using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class camera : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraDisplacement;
    
    // Update is called once per frame
    void Update()
    {
        MoveCamera();   
    }

    //fucntion for moving th camera
    void MoveCamera()
    {
        transform.position = player.transform.position + cameraDisplacement;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

}
