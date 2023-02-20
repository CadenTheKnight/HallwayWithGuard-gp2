using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sanityrestored : MonoBehaviour
{
    private playerController PC;

    public int restoreAmount = 10;
    //public TextMeshPro stealItemText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("player");
        //stealItemText = GameObject.Find("pickupItemText");
        if (PlayerObject != null)
        {
            PC = PlayerObject.GetComponent<playerController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (PC != null)
        {
            PC.canPickupItem = true;
            PC.restoreSanity(restoreAmount);
            Destroy(this);
            //PC.setCurrentItem(this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (PC != null)
        {
            PC.canPickupItem = false;
            //stealItemText.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
