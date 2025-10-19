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

    // ���� ���� ���� �߰�
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
        // ���� ���⿡ ���� �ӵ� ����
        if (currentWeapon == 1)
        {
            // ... ���� �ڵ�
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Projectile ��ũ��Ʈ ��������
            Projectile projectileScript = proj.GetComponent<Projectile>();

            projectileScript.speed = 10f; // ù ��° ���� �ӵ�
        }
        else
        {
            if (meleeWeaponObject != null)
            {
                // ���� ���� ����
                meleeWeaponObject.SetActive(true);
                StartCoroutine(SwingWeaponForDuration(swingDuration));
            }
            else
            {
                Debug.LogError("Melee Weapon Object�� Inspector�� �Ҵ���� �ʾҽ��ϴ�!");
            }
            // ... ���� �ڵ�
            // GameObject proj = Instantiate(projectilePrefab2, firePoint.position, Quaternion.identity);

            // Projectile ��ũ��Ʈ ��������
            //  Projectile projectileScript = proj.GetComponent<Projectile>();
            // projectileScript.speed = 20f; // �� ��° ���� �ӵ�
        }

    }
    IEnumerator SwingWeaponForDuration(float duration)
    {
        // ������ �ð�(duration)��ŭ ����մϴ�.
        yield return new WaitForSeconds(duration);

        // ��Ⱑ ������ ���� ������Ʈ�� �ٽ� ��Ȱ��ȭ�Ͽ� ����ϴ�.
        if (meleeWeaponObject != null)
        {
            meleeWeaponObject.SetActive(false);
        }
    }
}
