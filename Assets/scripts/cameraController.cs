using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform playerPosition;

    public float mouseSensitivity = 2.0f;
    float cameraVerticalRotation = 0;
    public bool paused = false;
    //bool lockedCursor = true;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(!paused){
            float inputX = Input.GetAxis("Camera X")*mouseSensitivity;
            float inputY = Input.GetAxis("Camera Y")*mouseSensitivity;

            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

            playerPosition.Rotate(Vector3.up*inputX);
        }

    }
}
