using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public int id;
    public bool resetPostion = false;
    public bool doNothing = false;    
    

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("item drop");
        if (eventData.pointerDrag!=null)
        {

            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id==id)
            {
                eventData.pointerDrag.GetComponent<PointsAction>().Addpoint();

                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("ok");


            }
           
            else
            {


                if (doNothing)
                {
                    //Debug.Log("nic");
                }
                else if (resetPostion==true)
                {
                    //Debug.Log("Totalnie Ÿle");
                    eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition();
                }
                else
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                    //Debug.Log("NOT ok");                    

                }

                eventData.pointerDrag.GetComponent<PointsAction>().RemovePoint();
                
            }
            

        }

      
        

    }


}
