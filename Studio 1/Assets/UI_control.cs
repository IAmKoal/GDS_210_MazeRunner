using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_control : MonoBehaviour

{
    public Text scoreText;
   
    // Start is called before the first frame update

    void Start()
    {
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        scoring.Instance.score = 0;
    }
    public void QuitButton()
    {
        Application.Quit();
    }


// Update is called once per frame
void Update()
    {
        scoreText.text = "Hi-Score: " + scoring.Instance.hiScore.ToString();
    }
}
