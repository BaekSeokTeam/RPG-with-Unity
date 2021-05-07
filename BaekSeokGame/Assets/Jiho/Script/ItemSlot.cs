using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Image icon;
    public Text count;

    public void AddItem(ItemData _item)
    {
        Debug.Log("??000"); 
        icon.sprite = _item.icon;
        
        if (_item.itemType == ItemData.ItemType.USE)
        {
            if (_item.itemCount > 0)
            {
                count.text = _item.itemCount.ToString();
            }
        }
        else
        {
            count.text = "";
        }
    }
    public void RemoveItem()
    {
        icon.sprite = null;
        count.text = "";
    }
}
