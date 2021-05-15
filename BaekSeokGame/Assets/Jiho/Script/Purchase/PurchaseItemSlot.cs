using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PurchaseItemSlot : ItemSlot, IPointerDownHandler
{
    public new Text name;
    public Text price;
    public PurchaseWindow window;
    public InventoryController inventory;

    public new void AddItem(Item _item)
    {
        
        item = _item;
        icon.sprite = _item.icon;
        name.text = _item.itemName;
        price.text = _item.purchasePrice.ToString();
       
    }
    public void OnPointerDown(PointerEventData data)
    {

        window.Show(item);
        window.transform.gameObject.SetActive(true);
    }
}
