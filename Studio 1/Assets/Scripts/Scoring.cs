using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Scoring : MonoBehaviour
{
    public TMP_Text text;
    string scoreWord;
    int currentScore, velocity;

    // Start is called before the first frame update
    void Start()
    {
        scoreWord = "SCORE: ";
        currentScore = 0;
        velocity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GetScore();
        UpdateUIScore();
    }

    void GetScore()
    {
        currentScore += 1 * velocity;
    }

    void UpdateUIScore()
    {
        text.text = scoreWord + currentScore;
    }

    //Created by Josh Shinnick.
}
