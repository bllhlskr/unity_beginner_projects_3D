using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisisonHandler : MonoBehaviour
{
    [Tooltip ("Particle effect")] [SerializeField] GameObject deathVFX;
    [SerializeField] float levelLoadDelay= 1f;
    int currentIndex;
     void Start()
    {
         currentIndex = SceneManager.GetActiveScene().buildIndex;   
    }
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathVFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }
    private void StartDeathSequence()
    {
        print("player is dying");
        SendMessage("OnPlayerDeath");
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(currentIndex);
    }
}
