using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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




    void Start()
    {
        //gameCamera = Camera.current;
        sanity = startingSanity;
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            ThrowPunch();
        }
        timer -= Time.deltaTime;
        if(timer <= 0){
            timer = 1;
            sanity--;
        }
        sanityText.text = "Sanity: " + sanity;
    }

    //pick up for sanity
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SanityPickUp") ;
        {
            sanity += 10;
            Destroy(other.gameObject);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * movementX + transform.forward * movementZ;
        //Vector3 move = new Vector3(movementX, 0, movementZ);

        playerBody.velocity = (move * speed * Time.deltaTime * 100);
        //controller.Move = (move * speed * Time.deltaTime);
        //playerBody.AddForce(move * speed * Time.deltaTime);
    }

    void ThrowPunch(){
        RaycastHit raycastHit;
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out raycastHit, punchRange)){
            LandPunch(raycastHit.transform.gameObject, ray);
        }
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
