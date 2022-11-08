using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

   
    private RectTransform rectTrans;
    public Canvas myCanvans;
    private CanvasGroup canvasGroup;
    public int id;
    public Vector3 initPos;
    private Vector3 scale;

    public void StartAction()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initPos = transform.position;
    }
    
    void Start()
    {

        StartAction();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       // Debug.Log("StartDrag");
        canvasGroup.blocksRaycasts = false;

        scale = transform.localScale;
        scale.x = (float)(scale.x * 0.8);
        scale.y = (float)(scale.y * 0.8);
        transform.localScale = scale;
        
        //eventData.pointerDrag.GetComponent<PointsAction>().point = 0;

        

    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("Draging");

        rectTrans.anchoredPosition += eventData.delta / myCanvans.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //  Debug.Log("EndDrag");
        ToNormal();

        
       
    }

    public void ToNormal()
    {
        canvasGroup.blocksRaycasts = true;
        scale.x = 1;
        scale.y = 1;
        transform.localScale = scale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      //  Debug.Log("CLICK");
    }

    public void ResetPosition()
    {
        transform.position = initPos;
        
    }


    public void Update()
    {
        




    }

    



}
