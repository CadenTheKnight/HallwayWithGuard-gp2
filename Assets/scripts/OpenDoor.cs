using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenDoor : MonoBehaviour


{
    public Animation hingeHere;


    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
     void OnTriggerEnter(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        hingeHere.Play ();
    }
}
