
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ClockOut : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI clockOutText;


    private bool clockOutAllowed;

    // Start is called before the first frame update
    private void Start()
    {
        clockOutText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    private void Update()
    {
    if ((clockOutAllowed = true) && (Input.GetKeyDown(KeyCode.E)))
        ClockOutOfWork();
    }

    
         void OnCollisionStay(Collision other)
        {
             if (other.gameObject.name == "Player Controller");

        {
            clockOutText.gameObject.SetActive(true);

        }
      
        }
    private void ClockOutOfWork()
{
       SceneManager.LoadScene("WinScreen");
}
}
