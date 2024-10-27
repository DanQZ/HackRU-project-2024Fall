using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float fatness = 0f;
    private float fatnessSlowingMitigator = 5f; // the amount of fatness required to reduce the speed by half
    public float speed { get; private set; } = 5f; 

    public float maxHP { get; private set; } = 100f;
    public float HP { get; private set; } = 100f;

    public float ChangeFatness(float amount)
    {
        fatness += amount;
        speed = 100f / (1f + (fatness / fatnessSlowingMitigator));
        return fatness;
    }

    public void TakeDamage(float amount)
    {
        float damage = -1f * Mathf.Abs(amount);
        HP -= damage;
        if(HP < 0)
        {
            HP = 0;
        }
        OnHPChange?.Invoke(damage);
    }

    public void TakeHealing(float amount)
    {
        float healing = Mathf.Abs(amount);
        HP += healing;
        if(HP > maxHP)
        {
            HP = maxHP;
        }
        OnHPChange?.Invoke(healing);
    }
    
    public event Action<float> OnHPChange;
}
