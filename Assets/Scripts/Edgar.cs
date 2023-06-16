using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Edgar : Character
{
    [SerializeField] private Slider slider;
    private Sprite firstMechanicImg;
    private Sprite secondMechanicImg;
    private GameObject mechanicOne;
    private GameObject mechanicTwo;
    private GameObject subMechanicOne;
    private GameObject subMechanicTwo;
    private Image fillOne;
    private Image fillTwo;

    [SerializeField] private Transform spot1;
    [SerializeField] private Transform spot2;
    [SerializeField] private Transform spot3;

    private float firstDuration = 10f;

    private GameObject mimic;
    private GameObject summon;

    [SerializeField] private float cooldownOne = 40f;
    private bool canCastOne = true;

    [SerializeField] private float cooldownTwo = 40f;
    private bool canCastTwo = false;
    private bool canChoose = true;

    private void Start()
    {
        attackPoint = GameObject.Find("Attack").transform;
        spellPrefeb = Resources.Load<GameObject>("GameObjects/FireBall");
        icon = GameObject.Find("AttackIcon").GetComponent<Image>();

        mimic = Resources.Load<GameObject>("GameObjects/Mimic");
        summon = Resources.Load<GameObject>("GameObjects/Summon1");

        deathPrefeb = Resources.Load<GameObject>("GameObjects/DeathEffect");
        currentHealth = maxHealthPoint;
        slider.maxValue = maxHealthPoint;
        slider.value = currentHealth;

        firstMechanicImg = Resources.Load<Sprite>("DemonHunter20");
        mechanicOne = GameObject.Find("first");
        mechanicOne.GetComponent<Image>().sprite = firstMechanicImg;
        subMechanicOne = GameObject.Find("subFirst");
        subMechanicOne.GetComponent<Image>().sprite = firstMechanicImg;

        secondMechanicImg = Resources.Load<Sprite>("ShapeShifter3");
        mechanicTwo = GameObject.Find("second");
        mechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;
        subMechanicTwo = GameObject.Find("subSecond");
        subMechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;

        fillOne = subMechanicOne.GetComponent<Image>();
        fillTwo = subMechanicTwo.GetComponent<Image>();

        subMechanicTwo.GetComponent<Button>().onClick.AddListener(Highlight);
        subMechanicOne.GetComponent<Button>().onClick.AddListener(Mimic);
    }

    public void Mimic()
    {
        if (canCastOne)
        {
            GameObject mim = Instantiate(mimic, transform.position, transform.rotation);
            Destroy(mim, firstDuration);
            fillOne.fillAmount = 0;
            canCastOne = false;
        }
    }
    private void Update()
    {
        slider.value = GetCurrentHealth();
        if (GetCurrentHealth() <= 0)
        {
            Instantiate(deathPrefeb, transform.position, transform.rotation);
            Destroy(gameObject);
            if (team == "blue")
            {
                GameObject.Find("GameController").GetComponent<Controller>().IncRed();
            }
            else if (team == "red")
            {
                GameObject.Find("GameController").GetComponent<Controller>().IncBlue();
            }
        }

        if ((Input.touchCount > 1) && (Input.GetTouch(1).phase == TouchPhase.Began))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit != null && hit.collider != null && hit.collider.gameObject.GetComponent<Character>().GetTeam() != GetTeam() && canCastOne)
            {
                Debug.Log(spot1.position);
                GameObject summon1 = Instantiate(summon, spot1.position, spot1.rotation);
                summon1.GetComponent<Summon>().Setup(hit.collider.gameObject);
                GameObject summon2 = Instantiate(summon, spot2.position, spot2.rotation);
                summon2.GetComponent<Summon>().Setup(hit.collider.gameObject);
                GameObject summon3 = Instantiate(summon, spot3.position, spot3.rotation);
                summon3.GetComponent<Summon>().Setup(hit.collider.gameObject);
                canCastTwo = false;
                canChoose = false;
                DeHighlight();
                fillTwo.fillAmount = 0;
            }
        }
    }

    private void Highlight()
    {
        if (canCastTwo && canChoose)
        {
            DeHighlight();
        }
        else if (!canCastTwo && canChoose)
        {
            subMechanicTwo.GetComponent<Image>().color = new Color(0.745544f, 0.8301887f, 0.4887148f, 1);
            canCastTwo = true;
        }
    }

    private void DeHighlight()
    {
        subMechanicTwo.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        canCastTwo = false;
    }

    private void FixedUpdate()
    {
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
        if (fillOne.fillAmount == 1)
        {
            canCastOne = true;
        }
        else fillOne.fillAmount += 0.02f / cooldownOne;

        if (fillTwo.fillAmount == 1)
        {
            canChoose = true;
        }
        else fillTwo.fillAmount += 0.02f / cooldownTwo;

        if (icon.fillAmount == 1) { canAttack = true; }
        else icon.fillAmount += 0.02f / attackCooldown;
    }
}
