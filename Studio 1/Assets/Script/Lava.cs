using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    ShieldPickUp sC;
    GameObject player;
    public SpriteRenderer sR;

    private void Start()
    {
        player = gameObject;
        sC = player.GetComponent<ShieldPickUp>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Lava") && sC.shield == false && !sC.invulnerable)
        {
            Debug.Log("You died! Try again");
            SceneManager.LoadScene(0);
            //load death/restart scene
        }

        if (collider.gameObject.CompareTag("Lava") && sC.shield == true && !sC.invulnerable)
        {
            sR.color = Color.cyan;
            Debug.Log("Good thing you had a shield");
            StartCoroutine(Invulnerability());
            sC.shield = false;
            sC.invulnerable = true;
            //waits specified amount of time and removes players sheild power up
            Debug.Log("You have used your shield");
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
}
