using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


    public GameObject menuController;



    public void OnPointerDown(PointerEventData data)
    {
        int id = int.Parse(this.gameObject.name);

        menuController.GetComponent<UIController>().changeMenu(id);

    }
    public void OnPointerUp(PointerEventData data)
    {

    }

}