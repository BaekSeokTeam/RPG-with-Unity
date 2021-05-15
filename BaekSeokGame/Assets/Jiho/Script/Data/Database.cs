using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> itemList;
    public ItemData itemData;
   void Start()

    {
        itemList = new List<Item>();
        Debug.Log("db");
        for (int i = 0; i < itemData.itemArray.data.Length; i++)
        {
            itemList.Add(new Item(itemData.itemArray.data[i]));
  
        }
      
    }
    

}
