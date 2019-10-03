using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class camera : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraDisplacement;
    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();   
    }

    //fucntion for moving th camera
    void MoveCamera()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, 0, 0),
player.transform.position.y, player.transform.position.z) + cameraDisplacement;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

}
