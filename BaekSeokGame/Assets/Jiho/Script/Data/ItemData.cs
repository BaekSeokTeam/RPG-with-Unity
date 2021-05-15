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
    TextAsset itemTextData;
    public MyItemDataArray itemArray;
    //TextAsset playerTextData;
    //MyTextDataArray playerText;
  
    void Awake()
    {
        Debug.Log("itemdata");   
        GenerateData();
    }
    void GenerateData()
    {
        itemTextData = Resources.Load("ItemData") as TextAsset;
        itemArray = JsonUtility.FromJson<MyItemDataArray>(itemTextData.ToString());



    }
    
}





