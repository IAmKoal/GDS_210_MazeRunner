using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options_UI : MonoBehaviour
{
    public int controls = 0;
    // Start is called before the first frame update
   
        void ControlSwitch(int controls)
    {
        switch (controls)
        {
            case 0: //tilt case (accelerometer)
                Singleton.Instance.isTilted = true;
                Singleton.Instance.isSlidered = false;
                Singleton.Instance.isTouched = false;
                break;
            case 1: //Slider case
                Singleton.Instance.isTilted = false;
                Singleton.Instance.isSlidered = true;
                Singleton.Instance.isTouched = false;
                break;
            case 2: //Touch case
                Singleton.Instance.isTilted = false;
                Singleton.Instance.isSlidered = false;
                Singleton.Instance.isTouched = true;
                break;
            default:
                Singleton.Instance.isTilted = true;
                Singleton.Instance.isSlidered = false;
                Singleton.Instance.isTouched = false;
                break;
        }
    }
  
    void Start()
    {
       
    }
    public void TiltButton()
    {
        ControlSwitch(0);
    }
    public void SliderButton()
    {
        ControlSwitch(1);
    }
    public void TouchButton()
    {
        ControlSwitch(2);
    }
    public void BackButton()
    {
       SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
