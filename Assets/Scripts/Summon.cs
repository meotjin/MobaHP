using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float moveSpeed = 3f;
    private bool set = false;

    public void Setup(GameObject p)
    {
        target = p;
        set = true;
    }

    private void Update()
    {
        if (set)
        {
            transform.position = Vector2.MoveTowards(transform.position,target.transform.position,moveSpeed * Time.deltaTime);
        }
           
    }
}
