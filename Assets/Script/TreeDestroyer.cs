using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeDestroyer : MonoBehaviour
{

    public string level_2 = "level_2";

    // 나무의 체력을 설정 (투사체의 피해량을 기준으로)
    public float treeHealth = 5f;

    // 외부에서 피해를 받을 때 호출되는 함수
    public void TakeDamage(float amount)
    {
        treeHealth -= amount;

        if (treeHealth <= 0)
        {
            Destroy(gameObject); // 나무 파괴
            LoadNextScene();     // 함수 호출
        }
    }
    // LoadNextScene 함수는 아래처럼 하나만 남겨야 합니다.
    void LoadNextScene()
    {
        // Level 2 씬이 로드됩니다.
        SceneManager.LoadScene("Level 2");
    }
}
