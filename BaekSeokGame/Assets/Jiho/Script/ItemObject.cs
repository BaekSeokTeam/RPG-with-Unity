using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : ObjectData
{
    // Start is called before the first frame update
    public ItemData itemData;
    void Start()
    {
        Debug.Log("이거 불려?");
       itemData= GameObject.Find("Database").GetComponent<Database>().itemList.Find(x=>x.id == this.id);
    }
}
