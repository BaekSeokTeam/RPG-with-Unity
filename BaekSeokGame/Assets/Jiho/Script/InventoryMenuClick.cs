using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryMenuClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject menuController;


    public void OnPointerDown(PointerEventData data)
    {
        int id = int.Parse(this.gameObject.name);

        menuController.GetComponent < InventoryController>().changeMenu(id);

    }
    public void OnPointerUp(PointerEventData data)
    {

    }
}
