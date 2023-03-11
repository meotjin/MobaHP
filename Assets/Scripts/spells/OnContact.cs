using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnContact : MonoBehaviour
{
    private float damage;
    [SerializeField] private GameObject particle;

    public float Damage
    {
        set => damage = value;
    }

    [SerializeField] private GameObject contactPrefab;

    private void OnCollisionEnter2D(Collision2D col)
    {
        // if the hitted object is a enemy reduce their hp
        if (col.gameObject.CompareTag("Player"))
        {
             Character character = col.gameObject.GetComponent<Character>();
             if (character.GetCurrentHealth() > 0)
             {
                character.SetCurrentHealth(character.GetCurrentHealth() - damage);
             }
        }
        // destroy the spell and instantiate hit particles on contact
        Instantiate(particle,transform.position,transform.rotation);
        Destroy(contactPrefab);
    }
}
