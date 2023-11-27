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

    // Start is called before the first frame update
    void Start()
    {
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