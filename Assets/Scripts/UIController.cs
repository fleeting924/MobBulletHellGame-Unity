using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake(){
        instance = this;
    }

    public Slider explvlSlider;
    public TMP_Text expLvlText;

    public GameObject levelUpPanel;

    public PlayerStatUpgradeDisplay attackPowerUpgradeDisplay, attackSpeedUpgradeDisplay, moveSpeedUpgradeDisplay, healthUpgradeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLvl)
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;

        expLvlText.text = "Level: " + currentLvl;
    }

    public void LevelUpAttackPower()
    {
        PlayerStatController.instance.LevelUpAttackPower();
        UIController.instance.levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LevelUpAttackSpeed()
    {
        PlayerStatController.instance.LevelUpAttackSpeed();
        UIController.instance.levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LevelUpMoveSpeed()
    {
        PlayerStatController.instance.LevelUpMoveSpeed();
        UIController.instance.levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LevelUpHealth()
    {
        PlayerStatController.instance.LevelUpHealth();
        UIController.instance.levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
