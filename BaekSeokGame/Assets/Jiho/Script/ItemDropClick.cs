using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropClick : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    public ItemViewer viewConroller;
    public void OnPointerDown(PointerEventData data)
    {
        viewConroller.removeItem();
        
    }
}
