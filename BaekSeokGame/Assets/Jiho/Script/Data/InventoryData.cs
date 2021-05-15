using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    private static InventoryData instance = null;
    // Start is called before the first frame update
    public List<Item> items;
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
        items = new List<Item>();
    }
    public static InventoryData Instance
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
        Debug.Log(Database.Instance.itemList.Count);
        for (int i=0; i< Database.Instance.itemList.Count; i++)
        {
            items.Add(Database.Instance.itemList[i]);
        }
      

    }


}
