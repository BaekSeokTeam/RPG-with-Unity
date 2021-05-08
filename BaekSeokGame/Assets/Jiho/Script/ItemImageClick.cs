using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemImageClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public InventoryController inventory;


    public void OnPointerDown(PointerEventData data)
    {


        inventory.GetComponent<ItemViewer>().makeView(transform.parent.GetComponent<ItemSlot>().item);

    }
    public void OnPointerUp(PointerEventData data)
    {

    }
}
