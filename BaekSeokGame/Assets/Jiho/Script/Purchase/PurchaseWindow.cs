using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseWindow : MonoBehaviour
{
    public Text name;
    public Text price;
    public Text description;
    public Image icon;
    public InventoryController inventory;
    Item item;
   public void Show(Item item)
    {
        this.item = item;
        name.text = item.itemName;
        price.text = item.purchasePrice.ToString();
        description.text = item.itemDescription;
        icon.sprite = item.icon;
    }
    public void Purchase()
    {
        inventory.AddItem(this.item);
        transform.gameObject.SetActive(false);
    }
}
