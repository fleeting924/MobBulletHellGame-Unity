using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    public static PlayerStatController instance;
    private void Awake(){
        instance = this;
    }

    public List<PlayerStatValue> attackPower, attackSpeed, moveSpeed, health;
    public int attackPowerLevelCount, attackSpeedLevelCount, moveSpeedLevelCount, healthLevelCount;

    public int attackPowerLevel, attackSpeedLevel, moveSpeedLevel, healthLevel;

    public EnemyDamager damager;

    // Start is called before the first frame update
    void Start()
    {
        damager.damageAmount = attackPower[attackPowerLevel].value;

        for(int i = attackPower.Count - 1; i < attackPowerLevelCount; i++)
        {
            attackPower.Add(new PlayerStatValue(attackPower[i].value + (attackPower[1].value - attackPower[0].value)));
        }

        for(int i = attackSpeed.Count - 1; i < attackSpeedLevelCount; i++)
        {
            attackSpeed.Add(new PlayerStatValue(attackSpeed[i].value + (attackSpeed[1].value - attackSpeed[0].value)));
        }

        for(int i = moveSpeed.Count - 1; i < moveSpeedLevelCount; i++)
        {
            moveSpeed.Add(new PlayerStatValue(moveSpeed[i].value + (moveSpeed[1].value - moveSpeed[0].value)));
        }

        for(int i = health.Count - 1; i < healthLevelCount; i++)
        {
            health.Add(new PlayerStatValue(health[i].value + (health[1].value - health[0].value)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(UIController.instance.levelUpPanel.activeSelf == true)
        {
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        if(attackPowerLevel < attackPower.Count - 1)
        {
            UIController.instance.attackPowerUpgradeDisplay.UpdateDisplay(attackPowerLevel+1, attackPowerLevel+2);
        } else 
        {
            UIController.instance.attackPowerUpgradeDisplay.ShowMaxLevel();
        }
        if(attackSpeedLevel < attackSpeed.Count - 1)
        {
        UIController.instance.attackSpeedUpgradeDisplay.UpdateDisplay(attackSpeedLevel+1, attackSpeedLevel+2);
        } else 
        {
            UIController.instance.attackSpeedUpgradeDisplay.ShowMaxLevel();
        }
        if(moveSpeedLevel < moveSpeed.Count - 1)
        {
        UIController.instance.moveSpeedUpgradeDisplay.UpdateDisplay(moveSpeedLevel+1 , moveSpeedLevel+2);
        } else 
        {
            UIController.instance.moveSpeedUpgradeDisplay.ShowMaxLevel();
        }
        if(healthLevel < health.Count - 1)
        {
        UIController.instance.healthUpgradeDisplay.UpdateDisplay(healthLevel+1, healthLevel+2);
        } else 
        {
            UIController.instance.healthUpgradeDisplay.ShowMaxLevel();
        } 
    }

    public void LevelUpAttackPower()
    {
        attackPowerLevel++;
        UpdateDisplay();
        
        damager.damageAmount = attackPower[attackPowerLevel].value;
    }

    public void LevelUpAttackSpeed()
    {
        attackSpeedLevel++;
        UpdateDisplay();
        
        Gun1.instance.fireRate = attackSpeed[attackSpeedLevel].value;
        Gun2.instance.fireRate = attackSpeed[attackSpeedLevel].value;
    }

    public void LevelUpMoveSpeed()
    {
        moveSpeedLevel++;
        UpdateDisplay();

        PlayerController.instance.moveSpeed = moveSpeed[moveSpeedLevel].value;
    }

    public void LevelUpHealth()
    {
        healthLevel++;
        UpdateDisplay();

        PlayerHealthController.instance.maxHealth = health[healthLevel].value;
    }
}

[System.Serializable]
public class PlayerStatValue
{
    public float value;

    public PlayerStatValue(float newValue)
    {
        value = newValue;
    }
}