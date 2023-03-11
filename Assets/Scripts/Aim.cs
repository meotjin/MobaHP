using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private FixedJoystick js;
    [SerializeField] private SpriteRenderer aim; // the aiming triangle
    [SerializeField] private Attack attack;

    private double current;
    private double before;

    private void Start()
    {
        current = 0;
        before = 0;
    }

    private void Update()
    {
        float x = js.Horizontal;
        float y = js.Vertical;

        // calculating the position of joystick in current and last frame
        before = current;
        current = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

        if (x != 0 && y != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, (float)(Math.Atan2(y, x) * 180 / Math.PI - 90));
             
            if (current >= .7d) aim.enabled = true;
            else aim.enabled = false;
            
        }
        else
        {
            
            aim.enabled = false;
            
            //checking if the joystick has been released while drawn to shoot
            if (before - current >= .7d)
            {
                attack.Expelliarmus();
            }
            transform.rotation = Quaternion.Euler(0, 0, 0 - transform.rotation.z);
        }
    }
}
