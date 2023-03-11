using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FixedJoystick js;
    [SerializeField] private Character character;
  
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2 (rb.position.x + js.Horizontal * character.GetMoveSpeed() * Time.deltaTime,
            rb.position.y + js.Vertical * character.GetMoveSpeed() * Time.deltaTime);
        rb.MovePosition(direction);
    }
}
