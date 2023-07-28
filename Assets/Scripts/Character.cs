using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

// root of all character classes
public class Character : MonoBehaviour
{
    protected AudioSource att;

    // properties
    protected string team = "neuteral";

    public void SetTeam(int k)
    {
        switch (k)
        {
            case 0:
                team = "blue";
                break;
            case 1:
                team = "red";
                break;
            default:
                team = "neuteral";
                break;
        }
    }

    public string GetTeam()
    {
        return team;
    }

    [SerializeField] protected float maxHealthPoint = 500f;
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float attackDamage = 50f;
    [SerializeField] protected float attackRange = 100f;
    [SerializeField] protected float attackSpeed = 20f;
    protected GameObject deathPrefeb;

    protected GameObject spellPrefeb;
    protected Transform attackPoint;
    protected bool canAttack;
    protected Image icon;
    [SerializeField] protected float attackCooldown = 0.5f;

    // encapsulation
    public void SetMoveSpeed(float amount)
    {
        moveSpeed = amount;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMaxHealthPoint(float amount)
    {
        maxHealthPoint = amount;
    }

    public float GetMaxHealthPoint()
    {
        return maxHealthPoint;
    }

    public void SetCurrentHealth(float amount)
    {
        currentHealth = amount;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetAttackDamage(float amount)
    {
        attackDamage = amount;
    }

    public float GetAttackDamage()
    {
        return attackDamage;
    }

    public void SetAttackRange(float amount)
    {
        attackRange = amount;
    }

    public float GetAttackRange()
    {
        return attackRange;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    protected bool takingFireDmg = false;
    protected bool healing = false;
    protected bool takingSummonDmg = false;
    [SerializeField] protected Image healthBar;
    [SerializeField] protected GameObject underBuffLogo;

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireCloak"))
        {
            takingFireDmg = true;
        }
        if (collision.gameObject.CompareTag("HealingCircle"))
        {
            healing = true;
            healthBar.color = new Color( 20f/255, 181f/255, 1f/255, 1);
        }
        if (collision.gameObject.CompareTag("BuffingCircle"))
        {
            attackSpeed *= 1.1f;
            attackDamage *= 1.1f;
            attackRange *= 1.1f;
            underBuffLogo.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Mimic") && collision.gameObject.GetComponent<Mimic>().GetTeam() != team)
        {
            currentHealth -= 200;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Summon") && collision.gameObject.GetComponent<Summon>().GetTeam() != team)
        {
            Debug.Log("ass");
            takingSummonDmg = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireCloak"))
        {
            takingFireDmg = false;
        }
        if (collision.gameObject.CompareTag("HealingCircle"))
        {
            healing = false;
            healthBar.color = new Color(212f / 255, 23f / 255, 23f / 255, 1);
        }
        if (collision.gameObject.CompareTag("BuffingCircle"))
        {
            attackSpeed /= 1.1f;
            attackDamage /= 1.1f;
            attackRange /= 1.1f;
            underBuffLogo.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Summon") && collision.gameObject.GetComponent<Summon>().GetTeam() != team)
        {
            takingSummonDmg = false;
        }
    }

    public void Expelliarmus()
    {
        if (canAttack)
        {
            Quaternion rot = attackPoint.rotation;
            canAttack = false;
            icon.fillAmount = 0;
            GameObject spell = Instantiate(spellPrefeb, attackPoint.position, rot);
            //att.Play();
            spell.transform.Rotate(0, 0, rot.z + 90);
            spell.GetComponent<OnContact>().Damage = GetAttackDamage();
            Rigidbody2D spellRb = spell.GetComponent<Rigidbody2D>();
            spellRb.AddForce(attackPoint.up * GetAttackSpeed(), ForceMode2D.Impulse);
            Destroy(spell, GetAttackRange() / 200f);
        }
    }
}


