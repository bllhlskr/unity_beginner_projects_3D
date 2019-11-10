using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas gunreticleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;

    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        gunreticleCanvas.enabled = false;
        Time.timeScale = 0;
        FindObjectOfType<handleWeapons>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
