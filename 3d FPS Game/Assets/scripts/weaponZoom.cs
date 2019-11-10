using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class weaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] float zoomedIn = 20f;
    RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomInSensitivity = 5f;
    [SerializeField] float zoomOutSensitivity = 2f;
    // Start is called before the first frame update
    void Start()
    {
        fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
       
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(1))
            {
                fpsCamera.fieldOfView = zoomedIn;
                fpsController.mouseLook.XSensitivity = zoomInSensitivity;
                fpsController.mouseLook.YSensitivity = zoomInSensitivity;

            FindObjectOfType<handleWeapons>().Flag = false;
            }
            if (Input.GetMouseButtonUp(1))
            {
                fpsCamera.fieldOfView = zoomedOut;
                fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
                fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
            FindObjectOfType<handleWeapons>().Flag = true;

        }



    }
}
