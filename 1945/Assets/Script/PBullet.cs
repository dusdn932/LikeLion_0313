using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;
    public int Attack = 10;
    public GameObject effect;
    void Start()
    {
        
    }

    void Update()
    {
        //미사일 위쪽방향
        //위의방향 * 스피드 * 타임
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    //화면 밖으로 나갈경우
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(go, 1);
            //몬스터삭제
            collision.gameObject.GetComponent<Monster>().Damage(Attack);
            //PoolManager.Instance.Return(collision.gameObject);
            //미사일 삭제
            Destroy(gameObject);
            
        }
        else if (collision.CompareTag("Boss"))
        {

            //이펙트생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //1초뒤에 지우기
            Destroy(go, 1);
            collision.gameObject.GetComponent<Boss>().Damage(Attack);
            //미사일 삭제
            Destroy(gameObject);

        }
    }
}
