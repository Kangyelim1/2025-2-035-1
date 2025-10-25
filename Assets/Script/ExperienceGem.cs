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

        float distance = Vector3.Distance(transform.position, player.position);

        // 거리가 pickupDistance 이하면 플레이어에게 이동 시작
        if (distance <= pickupDistance)
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        // 플레이어를 향하는 방향 벡터 계산 및 이동 로직
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    // OnTriggerEnter 함수는 image_7f2349.png 와 같이 올바르게 작성되어 있습니다.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.GainExperience(expValue);
                Destroy(gameObject);
            }
        }
    }

}
