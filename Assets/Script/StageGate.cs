using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ✨ SceneManager를 사용하기 위해 추가

public class StageGate : MonoBehaviour
{
    // Inspector에서 다음 씬 이름을 설정할 수 있게 합니다.
    public string nextSceneName = "level_2";

    public float gateHealth = 5f;

    private void Start()
    {
        // ✨ 게임 시작 시 또는 씬 로드 시 체력을 최대로 초기화
        gateHealth = 5f;
    }

    public void TakeDamage(float amount)
    {
        gateHealth -= amount;

        if (gateHealth <= 0)
        {
            LoadNextScene();     // 1. 씬 전환 요청을 먼저 합니다. (SceneManager가 다음 프레임에 씬 로드를 시작함)
        }
    }

    private void LoadNextScene()
    {
        // ⭐ Build Settings에 nextSceneName 씬이 추가되어 있어야 합니다. ⭐
        SceneManager.LoadScene(nextSceneName);
    }

}
