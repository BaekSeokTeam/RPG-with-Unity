using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PurchaseButton : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData data)
    {
        transform.parent.gameObject.GetComponent<PurchaseWindow>().Purchase();
  
    }
}
