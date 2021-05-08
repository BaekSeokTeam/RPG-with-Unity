using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text itemName;
    public Text itemDescription;
    public Image itemIcon;
    public void makeView(ItemData item)
    {
        itemName.text = item.itemName;
        itemDescription.text = item.itemDescription;
        itemIcon.sprite = item.icon;
        itemIcon.transform.gameObject.SetActive(true);
    }
    public void makeVoid()
    {
        itemName.text = "";
        itemDescription.text = "";
        itemIcon.sprite = null;
        itemIcon.transform.gameObject.SetActive(false);
    }
}
