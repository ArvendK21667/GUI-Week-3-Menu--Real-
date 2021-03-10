using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = playerCam.transform.rotation;              //Sets the rotation to match the camera so it's always "facing"t he camera
        
        //transform.LookAt(playerCam.transform.position);               //This will in theory do the same thing, but it will give the effect of the UI "turning"
                                                                        //If it gets close to the corners of the screen. Try it and see.
    }
}
