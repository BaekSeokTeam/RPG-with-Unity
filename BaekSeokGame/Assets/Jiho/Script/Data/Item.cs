using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    // Start is called before the first frame update
    
    public string itemName;
    public string itemDescription;
    public int itemCount;
    public ItemType itemType;
    public Sprite icon;
    public int id;
    public int purchasePrice;
    public int salePrice;
    public enum ItemType
    {
        EQUIP=0,
        USE=1,
        MATERIAL=2,
        IMPORTANT=3
    }
    ItemType GetType(int num)
    {
        if (num == 1)
        {
            return ItemType.EQUIP;
        }
        if (num == 2)
        {
            return ItemType.USE;
        }
        if (num == 3)
        {
            return ItemType.MATERIAL;
        }
        else
        {
            return ItemType.IMPORTANT;
        }
        
    }
    public Item(MyItemData item, int itemCount = 1)
    {
        this.id = item.id;
        this.itemName = item.name;
        this.itemDescription = item.description;
        this.itemCount = itemCount;
        this.itemType = GetType(item.itemType);
        this.icon = Resources.Load("ItemIcon/" + id, typeof(Sprite)) as Sprite;
        this.salePrice = item.salePrice;
        this.purchasePrice = item.purchasePrice;

    }


}
