using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    // Start is called before the first frame update
    Item selectedItem;
    public Text itemName;
    public Text itemDescription;
    public Image itemIcon;
    public void makeView(Item item)
    {
        selectedItem = item;
        itemName.text = selectedItem.itemName;
        itemDescription.text = selectedItem.itemDescription;
        itemIcon.sprite = selectedItem.icon;
        itemIcon.transform.gameObject.SetActive(true);
    }
    public void makeVoid()
    {
        selectedItem = null;
        itemName.text = "";
        itemDescription.text = "";
        itemIcon.sprite = null;
        itemIcon.transform.gameObject.SetActive(false);
    }
    public void removeItem()
    {
        InventoryController inven = transform.GetComponent<InventoryController>();
        inven.RemoveItem(selectedItem);
        inven.showItems(inven.activeId);
        makeVoid();
    }
}
