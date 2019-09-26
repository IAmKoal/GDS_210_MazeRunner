using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    int gravOnEnter;
    ArtificialGravity aG;
    GameObject player;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player = collider.gameObject;
            //saves player gavity on entry
            aG = player.GetComponent<ArtificialGravity>();
            gravOnEnter = aG.gravityStrength;
            //gives player gravity increase
            aG.gravityStrength = (int)(aG.gravityStrength * 1.5f);
        }
        else { }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player = collider.gameObject;
            aG = player.GetComponent<ArtificialGravity>();
            //reset gravity of player
            aG.gravityStrength = gravOnEnter;
        }
        else { }
    }
}