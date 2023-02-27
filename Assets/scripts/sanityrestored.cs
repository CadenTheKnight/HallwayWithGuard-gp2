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
            
            PC.restoreSanity(restoreAmount);
            Destroy(gameObject);
            //PC.setCurrentItem(this);
        }
    }

}
