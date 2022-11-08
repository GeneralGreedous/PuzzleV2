using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class ShowMe : MonoBehaviour
{


    public static bool check;
    [Serializable]
    public class Requi
    {
        public GameObject piece;
        public int pointsRe;
        public static bool show=true;
        
    }

    [SerializeField] public Requi[] info;


    // Start is called before the first frame update
    void Start()
    {
        
        Score.scoreMax = info.Length;

}

    public void ResetAll()
    {
        foreach (var item in info)
        {
            item.piece.GetComponent<PointsAction>().RemovePoint();
            item.piece.GetComponent<DragAndDrop>().ResetPosition();
        }
    }
    public void DoShow()
    {
        Debug.Log("DoShow");
        foreach (var item in info)
        {
            if (item.pointsRe <= Score.scoreV)
            {
                item.piece.SetActive(true);
            }
            else
            {
                item.piece.GetComponent<PointsAction>().RemovePoint();
                item.piece.GetComponent<DragAndDrop>().ResetPosition();
                item.piece.SetActive(false);

            }


        }
    }

    

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            DoShow();
            check = false;
        }


        
    }

}

