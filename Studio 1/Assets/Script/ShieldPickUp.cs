using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    public bool shield = false;
    public bool invulnerable = false;
    public SpriteRenderer sR;
    GameObject player;

    public AudioSource powerupSource;
    public AudioClip powerupClip;


    private void Start()
    {
        powerupSource.clip = powerupClip;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Shield"))
        {
            powerupSource.PlayOneShot(powerupClip);
            player = collider.gameObject;
            shield = true;
            sR.color = Color.blue;
            //gives player shield power up
            Destroy(collider.gameObject);
            //destroys power up
        }
    }

    private void Update()
    {
        
    }



}
