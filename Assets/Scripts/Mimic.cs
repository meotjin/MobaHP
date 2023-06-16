using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    private string team = "neuteral";

    public void SetTeam(string t)
    {
        team = t;
    }
    public string GetTeam()
    {
        return team;
    }
}
