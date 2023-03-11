using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour
{
    // code for player to face the direction of movement
    [SerializeField] FixedJoystick js;

    private void FixedUpdate()
    {
        float x = js.Horizontal;
        float y = js.Vertical;
        if (x != 0 && y != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, (float)(Math.Atan2(y, x) * 180 / Math.PI - 90)); 
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 - transform.rotation.z);
        }
    }
}
