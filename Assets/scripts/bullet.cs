using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public int loseamount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        playerController PC = collision.collider.GetComponent<playerController>();
        if (PC != null)
        {
            PC.losesanity(loseamount);
            Destroy(gameObject);

        }
        else if (PC == null)
        {
            Destroy(gameObject);
        }
    }
}
