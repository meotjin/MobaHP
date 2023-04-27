using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Recorder.OutputPath;

public class Mia : Character
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
    private GameObject healCircle;
    [SerializeField] private float firstDuration = 10f;
    [SerializeField] private float cooldownOne = 40f;
    private bool canCastOne = true;

    [SerializeField] private GameObject buffRing;
    [SerializeField] private float secondDuration = 10f;
    [SerializeField] private float cooldownTwo = 30f;
    private bool canCastTwo = false;

    private void Start()
    {
        deathPrefeb = Resources.Load<GameObject>("GameObjects/DeathEffect");
        currentHealth = maxHealthPoint;
        slider.maxValue = maxHealthPoint;
        slider.value = currentHealth;
        healCircle = Resources.Load<GameObject>("GameObjects/HealingCircle");

        firstMechanicImg = Resources.Load<Sprite>("Druid2");
        mechanicOne = GameObject.Find("first");
        mechanicOne.GetComponent<Image>().sprite = firstMechanicImg;
        subMechanicOne = GameObject.Find("subFirst");
        subMechanicOne.GetComponent<Image>().sprite = firstMechanicImg;

        secondMechanicImg = Resources.Load<Sprite>("Druid9");
        mechanicTwo = GameObject.Find("second");
        mechanicTwo.GetComponent<Image>().sprite = secondMechanicImg;
        subMechanicTwo = GameObject.Find("subSecond");
        subMechanicTwo.GetComponent <Image>().sprite = secondMechanicImg;

        fillOne = subMechanicOne.GetComponent <Image>();
        fillTwo = subMechanicTwo.GetComponent<Image>();
    }
    private void Update()
    {
        slider.value = GetCurrentHealth();
        if (GetCurrentHealth() <= 0)
        {
            Instantiate(deathPrefeb, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        subMechanicOne.GetComponent<Button>().onClick.AddListener(HealingCircle);
        subMechanicTwo.GetComponent<Button>().onClick.AddListener(BuffingCircle);
    }

    public void HealingCircle()
    {
        if (canCastOne)
        {
            GameObject circle = Instantiate(healCircle, transform.position, transform.rotation);
            Destroy (circle, firstDuration);
            fillOne.fillAmount = 0;
            canCastOne = false;
        }
        
    }

    public void BuffingCircle()
    {
        if (canCastTwo)
        {
            buffRing.SetActive(true);
            fillTwo.fillAmount = 0;
            canCastTwo = false;
        }
    }

    private void FixedUpdate()
    {
        if (fillOne.fillAmount == 1)
        {
            canCastOne = true;
        }
        else fillOne.fillAmount += 0.02f / cooldownOne;

        if (fillTwo.fillAmount == 1)
        {
            canCastTwo = true;
        }
        else fillTwo.fillAmount += 0.02f / cooldownTwo;
        if (fillTwo.fillAmount >= secondDuration / cooldownTwo)
        {
            buffRing.SetActive(false);
        }
    }
}
