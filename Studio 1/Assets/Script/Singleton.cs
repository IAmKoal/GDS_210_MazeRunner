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
    public bool isSlidered = false;
    public bool isTouched = false;
    public bool isDead = false;
    
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
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            isTilted = true;
        }else if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            isSlidered = true;
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
       hiScore =  PlayerPrefs.GetInt("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
      PlayerPrefs.SetInt("highscore", hiScore);      
    }
}
 
