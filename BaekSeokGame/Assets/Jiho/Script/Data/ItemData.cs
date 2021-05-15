using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;




[System.Serializable]
public class MyItemData
{
    public int id;
    public string name;
    public string description;
    public int itemType;
    public int purchasePrice;
    public int salePrice;

}
[System.Serializable]
public class MyItemDataArray
{
    public MyItemData[] data;
}
public class ItemData : MonoBehaviour
{
    private static ItemData instance = null;
    TextAsset itemTextData;
    public MyItemDataArray itemArray;
    //TextAsset playerTextData;
    //MyTextDataArray playerText;
    public static ItemData Instance
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
        GenerateData();
    }
    void GenerateData()
    {
        itemTextData = Resources.Load("ItemData") as TextAsset;
        itemArray = JsonUtility.FromJson<MyItemDataArray>(itemTextData.ToString());



    }
    
}





