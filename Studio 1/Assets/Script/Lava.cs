using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Lava : MonoBehaviour
{
    ShieldPickUp sC;
    GameObject player;
    public SpriteRenderer sR;
    public AudioSource deathSource;
    public  AudioClip deathClip;
    public bool isPlaying;
   

    private void Start()
    {
        player = gameObject;
        sC = player.GetComponent<ShieldPickUp>();
        deathSource.clip = deathClip;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Lava") && sC.shield == false && !sC.invulnerable)
        {
            deathSource.PlayOneShot(deathClip);
            sR.color = Color.red;
           
            StartCoroutine("WaitTime");
            // Debug.Log("You died! Try again");
         
          
            //load death/restart scene
        }

        if (collider.gameObject.CompareTag("Lava") && sC.shield == true && !sC.invulnerable)
        {
            sR.color = Color.cyan;
           // Debug.Log("Good thing you had a shield");
            StartCoroutine(Invulnerability());
            sC.shield = false;
            sC.invulnerable = true;
            //waits specified amount of time and removes players sheild power up
           // Debug.Log("You have used your shield");
        }
    }

    IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(1);
        sC.invulnerable = false;
        if (sC.shield == true)
        {
            sR.color = Color.blue; 
        }
        else
        {
            sR.color = Color.white;
        }
    }

    IEnumerator WaitTime()
    {
        Singleton.Instance.isDead = true;
        yield return new WaitForSeconds(2);
      
        SceneManager.LoadScene(0);

    }
}
