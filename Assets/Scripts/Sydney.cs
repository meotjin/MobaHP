using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sydney : Character
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        SetAttackDamage(GetAttackDamage() * 1.2f);
        SetAttackRange(GetAttackRange() * 1.25f);
        SetMoveSpeed(GetMoveSpeed() * .75f);
        SetCurrentHealth(GetMaxHealthPoint());
        slider.maxValue = GetMaxHealthPoint();
        slider.value = GetCurrentHealth();
        Debug.Log(slider.value);
    }
    private void Update()
    {
        slider.value = GetCurrentHealth();
        if (GetCurrentHealth() <= 0)
        {
            Instantiate(deathPrefeb,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
