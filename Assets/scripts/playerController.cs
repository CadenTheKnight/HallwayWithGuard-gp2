using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
    public float speed = 6f;
    public CharacterController controller;
    public Rigidbody playerBody;


    void Start()
    {
        
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
}
