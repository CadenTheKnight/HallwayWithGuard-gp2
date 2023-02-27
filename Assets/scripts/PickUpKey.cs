using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpKey : MonoBehaviour
{
    public GameObject hinge;
    public  GameObject pickUpKey;

    void OnTriggerStay(Collider other) 
    {
        if(Input.GetButtonDown("Interact")) {
            Debug.Log("Key Picked up");
            //hinge.GetComponent<Animator>().SetTrigger("OpenDoor");
            hinge.SetActive(false);
            pickUpKey.SetActive(false);
        }
    }
}
