using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Sydney : Character
{
    [SerializeField] private Slider slider;
    private Sprite firstMechanicImg;
    private Sprite secondMechanicImg;
    private GameObject mechanicOne;
    private GameObject mechanicTwo;
    private GameObject subMechanicTwo;
    private Image fill;
    [SerializeField] private float cooldown = 20f;
    [SerializeField] private float duration = 4f;
    [SerializeField] public GameObject fireCloak;
    private bool canCast;

    private void Start()
    {
        passive();
        currentHealth = maxHealthPoint;
        slider.maxValue = maxHealthPoint;
        slider.value = currentHealth;
        deathPrefeb = Resources.Load<GameObject>("GameObjects/DeathEffect");
        firstMechanicImg = Resources.Load<Sprite>("Necromancer13");
        secondMechanicImg = Resources.Load<Sprite>("Necromancer3");

        mechanicOne = GameObject.Find("subFirst");
        mechanicTwo = GameObject.Find("second");
        subMechanicTwo = GameObject.Find("subSecond");
        mechanicOne.GetComponent<Image>().sprite = firstMechanicImg;
        mechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;
        subMechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;
        fill = subMechanicTwo.GetComponent<Image>();
        canCast = true;
        fireCloak.SetActive(false);
    }
    private void Update()
    {
        slider.value = GetCurrentHealth();
        if (GetCurrentHealth() <= 0)
        {
            Instantiate(deathPrefeb,transform.position,transform.rotation);
            Destroy(gameObject);
        }
        subMechanicTwo.GetComponent<Button>().onClick.AddListener(FireCloak);
    }

    private void passive()
    {
        attackDamage *= 1.2f;
        attackRange *= 1.25f;
        moveSpeed *= .75f;

    }

    public void FireCloak()
    {
        if (canCast)
        {
            canCast = false;
            fill.fillAmount = 0;
            fireCloak.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (fill.fillAmount == 1) {
            canCast = true;
        }
        else fill.fillAmount += 0.02f/cooldown;
        if (fill.fillAmount >= duration / cooldown)
        {
            fireCloak.SetActive(false);
        }
    }
}
