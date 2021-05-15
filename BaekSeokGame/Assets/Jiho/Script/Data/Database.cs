using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> itemList = new List<Item>();
    public ItemData itemData;
   void Start()

    {

        for (int i = 0; i < itemData.itemArray.data.Length; i++)
        {
            itemList.Add(new Item(itemData.itemArray.data[i]));
  
        }
      
    }
    

}
