using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 28f;

    public float lifeTime = 2f;

    public float Damge;

    public float damage = 1f; // 투사체가 줄 피해량

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
            // 1. 충돌한 적 오브젝트에서 Enemy 스크립트를 가져옵니다.
            Enemy enemyScript = other.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                // 2. 적의 TakeDamage 함수를 호출하여 피해를 입힙니다.
                // 이 함수는 적의 체력을 감소시키고, 체력이 0이 되면 Die()를 호출합니다.
                enemyScript.TakeDamage(damage);
            }

            // 3. 투사체(자신)를 파괴합니다.
            Destroy(gameObject);
        }
        // Enemy 태그가 아니지만 파괴되어야 하는 다른 오브젝트(예: 벽) 처리
        else if (!other.CompareTag("Player"))
        {
            // 플레이어와 충돌한 것이 아니라면 투사체 파괴 (필요에 따라 로직 수정 가능)
            Destroy(gameObject);
        }

    }
}
