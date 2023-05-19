using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnContact : MonoBehaviour
{
    private float damage;
    private GameObject particle;

    public float Damage
    {
        set => damage = value;
    }

    private void Start()
    {
        particle = Resources.Load<GameObject>("GameObjects/HitEffect");
    }

    [SerializeField] private GameObject contactPrefab;

    private void OnCollisionEnter2D(Collision2D col)
    {
        // if the hitted object is a enemy reduce their hp
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Dummy"))
        {
             Character character = col.gameObject.GetComponent<Character>();
             if (character.GetCurrentHealth() > 0)
             {
                character.SetCurrentHealth(character.GetCurrentHealth() - damage);
             }
        }
        else if (col.gameObject.CompareTag("Shield"))
        {
            col.gameObject.GetComponent<Shield>().getHit();
        }
        if (col.gameObject.CompareTag("Summon"))
        {
            Destroy(col.gameObject);
        }
        // destroy the spell and instantiate hit particles on contact
        GameObject effct = Instantiate(particle,transform.position,transform.rotation);
        Destroy(contactPrefab);
        Destroy(effct, 0.4f);
    }
   
}
