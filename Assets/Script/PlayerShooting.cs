using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;

    public Transform firePoint;
    Camera cam;

    int currentWeapon = 0;

    // 근접 무기 변수 추가
    [SerializeField]
    private GameObject meleeWeaponObject;

    private float swingDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        currentWeapon = 1 - currentWeapon;
    }

    void Shoot()
    {
        // 현재 무기에 따라 속도 설정
        if (currentWeapon == 1)
        {
            // ... 기존 코드
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Projectile 스크립트 가져오기
            Projectile projectileScript = proj.GetComponent<Projectile>();

            projectileScript.speed = 10f; // 첫 번째 무기 속도
        }
        else
        {
            if (meleeWeaponObject != null)
            {
                // 근접 무기 로직
                meleeWeaponObject.SetActive(true);
                StartCoroutine(SwingWeaponForDuration(swingDuration));
            }
            else
            {
                Debug.LogError("Melee Weapon Object가 Inspector에 할당되지 않았습니다!");
            }
            // ... 기존 코드
            // GameObject proj = Instantiate(projectilePrefab2, firePoint.position, Quaternion.identity);

            // Projectile 스크립트 가져오기
            //  Projectile projectileScript = proj.GetComponent<Projectile>();
            // projectileScript.speed = 20f; // 두 번째 무기 속도
        }

    }
    IEnumerator SwingWeaponForDuration(float duration)
    {
        // 설정된 시간(duration)만큼 대기합니다.
        yield return new WaitForSeconds(duration);

        // 대기가 끝나면 무기 오브젝트를 다시 비활성화하여 숨깁니다.
        if (meleeWeaponObject != null)
        {
            meleeWeaponObject.SetActive(false);
        }
    }
}
