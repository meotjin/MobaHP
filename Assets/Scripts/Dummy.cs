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
            Destroy(gameObject);
        }
    }
}
