using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeAcrion : MonoBehaviour
{
    [SerializeField] public Can[] canv;
    public int x = 0;
    [Serializable]
    public class Can
    {
        public GameObject canva;
        public GameObject eventCanvas;
        public bool acces;

    }

    public int UnlockedLevels = 1;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.MaxScore)
        {
            UnlockCanvas();
            Score.MaxScore = false;
        }
    }

    public void NextImage()
    {
       


        if (canv.Length>x+1 && canv[x + 1].acces)
        {
            var items = canv[x].eventCanvas.GetComponent<ShowMe>().info;
            foreach (var item in items)
            {
                item.piece.GetComponent<PointsAction>().RemovePoint();
                item.piece.GetComponent<DragAndDrop>().ResetPosition();

            }
            canv[x].canva.SetActive(false);
            x++;

            canv[x].canva.SetActive(true);
            Score.scoreMax = canv[x].eventCanvas.GetComponent<ShowMe>().info.Length;
            
            Score.PointChange();
            var y = canv[x].eventCanvas.GetComponent<ShowMe>().info;
            foreach (var item in y)
            {
                item.piece.GetComponent<DragAndDrop>().StartAction();
            }
        }

    }

    public void PreviousImage()
    {
        if (x>0)
        {
            var items = canv[x].eventCanvas.GetComponent<ShowMe>().info;
            foreach (var item in items)
            {
                item.piece.GetComponent<PointsAction>().RemovePoint();
                item.piece.GetComponent<DragAndDrop>().ResetPosition();

            }
            canv[x].canva.SetActive(false);
            x--;

            canv[x].canva.SetActive(true);
            Score.scoreMax = canv[x].eventCanvas.GetComponent<ShowMe>().info.Length;
            
            Score.PointChange();
            var y = canv[x].eventCanvas.GetComponent<ShowMe>().info;
            foreach (var item in y)
            {
                item.piece.GetComponent<DragAndDrop>().StartAction();
            }

        }
    }

    public void ChangeCanvas()
    {
        


        var items = canv[x].eventCanvas.GetComponent<ShowMe>().info;
        foreach (var item in items)
        {
            item.piece.GetComponent<PointsAction>().RemovePoint();
            item.piece.GetComponent<DragAndDrop>().ResetPosition();
           
        }
        canv[x].canva.SetActive(false);


        if (x==canv.Length-1 || !canv[x+1].acces )
        {
            x = 0;
        }
        else
        {
            x++;
        }

        canv[x].canva.SetActive(true);
        Score.scoreMax = canv[x].eventCanvas.GetComponent<ShowMe>().info.Length;
        Debug.Log("podaj Max Punkty" + canv[x].eventCanvas.GetComponent<ShowMe>().info.Length);
        Score.PointChange();
        var y = canv[x].eventCanvas.GetComponent<ShowMe>().info;
        foreach (var item in y)
        {
            item.piece.GetComponent<DragAndDrop>().StartAction();
        }
    }

    public  void UnlockCanvas()
    {
        int progresik = 0;
        Debug.Log(canv.Length);
        Debug.Log(x);
        Debug.Log("unlock next");
        if (canv.Length>x+1)
        {
            

            canv[x + 1].acces = true;
        }

        foreach (var item in canv[x].eventCanvas.GetComponent<ShowMe>().info)
        {
            item.pointsRe = 0;
        }


        foreach (var item in canv)
        {            
            if (item.acces)
            {
                progresik++;
            }
        }
        UnlockedLevels = progresik;
       
    }

}
