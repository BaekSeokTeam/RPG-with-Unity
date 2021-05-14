using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseController : MonoBehaviour
{
    List<ItemData> itemList;
    public GameObject slotParent;
    PurchaseItemSlot[] slots;
    public Database db;
    void Start()
    {

        itemList = new List<ItemData>();       
        slots = slotParent.GetComponentsInChildren<PurchaseItemSlot>();
        Debug.Log(db.itemList.Count);
        for (int i = 0; i < db.itemList.Count; i++)
        {

            if (db.itemList[i].itemType == ItemData.ItemType.EQUIP)
            {
                itemList.Add(db.itemList[i]);
            }
        }
        showItems();


    }
    public void showItems()
    {
        
   
        for (int i = 0; i < itemList.Count; i++)
        {

            
            slots[i].AddItem(itemList[i]);
            slots[i].transform.Find("Icon").gameObject.transform.Find("Image").gameObject.SetActive(true);

        }
    }
    
}
