using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 28f;

    public float lifeTime = 2f;

    public float Damge;

    public float damage = 1f; // 투사체가 줄 피해량

    public GameObject experienceGemPrefab;

    private float damageAmount = 1f;

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
        // 충돌한 오브젝트가 "Enemy" 태그를 가지고 있는지 확인
        if (other.CompareTag("Enemy"))
        {
            // 1. 적(Enemy) 처리
            if (other.CompareTag("Enemy"))
            {
                Enemy enemyScript = other.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(damageAmount); // 적의 TakeDamage 호출 (경험치 드롭 유도)
                }
                Destroy(gameObject); // 투사체 파괴
            }
            else if (other.CompareTag("Gate")) // ⭐ Gate 태그를 가진 오브젝트와 충돌
            {
                StageGate gateScript = other.GetComponent<StageGate>();
                if (gateScript != null)
                {
                    gateScript.TakeDamage(damageAmount); // Gate에게 피해 입히기
                }
                Destroy(gameObject); // 투사체 파괴
            }

            // Enemy 태그가 아니지만 파괴되어야 하는 다른 오브젝트(예: 벽) 처리
            else if (!other.CompareTag("Player"))
            {
                // 플레이어와 충돌한 것이 아니라면 투사체 파괴 (필요에 따라 로직 수정 가능)
                Destroy(gameObject);
            }

        }
    }


}