using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel = 1;
    public float currentExp = 0f;
    public float expToNextLevel = 100f;

    public Slider expSlider; // Inspector에서 경험치 바 Slider 연결
    public Text levelText;   // (선택 사항) 레벨을 표시할 Text UI


    void Start()
    {
        // 초기 UI 상태 업데이트
        UpdateExpUI();
        UpdateLevelText();
    }

    // 경험치 획득 함수 (이 함수가 스크립트에 딱 하나만 있어야 합니다!)
    public void GainExperience(float expAmount)
    {
        currentExp += expAmount;
        Debug.Log("경험치 획득: " + expAmount + ". 현재 경험치: " + currentExp);

        CheckLevelUp();

        // 함수 호출 시 괄호 ()는 필수입니다.
        UpdateExpUI();
        UpdateLevelText(); // ⭐ 괄호 ()가 추가되어 오류를 해결했습니다.
    }

    private void CheckLevelUp()
    {
        while (currentExp >= expToNextLevel)
        {
            currentLevel++;
            currentExp -= expToNextLevel;
            expToNextLevel *= 1.1f; // 다음 레벨업 경험치 증가

            Debug.Log("레벨업! 현재 레벨: " + currentLevel);
        }
    }

    // 경험치 바 UI 업데이트 함수
    private void UpdateExpUI()
    {
        if (expSlider != null)
        {
            expSlider.value = currentExp / expToNextLevel;
        }
    }

    // 레벨 텍스트 UI 업데이트 함수
    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Lv. " + currentLevel.ToString();
        }
    }

}
