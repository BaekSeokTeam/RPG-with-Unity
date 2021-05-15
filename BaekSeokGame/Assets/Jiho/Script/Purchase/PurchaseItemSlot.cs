using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseItemSlot : ItemSlot
{
    public new Text name;
    public Text price;

    public new void AddItem(Item _item)
    {
        
        item = _item;
        icon.sprite = _item.icon;
        name.text = _item.itemName;
        price.text = _item.purchasePrice.ToString();
       
    }
}
