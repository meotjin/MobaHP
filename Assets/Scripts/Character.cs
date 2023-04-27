using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// root of all character classes
public class Character : MonoBehaviour
{
    // properties
    [SerializeField] protected float maxHealthPoint = 500f;
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float attackDamage = 50f;
    [SerializeField] protected float attackRange = 100f;
    [SerializeField] protected float attackSpeed = 20f;
    protected GameObject deathPrefeb;

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
    }

    protected void FixedUpdate()
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


