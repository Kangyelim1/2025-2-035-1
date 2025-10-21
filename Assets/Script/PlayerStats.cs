using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  public int currentLevel = 1;
    public float currentExp = 0f;
    public float expToNextLevel = 100f; // 레벨업에 필요한 기본 경험치

    public void GainExperience(float expAmount)
    {
        currentExp += expAmount;
        Debug.Log("경험치 획득: " + expAmount + ". 현재 경험치: " + currentExp);
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        while (currentExp >= expToNextLevel)
        {
            // 레벨업 처리
            currentLevel++;
            currentExp -= expToNextLevel;

            // 다음 레벨업에 필요한 경험치 증가 (예: 10% 증가)
            expToNextLevel *= 1.1f; 

            Debug.Log("레벨업! 현재 레벨: " + currentLevel);

            // 레벨업 시 다른 효과 (체력 증가, 스탯 증가 등)를 여기서 처리할 수 있습니다.
        }
    }
}
