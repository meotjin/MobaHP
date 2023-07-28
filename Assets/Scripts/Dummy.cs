using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dummy : Character
{
    [SerializeField] private Slider slider;
    private void Start()
    {
        deathPrefeb = Resources.Load<GameObject>("GameObjects/DeathEffect");
        currentHealth = maxHealthPoint;
        slider.maxValue = maxHealthPoint;
        slider.value = currentHealth;
    }
    private void Update()
    {
        slider.value = GetCurrentHealth();
        if (GetCurrentHealth() <= 0)
        {
            Instantiate(deathPrefeb, transform.position, transform.rotation);
            if (team == "red")
            {
                GameObject.Find("GameController").GetComponent<Controller>().IncBlue();
            }
            else if (team == "blue")
            {
                GameObject.Find("GameController").GetComponent<Controller>().IncRed();
            }
            SetCurrentHealth(GetMaxHealthPoint());
        }
        if (takingFireDmg)
        {
            currentHealth -= 1f;
        }
        if (takingSummonDmg)
        {
            currentHealth -= 1f;
        }
        if (healing)
        {
            if (currentHealth < maxHealthPoint)
            {
                currentHealth += 0.2f;
            }
        }
    }
    private void FixedUpdate()
    {
        if (takingFireDmg)
        {
            currentHealth -= 1f;
        }
        if (healing)
        {
            if (currentHealth < maxHealthPoint)
            {
                currentHealth += 0.2f;
            }
        }
    }
}
