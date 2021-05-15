using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] UI;

    public GameObject[] slotParent;
    List<Item> itemList;
    List<ItemSlot[]> slots;
    public int activeId;
    public Database db;
    void Start()
    {
        
        activeId = 0;
        Debug.Log("inven");
        
        UI[0].SetActive(true);
        slots = new List<ItemSlot[]>();

        itemList = new List<Item>();
        slots.Add(slotParent[activeId].GetComponentsInChildren<ItemSlot>());
        for (int i = 1; i < UI.Length; i++)
        {
            
            UI[i].SetActive(false);
            slots.Add(slotParent[i].GetComponentsInChildren<ItemSlot>());


        }
        for (int i = 0; i < db.itemList.Count; i++)
        {
            
            
            AddItem(db.itemList[i]);
        }

        showItems(activeId);
    }
    public void AddItem(Item item){

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
    public void RemoveItem(Item item,int count=1)
    {

        if (item == null)
        {
            return;
        }
        for (int i = 0; i < itemList.Count; i++)
        {
            if (item.id == itemList[i].id)
            {
                itemList[i].itemCount-=count;
                if (itemList[i].itemCount == 0)
                {
                    itemList.RemoveAt(i);
                }
                return;
               
            }
        }


       


    }
    void renewSlots(int id)
    {
        for(int i = 0; i < slots[id].Length; i++)
        {
            slots[id][i].RemoveItem();
        }
    }
    public void showItems(int id)  
    {
        renewSlots(id);
        List<Item> temp = new List<Item>();
        for (int i = 0; i < itemList.Count; i++)
        {
            
           
            if (id== (int)itemList[i].itemType)
            {
                
                temp.Add(itemList[i]);
               
            }
        }
        for (int i = 0; i < temp.Count; i++)
        {
           

            slots[id][i].AddItem(temp[i]);
            slots[id][i].transform.Find("Image").gameObject.SetActive(true);
            
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
                activeId = id;
                UI[i].SetActive(true);
                UI[i].transform.Find("Scrollbar Vertical").gameObject.GetComponent<Scrollbar>().value = 1;
                showItems(i);

            }
        }
    }
}
