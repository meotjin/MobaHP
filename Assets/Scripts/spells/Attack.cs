using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    private Character character;
    private GameObject spellPrefeb;
    private Transform attackPoint;
    private bool canAttack;
    private Image icon;

    private void Start()
    {
        character = GetComponent<Character>();
        attackPoint = GameObject.Find("Attack").transform;
        spellPrefeb = Resources.Load<GameObject>("GameObjects/FireBall");
        icon = GameObject.Find("AttackIcon").GetComponent<Image>();
    }

    // basic attack logic
    public void Expelliarmus()
    {
        if (canAttack)
        {
            Quaternion rot = attackPoint.rotation;
            canAttack = false;
            icon.fillAmount = 0;
            GameObject spell = Instantiate(spellPrefeb, attackPoint.position, rot);
            spell.transform.Rotate(0,0,rot.z+90);
            spell.GetComponent<OnContact>().Damage = character.GetAttackDamage();
            Rigidbody2D spellRb = spell.GetComponent<Rigidbody2D>();
            spellRb.AddForce(attackPoint.up * character.GetAttackSpeed(), ForceMode2D.Impulse);
            Destroy(spell, character.GetAttackRange()/200f);
        } 
    }

    private void FixedUpdate()
    {
        if (icon.fillAmount == 1) { canAttack = true; }
        else icon.fillAmount += 0.02f;
        //Debug.Log(attackPoint.rotation.z);
    }

}
