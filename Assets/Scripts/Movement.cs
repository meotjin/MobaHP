using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private FixedJoystick js;
    private GameObject joystick;
    private Character character;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
        joystick = GameObject.Find("Move Joystick");
        js = joystick.GetComponent<FixedJoystick>();
        character = GetComponent<Character> ();
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2 (rb.position.x + js.Horizontal * character.GetMoveSpeed() * Time.deltaTime,
            rb.position.y + js.Vertical * character.GetMoveSpeed() * Time.deltaTime);
        rb.MovePosition(direction);
    }
}
