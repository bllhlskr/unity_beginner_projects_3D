using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPLayer : MonoBehaviour
{
    

    private void Awake()
    {
       int numMusiPLayer =  FindObjectsOfType<MusicPLayer>().Length;
       if(numMusiPLayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
          
    }
   
}
