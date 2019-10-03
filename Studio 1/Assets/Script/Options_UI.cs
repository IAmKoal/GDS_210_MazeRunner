using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options_UI : MonoBehaviour
{
    public int controls = 0;
    public AudioMixer GameMixer;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider effectVolumeSlider;
    public Text masterPerText;
    public Text musicPerText;
    public Text effectPerText;


    // Start is called before the first frame update

    private void Awake()
    {
        //masterVolumeSlider.value = Singleton.Instance.masterVol;
    }

    void ControlSwitch(int controls)
    {
        switch (controls)
        {
            case 0: //tilt case (accelerometer)
                Singleton.Instance.isTilted = true;
                Singleton.Instance.isSlidered = false;
                break;
            case 1: //Slider case
                Singleton.Instance.isTilted = false;
                Singleton.Instance.isSlidered = true;
                break;
            default:
                Singleton.Instance.isTilted = true;
                Singleton.Instance.isSlidered = false;
                break;
        }
    }
  
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume",1);
        masterPerText.text = Mathf.RoundToInt(masterVolumeSlider.value * 100) + "%";
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
        musicPerText.text = Mathf.RoundToInt(musicVolumeSlider.value * 100) + "%";
        effectVolumeSlider.value = PlayerPrefs.GetFloat("soundEffectVolume", 1);
        effectPerText.text = Mathf.RoundToInt(effectVolumeSlider.value * 100) + "%";

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
        //masterVolumeSlider.value = Singleton.Instance.masterVol;
    }
    public void SetMasterVolume(float vol)
    {
        GameMixer.SetFloat("masterVolume", Mathf.Log10( vol) * 20);
        PlayerPrefs.SetFloat("masterVolume", vol);
        masterPerText.text = Mathf.RoundToInt(vol * 100) + "%";
       
    }
    public void SetMusicVolume(float vol)
    {
        GameMixer.SetFloat("musicVolume", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("musicVolume", vol);
        musicPerText.text = Mathf.RoundToInt(vol * 100) + "%";
    }
    public void SetEffectVolume(float vol)
    {
        GameMixer.SetFloat("soundEffectVolume", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("soundEffectVolume", vol);
        effectPerText.text = Mathf.RoundToInt(vol * 70) + "%";
    }
}

