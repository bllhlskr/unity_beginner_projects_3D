using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoad : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LevelLoad", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LevelLoad()
    {
        SceneManager.LoadScene(1);
        

    }
}
