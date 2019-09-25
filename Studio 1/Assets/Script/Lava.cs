using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    ShieldPickUp sC;
    GameObject player;

    private void Start()
    {
        player = gameObject;
        sC = player.GetComponent<ShieldPickUp>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collision with Lava!");
        if (collider.gameObject.CompareTag("Lava") && sC.shield == false)
        {
            Debug.Log("You died! Try again");
            SceneManager.LoadScene(0);
            //load death/restart scene
        }

        if (collider.gameObject.CompareTag("Lava") && sC.shield == true)
        {
            Debug.Log("Good thing you had a shield");
            StartCoroutine(Invulnerability());
            //waits specified amount of time and removes players sheild power up
            Debug.Log("You have used your shield");
        }
    }

    IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(1);
        sC.shield = false;
    }
}
