using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    public bool shield = false;
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collision with power up");
        if (collider.gameObject.CompareTag("Shield"))
        {
            Debug.Log("collision with player");
            player = collider.gameObject;
            shield = true;
            Debug.Log("You received a shield!");
            //gives player shield power up
            Destroy(gameObject);
            //destroys power up
        }
    }
}
