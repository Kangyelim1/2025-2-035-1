using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 필수

public class StageGate : MonoBehaviour
{
    // Inspector에서 다음 씬 이름을 설정할 수 있게 합니다.
    public string nextSceneName = "Level 2";

    public float gateHealth = 5f;

    public void TakeDamage(float amount)
    {
        gateHealth -= amount;

        if (gateHealth <= 0)
        {
            Destroy(gameObject); // Gate 파괴
            LoadNextScene();     // 씬 전환 함수 호출
        }
    }

    private void LoadNextScene()
    {
        // ⭐ Build Settings에 nextSceneName 씬이 추가되어 있어야 합니다. ⭐
        SceneManager.LoadScene(nextSceneName);
    }

}
