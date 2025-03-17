using UnityEngine;

public class Monster : MonoBehaviour
{
    public int HP = 100;
    public float Speed = 1f;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    public GameObject Item = null;
    void Start()
    {
        Invoke("CreateBullet", Delay);
    }
    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);
        Invoke("CreateBullet", Delay);
    }


    void Update()
    {
        //아래방향으로 움직여라
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    //미사일에 따른 데미지 입ㄴ는 함수
    public void Damage(int attack)
    {
        HP -= attack;
        if (HP <= 0)
        {
            ItemDrop();
            Destroy(gameObject);
        }
    }

    public void ItemDrop()
    {
        Instantiate(Item, transform.position, Quaternion.identity);
    }
}
