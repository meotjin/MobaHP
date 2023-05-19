using System.Collections;
using System.Collections.Generic;
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
    private bool canCast;
    private bool canChoose;

    private void Start()
    {
        attackPoint = GameObject.Find("Attack").transform;
        spellPrefeb = Resources.Load<GameObject>("GameObjects/FireBall");
        icon = GameObject.Find("AttackIcon").GetComponent<Image>();

        passive();
        currentHealth = maxHealthPoint;
        slider.maxValue = maxHealthPoint;
        slider.value = currentHealth;
        deathPrefeb = Resources.Load<GameObject>("GameObjects/DeathEffect");
        firstMechanicImg = Resources.Load<Sprite>("Paladin14");
        secondMechanicImg = Resources.Load<Sprite>("Priest8");

        mechanicOne = GameObject.Find("subFirst");
        mechanicTwo = GameObject.Find("second");
        subMechanicTwo = GameObject.Find("subSecond");
        mechanicOne.GetComponent<Image>().sprite = firstMechanicImg;
        mechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;
        subMechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;
        subMechanicTwo.GetComponent<Button>().onClick.AddListener(Highlight);
        fill = subMechanicTwo.GetComponent<Image>();

        canCast = false;
        canChoose = true;
    }

    private void Update()
    {
        
        slider.value = GetCurrentHealth();
        if (GetCurrentHealth() <= 0)
        {
            Instantiate(deathPrefeb, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if ((Input.touchCount > 1) && (Input.GetTouch(1).phase == TouchPhase.Began))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit != null && hit.collider != null && canCast)
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                canChoose = false;
                canCast = false;
                DeHighlight();
                fill.fillAmount = 0;
            }
        }
    }

    private void passive()
    {
        attackRange *= .75f;
        moveSpeed *= 1.25f;

    }

    private void Highlight()
    {
        if (canCast && canChoose)
        {
            DeHighlight();
        }
        else if (!canCast && canChoose)
        {
            subMechanicTwo.GetComponent<Image>().color = new Color(0.745544f, 0.8301887f, 0.4887148f, 1);
            canCast = true;
        }
    }

    private void DeHighlight()
    {
        subMechanicTwo.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        canCast = false;
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
        if (fill.fillAmount == 1)
        {
            canChoose = true;
        }
        else fill.fillAmount += 0.02f / cooldown;

        if (icon.fillAmount == 1) { canAttack = true; }
        else icon.fillAmount += 0.02f / attackCooldown;
    }

}
