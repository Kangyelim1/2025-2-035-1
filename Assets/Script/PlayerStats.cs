using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel = 1;
    public float currentExp = 0f;
    public float expToNextLevel = 100f;
    public Slider expSlider;
    public Text levelText;


    void Start()
    {
        // 초기 UI 상태 업데이트
        UpdateExpUI();
        UpdateLevelText();
    }

    public void GainExperience(float expAmount)
    {
        currentExp += expAmount;
        Debug.Log("경험치 획득: " + expAmount + " . 현재 경험치: " + currentExp); // Line 18

        CheckLevelUp(); // 레벨업 체크

        // // UI 업데이트 호출 시 반드시 괄호 ()를 붙여야 합니다.
        UpdateExpUI();   // ⭐ 수정! 괄호 () 추가
        UpdateLevelText(); // ⭐ 수정! 괄호 () 추가
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
