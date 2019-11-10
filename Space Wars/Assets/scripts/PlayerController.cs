using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("Ranges")]
    [SerializeField]  float XminRange = -5f;
    [SerializeField]float XmaxRange = 5f;
    [SerializeField] float YminRange = -5f;
    [SerializeField] float YmaxRange = 5f;
    float yThrow;
    float xThrow;
    [SerializeField] GameObject[] Guns;
    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;
    [Tooltip("in meters/second")] [SerializeField] float controlSpeed = 20f;

    bool isControlEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void OnPlayerDeath()// called by string reference
    {
        isControlEnabled = false;
        
    }
 
    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }
 private void ProcessTranslation()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawXPos, XminRange, XmaxRange);

         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawYPos, YminRange, YmaxRange);

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
    private void ProcessRotation()
    {

		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
		float pitchDueToControlThrow = yThrow * controlPitchFactor;
		float pitch = pitchDueToPosition + pitchDueToControlThrow;

		float yaw = transform.localPosition.x * positionYawFactor;

		float roll = xThrow * controlRollFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}
    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(false);
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(true);
        }
    }
}
