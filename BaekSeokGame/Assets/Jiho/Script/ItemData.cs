using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    // Start is called before the first frame update

    public string itemName;
    public string itemDescription;
    public int itemCount;
    public ItemType itemType;
    public enum ItemType
    {
        EQUIP,
        USE,
        MATERIAL,
        IMPORTANT
    }


}
