using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : MonoBehaviour
{
    public float expValue = 10f; // 이 아이템이 플레이어에게 줄 경험치 양
    public float pickupDistance = 2.0f; // 플레이어가 자동으로 끌어당기는 거리
    public float moveSpeed = 8f; // 플레이어에게 이동하는 속도

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        // 플레이어와의 거리가 pickupDistance 이하면 플레이어에게 이동
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= pickupDistance)
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    // 플레이어와 충돌(트리거) 시 경험치 제공
    private void OnTriggerEnter(Collider other)
    {
        // 3D 환경을 가정했습니다. 2D라면 OnTriggerEnter2D를 사용하세요.
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                // 경험치 획득 및 아이템 파괴
                playerStats.GainExperience(expValue);
                Destroy(gameObject);
            }
        }
    }
    
}
