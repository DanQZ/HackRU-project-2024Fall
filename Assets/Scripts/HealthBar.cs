using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player playerRef;
    private float maxHP => playerRef.maxHP;
    private float currentHP => playerRef.HP;
    private float barWidthDefault = 1f;

    void Start(){
        playerRef.OnHPChange += UpdateHealthBar;
    }

    [SerializeField] private GameObject greenBar;
    // event handler
    private void UpdateHealthBar(float any){
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        float barWidth = barWidthDefault * (currentHP / maxHP);
        greenBar.transform.localScale = new Vector3(barWidth, greenBar.transform.localScale.y, 1f);
    }
}
