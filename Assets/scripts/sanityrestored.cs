using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanityrestored : MonoBehaviour
{
    private playerController PC;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("player");
        if (PlayerObject != null)
        {
            PC = PlayerObject.GetComponent<playerController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (PC != null)
        {
            PC.sanityrestored();
            Destroy(gameObject);
        }
    }
}
