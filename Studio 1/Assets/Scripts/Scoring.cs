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
    public Rigidbody2D playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        scoreWord = "SCORE: ";
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (int) (-1 * playerVelocity.velocity.y);
        GetScore();
        UpdateUIScore();
    }

    void GetScore()
    {
        Debug.Log(velocity);
        currentScore += (1 * velocity);
    }

    void UpdateUIScore()
    {
        text.text = scoreWord + currentScore;
        Singleton.Instance.hiScore = currentScore;
        PlayerPrefs.SetFloat("highscore", currentScore);
    }

    //Created by Josh Shinnick.
}
