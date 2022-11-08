using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{


    public static int scoreV;
    public static int scoreMax;
    public static bool MaxScore;
    static Text score;


    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        //score.text = "Score: " + 0;
        
    }
    public static void PointChange()
    {
       
        score.text = "Score: " + scoreV + " / " + scoreMax;
        if (scoreMax==scoreV)
        {
            MaxScore = true;
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
