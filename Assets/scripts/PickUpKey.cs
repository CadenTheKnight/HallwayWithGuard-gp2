using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpKey : MonoBehaviour
{
    public GameObject hinge;
    public  GameObject pickUpKey;
    public TextMeshProUGUI pickupKeyText;

    void OnTriggerStay(Collider other) 
    {
        pickupKeyText.gameObject.SetActive(true);

        if(Input.GetButtonDown("Interact")) {
            Debug.Log("Key Picked up");
            //hinge.GetComponent<Animator>().SetTrigger("OpenDoor");
            pickupKeyText.gameObject.SetActive(false);
            hinge.SetActive(false);
            pickUpKey.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other){
        pickupKeyText.gameObject.SetActive(false);
    }
}
