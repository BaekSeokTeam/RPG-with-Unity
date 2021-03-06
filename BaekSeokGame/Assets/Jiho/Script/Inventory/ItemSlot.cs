using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Image icon;
    public Text count;
    public Item item;
    

    public void AddItem(Item _item)
    {

        item = _item;
        icon.sprite = _item.icon;
        
        if (_item.itemType == Item.ItemType.USE)
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
    public void RemoveItem(Item _item,int _count=1)
    {

        _item.itemCount -= _count;
        if (_item.itemCount == 0)
        {
            item = null;
            transform.Find("Image").gameObject.SetActive(false);


        }
        if (_item.itemType == Item.ItemType.USE)
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
        item = null;
        icon.sprite = null;
        count.text = "";
        transform.Find("Image").gameObject.SetActive(false);
    }
}
