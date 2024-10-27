using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //singleton 
    public static Player instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private float fatness = 0f;
    private float fatnessSlowingMitigator = 5f; // the amount of fatness required to reduce the speed by half
    public float speed { get; private set; } = 5f; 
    public float sizeExponent { get; private set; } = 1.1f;

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
        float damageAmount = -1f * Mathf.Abs(amount);
        HP -= damageAmount;
        if(HP < 0f)
        {
            HP = 0f;
        }
        OnHPChange?.Invoke(damageAmount);
    }

    public void TakeHealing(float amount)
    {
        float healingAmount = Mathf.Abs(amount);
        HP += healingAmount;
        if(HP > maxHP)
        {
            HP = maxHP;
        }
        OnHPChange?.Invoke(healingAmount);
    }
    
    public event Action<float> OnHPChange;

    public void OnTrigger2DEnter(Collider2D other)
    {
        string tag = other.tag;
        switch(tag)
        {
            case "catfood":
                ChangeFatness(1f);
                break;
            case "bullet":
                TakeDamage(10f);
                break;
        }
    }
}
