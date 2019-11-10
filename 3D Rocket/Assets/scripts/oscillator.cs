using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f,10f,10f);
     float movementPercent;
    Vector3 startingPos;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period == Mathf.Epsilon) { return; }
        float cycles = Time.time / period;// grow with game time

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        
        movementPercent = (rawSinWave/2f)+ 0.5f ;
        Vector3 offset = movementVector * movementPercent;
        transform.position = startingPos + offset ;
        
    }
}
