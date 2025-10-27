using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum EnemyState { Idle, Trace, Attack, RunAway }

    public EnemyState state = EnemyState.Idle;

    public float moveSpeed = 2f;

    public float traceRange = 15;

    public float attackRange = 6f;

    public float attackCooldown = 1.5f;

    public float EnemyHelth = 5f;

    public GameObject projectilePrefad;

    public Transform firePoint;

    private Transform player;

    private float IastAttackTime;

    public int maxHP = 5;

    private int currentHp;

    private Rigidbody2D rb;

    private float currentHealth; // 체력 변수가 maxHP로 초기화된 곳

    public float experienceAmount = 10f; // 이 적을 처치하면 얻는 경험치 양

    public Slider hpSlider;

    //경험치
    public GameObject experienceGemPrefab; // 경험치 아이템 Prefab을 Inspector에서 연결
    public float experienceValue = 10f;  // 이 적이 드롭할 경험치 양

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        IastAttackTime = -attackCooldown;
        //경험치
        EnemyHelth = maxHP;
        currentHp = maxHP;
        rb = GetComponent<Rigidbody2D>();
        hpSlider.value = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(player.position, transform.position);


        if ((float)currentHp / maxHP < .2f)
        {
            state = EnemyState.RunAway;
        }


        switch (state)
        {
            case EnemyState.Idle:
                if (dist < traceRange)
                    state = EnemyState.Trace;
                break;
            case EnemyState.Trace:
                if (dist < attackRange)
                    state = EnemyState.Attack;
                else if (dist > traceRange)
                    state = EnemyState.Idle;
                else
                    TracePlayer();
                break;

            case EnemyState.Attack:
                if (dist > attackRange)
                    state = EnemyState.Trace;
                else
                    AttackPlayer();
                break;

            case EnemyState.RunAway:

                RunAway();
                break;
        }
    }

    
    public void TakeDamage(float amount)
    {
        EnemyHelth -= amount;

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0이 되면 사망 처리
        }
    }
    void RunAway()
    {
        if (player == null) return;
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * -moveSpeed * Time.deltaTime;
        transform.LookAt(player.position);
    }

    void Die()
    {
        // 1. 경험치 부여
        // PlayerStats.Instance가 null인지 확인하는 것이 안전합니다.
        if (PlayerStats.Instance != null)
        {
            PlayerStats.Instance.GainExperience(experienceAmount); // ✨ 경험치 전달
        }

        // 2. 적 파괴
        Destroy(gameObject);
    }

    void TracePlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
        transform.LookAt(player.position);
    }

    void AttackPlayer()
    {
        if (Time.time >= IastAttackTime + attackCooldown)
        {
            IastAttackTime = Time.time;
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefad != null && firePoint != null)
        {
            transform.LookAt(player.position);
            GameObject proj = Instantiate(projectilePrefad, firePoint.position, firePoint.rotation);
            EnemyProjectile ep = proj.GetComponent<EnemyProjectile>();

            if (ep != null)
            {
                Vector3 dir = (player.position - firePoint.position).normalized;
                ep.SetDirection(dir);
            }
        }
    }
}
