using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : ObjectData
{
    // Start is called before the first frame update
    public Item itemData;
    void Start()
    {
        
       itemData= GameObject.Find("Database").GetComponent<Database>().itemList.Find(x=>x.id == this.id);
    }
}
