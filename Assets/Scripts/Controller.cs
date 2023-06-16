using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private int blueScore;
    [SerializeField] private int redScore;

    [SerializeField] private int scoreLimit;

    [SerializeField] private Text redText;
    [SerializeField] private Text blueText;

    private void Start()
    {
        blueScore = 0;
        redScore = 0;

        scoreLimit = 30;

        blueText.text = blueScore.ToString();
        redText.text = redScore.ToString();
    }

    public void IncBlue()
    {
        ++blueScore;
        blueText.text = blueScore.ToString();
    }

    public void IncRed()
    {
        ++redScore;
        redText.text = redScore.ToString();
    }

    //when limit reacheded, end the game
}
