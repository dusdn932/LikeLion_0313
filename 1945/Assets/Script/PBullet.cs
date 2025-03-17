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
        //�̻��� ���ʹ���
        //���ǹ��� * ���ǵ� * Ÿ��
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    //ȭ�� ������ �������
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
            //���ͻ���
            collision.gameObject.GetComponent<Monster>().Damage(Attack);
            //PoolManager.Instance.Return(collision.gameObject);
            //�̻��� ����
            Destroy(gameObject);
            
        }
        else if (collision.CompareTag("Boss"))
        {

            //����Ʈ����
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //1�ʵڿ� �����
            Destroy(go, 1);
            collision.gameObject.GetComponent<Boss>().Damage(Attack);
            //�̻��� ����
            Destroy(gameObject);

        }
    }
}
