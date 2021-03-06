using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    private static Database instance = null;
    // Start is called before the first frame update
    public List<Item> itemList;
    public ItemData itemData;
    void Awake()
    {
        if (null == instance)
        {
           
            instance = this;

      
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
           
            Destroy(this.gameObject);
        }

    }
    public static Database Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    void Start()

    {
        itemList = new List<Item>();
        
        for (int i = 0; i < itemData.itemArray.data.Length; i++)
        {
            itemList.Add(new Item(itemData.itemArray.data[i]));
  
        }
        Debug.Log("db");

    }
    

}
