using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 28f;

    public float lifeTime = 2f;

    public float Damge;

    public float damage = 1f; // ����ü�� �� ���ط�

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� "Enemy" �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Enemy"))
        {
            // 1. �浹�� �� ������Ʈ���� Enemy ��ũ��Ʈ�� �����ɴϴ�.
            Enemy enemyScript = other.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                // 2. ���� TakeDamage �Լ��� ȣ���Ͽ� ���ظ� �����ϴ�.
                // �� �Լ��� ���� ü���� ���ҽ�Ű��, ü���� 0�� �Ǹ� Die()�� ȣ���մϴ�.
                enemyScript.TakeDamage(damage);
            }

            // 3. ����ü(�ڽ�)�� �ı��մϴ�.
            Destroy(gameObject);
        }
        // Enemy �±װ� �ƴ����� �ı��Ǿ�� �ϴ� �ٸ� ������Ʈ(��: ��) ó��
        else if (!other.CompareTag("Player"))
        {
            // �÷��̾�� �浹�� ���� �ƴ϶�� ����ü �ı� (�ʿ信 ���� ���� ���� ����)
            Destroy(gameObject);
        }

    }
}
