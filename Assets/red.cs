using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{
    void Start()
    {
        transform.gameObject.GetComponent<Dummy>().SetTeam(1);
    }

    
}
