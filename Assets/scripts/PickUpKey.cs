using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpKey : MonoBehaviour
{
    public Component doorColliderHere;
    public  GameObject pickUpKey;


    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other) 
    {
        if(Input.GetButtonDown("Interact"))
        doorColliderHere.GetComponent<BoxCollider> ().enabled = true;
        pickUpKey.SetActive (false);
    }
}
