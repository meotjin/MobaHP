using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour
{
    // code for player to face the direction of movement
    private GameObject joystick;
    private FixedJoystick js;

    private void Start()
    {
        joystick = GameObject.Find("Move Joystick");
        js = joystick.GetComponent<FixedJoystick>();
    }

    private bool facingLeft;

    private void FixedUpdate()
    {
        float x = js.Horizontal;
        if (x > 0 && !facingLeft)
        {
            facingLeft = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(x < 0 && facingLeft)
        {
            facingLeft = false;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
