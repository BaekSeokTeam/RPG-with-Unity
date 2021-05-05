using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    // Start is called before the first frame update
    public class ExitButton : MonoBehaviour, IPointerDownHandler
    {


        public GameObject obj;


        public void OnPointerDown(PointerEventData data)
        {

            obj.SetActive(false);
        }
        public void OnPointerUp(PointerEventData data)
        {

        }


    }

