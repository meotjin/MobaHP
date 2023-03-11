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
    private float moveSpeed = 10f;
    private float maxHealthPoint = 500f;
    private float currentHealth;
    private float attackDamage = 50f;
    private float attackRange = 100f;
    private float attackSpeed = 20f;
    [SerializeField] protected GameObject deathPrefeb;

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
}
