using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{






    public void OnPointerDown(PointerEventData data)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().saveData();

    }
    public void OnPointerUp(PointerEventData data)
    {

    }

}