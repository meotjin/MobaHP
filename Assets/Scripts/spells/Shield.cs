using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hits = 0;
    
    public void getHit()
    {
        hits++;
    }

    private void Update()
    {
        if (hits == 3)
        {
            hits = 0;
            gameObject.SetActive(false);
            GameObject.Find("underShield").SetActive(false);
        }
    }
}
