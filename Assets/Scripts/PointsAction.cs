using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAction : MonoBehaviour
{
    public int point = 0;
    private int pointV = 0;
    
 
    public void Addpoint()
    {
        //Debug.Log("dodanie punktu");

        point = 1;
        Debug.Log(point);
        if (point == 1 && pointV == 0)
        {

            Score.scoreV += 1;
            pointV = 1;
            Debug.Log(Score.scoreV);
            ShowMe.check = true;
        }
        Score.PointChange();

        
       
    }

    public void RemovePoint()
    {
        //Debug.Log("zabranie punktu");
        point = 0;
        if (point == 0 && pointV == 1)
        {
            Score.scoreV += -1;
            pointV = 0;
            ShowMe.check = true;
        }
        
        Score.PointChange();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {


        ShowMe.check = true;
    }

    // Update is called once per frame
    void Update()
    {
        


     

    }
}
