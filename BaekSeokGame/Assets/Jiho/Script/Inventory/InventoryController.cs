using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] UI;
    private static InventoryController instance = null;
    public GameObject[] slotParent;
    
    List<ItemSlot[]> slots;
    public static InventoryController Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public int activeId;
    void Awake()
    {
        if (null == instance)
        {

            instance = this;


            DontDestroyOnLoad(this.gameObject);
        }
        else
        {

            Destroy(this.gameObject);
        }

    }
    void Start()
    {
        
        activeId = 0;
        Debug.Log("inven");
        
        UI[0].SetActive(true);
        slots = new List<ItemSlot[]>();

        
        slots.Add(slotParent[activeId].GetComponentsInChildren<ItemSlot>());
        for (int i = 1; i < UI.Length; i++)
        {
            
            UI[i].SetActive(false);
            slots.Add(slotParent[i].GetComponentsInChildren<ItemSlot>());


        }
    

        showItems(activeId);
    }
    public void AddItem(Item item){

        for (int i = 0; i < InventoryData.Instance.items.Count; i++)
        {
            if (item.id == InventoryData.Instance.items[i].id)
            {
                InventoryData.Instance.items[i].itemCount++;
                return;
            }
        }


        InventoryData.Instance.items.Add(item);
        
        
    }
    public void RemoveItem(Item item,int count=1)
    {

        if (item == null)
        {
            return;
        }
        for (int i = 0; i < InventoryData.Instance.items.Count; i++)
        {
            if (item.id == InventoryData.Instance.items[i].id)
            {
                InventoryData.Instance.items[i].itemCount-=count;
                if (InventoryData.Instance.items[i].itemCount == 0)
                {
                    InventoryData.Instance.items.RemoveAt(i);
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
        for (int i = 0; i < InventoryData.Instance.items.Count; i++)
        {
            
           
            if (id== (int)InventoryData.Instance.items[i].itemType)
            {
                
                temp.Add(InventoryData.Instance.items[i]);
               
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
