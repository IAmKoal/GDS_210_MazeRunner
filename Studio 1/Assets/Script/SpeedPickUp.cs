using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    ArtificialGravity aG;
    GameObject player;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision with player");
            player = collider.gameObject;
            //gives player instant speed boost
            Vector2 playerVel = player.GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().velocity = playerVel * 1.5f;
            //gives player gravity increase
            aG = player.GetComponent<ArtificialGravity>();
            aG.gravityStrength = (int)(aG.gravityStrength * 1.1f);
            //destorys self
            Destroy(gameObject);
        }
        else { }
    }
}

