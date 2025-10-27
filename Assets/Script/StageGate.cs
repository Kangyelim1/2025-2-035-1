using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ✨ SceneManager를 사용하기 위해 추가

public class StageGate : MonoBehaviour
{
    public string objectInfo;

    // 플레이어 오브젝트가 이 게이트를 통과할 때 실행됨
    private void OnTriggerEnter(Collider other)
    {
        // 1. 충돌한 오브젝트가 플레이어인지 확인
        // 플레이어 오브젝트에 "Player" 태그가 붙어있다고 가정
        if (other.CompareTag("Player"))
        {
            // 2. 씬 로드: Inspector의 objectInfo(씬 이름)으로 이동
            SceneManager.LoadScene(objectInfo);
        }
    }
}
