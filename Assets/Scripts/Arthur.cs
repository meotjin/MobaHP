using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;
using UnityEngine.UI;

public class Arthur : Character
{
    [SerializeField] private Slider slider;
    private Sprite firstMechanicImg;
    private Sprite secondMechanicImg;
    private GameObject mechanicOne;
    private GameObject mechanicTwo;
    private GameObject subMechanicTwo;
    private Image fill;
    [SerializeField] private float cooldown = 20f;

    private void Start()
    {
        passive();
        currentHealth = maxHealthPoint;
        slider.maxValue = maxHealthPoint;
        slider.value = currentHealth;
        deathPrefeb = Resources.Load<GameObject>("GameObjects/DeathEffect");
        firstMechanicImg = Resources.Load<Sprite>("Electromancer3");
        secondMechanicImg = Resources.Load<Sprite>("Electromancer16");

        mechanicOne = GameObject.Find("subFirst");
        mechanicTwo = GameObject.Find("second");
        subMechanicTwo = GameObject.Find("subSecond");
        mechanicOne.GetComponent<Image>().sprite = firstMechanicImg;
        mechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;
        subMechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;
        fill = subMechanicTwo.GetComponent<Image>();
    }

    private void Update()
    {
        slider.value = GetCurrentHealth();
        if (GetCurrentHealth() <= 0)
        {
            Instantiate(deathPrefeb, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (Input.touchCount > 0)
        {
            Debug.Log("AssPlz");
        }
    }

    private void passive()
    {
        attackRange *= .75f;
        moveSpeed *= 1.25f;

    }

    private void FixedUpdate()
    {
        if (fill.fillAmount != 1)
        {
            fill.fillAmount += 0.02f / cooldown;
        }
    }

}
