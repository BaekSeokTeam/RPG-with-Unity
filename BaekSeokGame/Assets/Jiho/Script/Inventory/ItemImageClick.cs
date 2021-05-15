using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemImageClick : MonoBehaviour
{

    public InventoryController inventory;

    public void Clicked()
    {
        inventory.GetComponent<ItemViewer>().makeView(transform.parent.GetComponent<ItemSlot>().item);
    }
  
}
