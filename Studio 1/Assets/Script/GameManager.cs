﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public List<GameObject> wallSections;
    public List<GameObject> activeSections;
    public Transform sectionSpawn;

   

    // Start is called before the first frame update
    void Start()
    {
  
        Vector3 firstSpawn = new Vector3(sectionSpawn.position.x -2, sectionSpawn.position.y - 10, sectionSpawn.position.z);
        GameObject sect = Instantiate(wallSections[1], firstSpawn, Quaternion.identity) as GameObject;
        activeSections.Add(sect.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "death")
        {
            if(Singleton.Instance.score > Singleton.Instance.hiScore)
            {
                Singleton.Instance.hiScore = Singleton.Instance.score;
            }
            SceneManager.LoadScene(0);
        }
        if (other.gameObject.tag == "shieldPwr")
        {
            //sheild stuff
        }
        if (other.gameObject.tag == "speedPwr")
        {
            //speed stuff
        }
        if (other.gameObject.tag == "healthPwr")
        {
            //health stuff
        }
        if (other.gameObject.tag == "speedUp")
        {
            //speed up
        }
    }
   private void OnTriggerExit2D(Collider2D other)
   {
        if (other.gameObject.tag == "startLine")
        {
            if (activeSections.Count != 0)
            {
                Transform prevSect = activeSections[activeSections.Count - 1].transform;
                Vector3 newSpawn = new Vector3(prevSect.position.x  , prevSect.position.y -19, prevSect.position.z);

                GameObject newSect = Instantiate(wallSections[Random.Range(1, 5)], newSpawn, Quaternion.identity) as GameObject;
                activeSections.Add(newSect.gameObject);
            
            }
        }
        if (other.gameObject.tag == "endLine")
        {
            if (activeSections.Count !=0)
            {
                Destroy(activeSections[activeSections.Count - 2]);
               // activeSections.RemoveAt(activeSections.Count - 1);
               // activeSections.Remove(;
            }
            Singleton.Instance.score += 100;
        }
      
    }
}
