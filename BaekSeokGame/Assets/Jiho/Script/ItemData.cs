using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ObjectData
{
    // Start is called before the first frame update
    
    public string itemName;
    public string itemDescription;
    public int itemCount;
    public ItemType itemType;
    public Sprite icon;
    public enum ItemType
    {
        EQUIP=0,
        USE=1,
        MATERIAL=2,
        IMPORTANT=3
    }

    public ItemData(int id,string itemName, string itemDescription,ItemType itemType, int itemCount = 1)
    {
        this.id = id;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemCount = itemCount;
        this.itemType = itemType;
        this.icon = Resources.Load("ItemIcon/" + itemName, typeof(Sprite)) as Sprite;

    }


}
