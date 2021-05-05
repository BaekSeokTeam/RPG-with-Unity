using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{

 
    public GameObject obj;
     

 
    public void OnPointerDown(PointerEventData data)
    {
        obj.SetActive(true);

    }
    public void OnPointerUp(PointerEventData data)
    {
     
    }

}
