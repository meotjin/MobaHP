using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue : MonoBehaviour
{
    void Start()
    {
        transform.gameObject.GetComponent<Dummy>().SetTeam(0);
    }
}
