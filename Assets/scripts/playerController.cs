using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    
    public float speed = 6f;
    public float punchPower = 5f;
    public float punchRange = 3f;
    public int startingSanity = 100;
    public CharacterController controller;
    public Rigidbody playerBody;
    public Camera gameCamera;

    public AudioSource voicelineSource;
    public AudioClip voiceline1;
    public AudioClip voiceline2;
    public AudioClip voiceline3;
    public AudioClip voiceline4;
    public AudioClip voiceline5;

    public TextMeshProUGUI sanityText;

    private int enemiesPunched = 0;
    private int punchVoicelinesUsed = 0;

    private int sanity;
    private float timer = 1f;
    public bool CanClockOut;
    public bool canPickupItem;

    private GameObject currentItem;

    void Start()
    {
        //gameCamera = Camera.current;
        sanity = startingSanity;
        CanClockOut = false;
        canPickupItem = false;
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            ThrowPunch();
        }
        timer -= Time.deltaTime;
        if(timer <= 0){
            timer = 1;
            sanity--;
        }
        sanityText.text = "Sanity: " + sanity;
        if (sanity <= 0)
        {
             //GameOver();
                SceneManager.LoadScene("LoseScreen");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CanClockOut)
            {
                ClockOutOfWork();
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canPickupItem)
            {
                restoreSanity(10);
            }
        }*/

    if (Input.GetKeyDown(KeyCode.Escape))
     Debug.Log("Quit!");
    Application.Quit();
    }

    //pick up for sanity
    public void restoreSanity(int amt)
    {
        sanity += amt;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            Destroy(other.gameObject);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * movementX + transform.forward * movementZ;
        move.Normalize();
        //Vector3 move = new Vector3(movementX, 0, movementZ);

        playerBody.velocity = (move * speed * Time.deltaTime * 100);
        //controller.Move = (move * speed * Time.deltaTime);
        //playerBody.AddForce(move * speed);
    }

    void ThrowPunch(){
        RaycastHit raycastHit;
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out raycastHit, punchRange)){
            LandPunch(raycastHit.transform.gameObject, ray);
        }

    void LandPunch(GameObject o, Ray ray){
        if(o.tag == "enemy"){
            Debug.Log(o + " has been punched");
            o.GetComponent<Rigidbody>().AddForce(ray.direction * punchPower*100);
            //Debug.Log(ray.direction * punchPower);
            enemiesPunched++;


            //Manages which voiceline to play after punching
            if(!voicelineSource.isPlaying){
                switch(punchVoicelinesUsed+1){
                    case 1:
                    PlayAudio(voiceline1);
                    punchVoicelinesUsed++;
                    break;
                    case 2:
                    PlayAudio(voiceline2);
                    punchVoicelinesUsed++;
                    break;
                    case 3:
                    PlayAudio(voiceline3);
                    punchVoicelinesUsed++;
                    break;
                    case 4:
                    PlayAudio(voiceline4);
                    punchVoicelinesUsed++;
                    break;
                    case 5:
                    PlayAudio(voiceline5);
                    punchVoicelinesUsed++;
                    break;
                }
            }
        }
        if(o.tag == "punchable"){
            Debug.Log(o + " has been punched");
            o.GetComponent<Rigidbody>().AddForce(ray.direction * punchPower*1000);
        }
    }

    void PlayAudio(AudioClip clip){
        voicelineSource.PlayOneShot(clip);
    }
}
    // clockout
    public void ClockOutOfWork()
    {
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    public void setCurrentItem(GameObject item){
        currentItem = item;
    }
}

