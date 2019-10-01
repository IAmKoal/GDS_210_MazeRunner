using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Singleton : MonoBehaviour
{
    public int score = 0;
    public int hiScore = 0;
    public bool isTilted = false;
    public bool isSlidered = true;
    public bool isTouched = false;

    public static Singleton Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
  
    }
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("highscore") > 0)
        {
            hiScore = PlayerPrefs.GetInt("highscore");
        }
        else if (PlayerPrefs.GetInt("highscore") > hiScore)
        {
            PlayerPrefs.SetInt("highscore", hiScore);
        }
    }
}
 
