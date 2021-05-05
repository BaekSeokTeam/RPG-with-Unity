using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] UI;

    void Awake()
    {
        UI[0].SetActive(true);
        for (int i = 1; i < UI.Length; i++)
        {
            
                UI[i].SetActive(false);
          
           
        }
    }

    // Update is called once per frame
    public void changeMenu(int id)
    {
        for(int i = 0; i < UI.Length; i++)
        {
            if (id != i)
            {
                UI[i].SetActive(false);
            }
            else
            {
                UI[i].SetActive(true);
            }
        }
    }
}
