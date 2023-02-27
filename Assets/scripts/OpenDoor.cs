using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenDoor : MonoBehaviour
{
    //public Animation hingeHere;

    void OnTriggerEnter(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E)){
            //hingeHere.Play();
        }
    }
}
