using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{ 
    
    int score;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ScoreHit(int scoreperHit)
    {
        score += scoreperHit;
        text.text = score.ToString();

    }
}
