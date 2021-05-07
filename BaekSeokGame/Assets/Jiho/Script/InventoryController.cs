using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] UI;

    public GameObject[] slotParent;
    List<ItemData> itemList;
    List<ItemSlot[]> slots;
    void Awake()
    {
        Database db = GameObject.Find("Database").GetComponent<Database>();
        UI[0].SetActive(true);
        slots = new List<ItemSlot[]>();

        itemList = new List<ItemData>();
        slots.Add(slotParent[0].GetComponentsInChildren<ItemSlot>());
        for (int i = 1; i < UI.Length; i++)
        {
            
            UI[i].SetActive(false);
            slots.Add(slotParent[i].GetComponentsInChildren<ItemSlot>());


        }
       
        
    }
    public void AddItem(ItemData item){

        for (int i = 0; i < itemList.Count; i++)
        {
            if (item.id == itemList[i].id)
            {
                itemList[i].itemCount++;
                return;
            }
        }


        itemList.Add(item);
        
        
    }

    void showItems(int id)  
    {
        List<ItemData> temp = new List<ItemData>();
        for (int i = 0; i < itemList.Count; i++)
        {
            Debug.Log(itemList[i].itemType);
           
            if (id== (int)itemList[i].itemType)
            {
                
                temp.Add(itemList[i]);
               
            }
        }
        for (int i = 0; i < temp.Count; i++)
        {
            Debug.Log(id);
            Debug.Log(i);

            slots[id][i].AddItem(temp[i]);
            
        }
    }
    // Update is called once per frame
    public void changeMenu(int id)
    {
        for (int i = 0; i < UI.Length; i++)
        {
            if (id != i)
            {
                UI[i].SetActive(false);
            }
            else
            {
                UI[i].SetActive(true);
                showItems(i);

            }
        }
    }
}
