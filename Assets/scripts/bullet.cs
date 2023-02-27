using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public int loseamount = 10;
    private playerController PC;
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("player");
        //stealItemText = GameObject.Find("pickupItemText");
        if (PlayerObject != null)
        {
            PC = PlayerObject.GetComponent<playerController>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PC != null)
        {

            PC.losesanity(loseamount);
            Destroy(gameObject);
            //PC.setCurrentItem(this);
        }
        else if (PC == null)
        {
            Destroy(gameObject);
        }
    }
}
