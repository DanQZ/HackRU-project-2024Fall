using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player playerRef;
    private float maxHP => playerRef.maxHP;
    private float currentHP => playerRef.HP;
    private float barWidthDefault = 1f;
    private float barHeightDefault = 0.1f;

    public void UpdateHealthBar()
    {
        float barWidth = barWidthDefault * (currentHP / maxHP);
        transform.localScale = new Vector3(barWidth, barHeightDefault, 1f);
    }
}
