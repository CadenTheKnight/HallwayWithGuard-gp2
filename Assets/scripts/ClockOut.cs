
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ClockOut : MonoBehaviour
{
    
    public TextMeshProUGUI clockOutText;

    // Start is called before the first frame update
     void Start()
      {
        clockOutText.gameObject.SetActive(false);
      }

    //manages the on trigger enter for the clock out function
    void OnTriggerStay(Collider mcguffin)
    {
        playerController player = mcguffin.GetComponent<playerController>();
        if (player != null) 
        {
            clockOutText.gameObject.SetActive(true);
            player.CanClockOut = true;
      
        }
    }

    void OnTriggerExit(Collider mcguffin) {
        playerController player = mcguffin.GetComponent<playerController>();
        clockOutText.gameObject.SetActive(false);
        player.CanClockOut = false;

    }

}


