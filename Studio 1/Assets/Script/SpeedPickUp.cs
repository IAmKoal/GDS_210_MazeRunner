using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    ArtificialGravity aG;
    GameObject player;

    AudioSource powerupSource;
    public AudioClip powerupClip;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player = collider.gameObject;
            Transform audioHolder= player.transform.GetChild(1);
            Transform pickup = audioHolder.GetChild(3);
            powerupSource = pickup.gameObject.GetComponent<AudioSource>();
            powerupSource.clip = powerupClip;
            powerupSource.PlayOneShot(powerupClip);
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

