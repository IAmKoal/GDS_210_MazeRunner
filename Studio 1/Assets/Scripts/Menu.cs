using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Scene mainGame, pauseGame;
    public void StartPress()
    {
        SceneManager.LoadScene("Main");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }
    public void PauseGame()
    {

    }

    //by Josh Shinnick.
}
