using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ItemData> itemList = new List<ItemData>();
   void Start()

    {
   
        itemList.Add(new ItemData(5000,"명검", "명검", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5001, "방패", "방패", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5002, "어깨보호대", "어깨보호대", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5003, "도끼", "도끼", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5004, "활", "활", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5005, "갑옷", "갑옷", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5006, "벨트", "벨트", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5007, "마법서", "마법서", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5008, "장화", "장화", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5009, "팔목보호대", "팔목보호대", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5010, "망토", "망토", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5011, "장갑", "장갑", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5012, "투구", "투구", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5013, "목걸이", "목걸이", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5014, "바지", "바지", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5015, "반지", "반지", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5101, "HP포션", "HP포션", ItemData.ItemType.USE));
        itemList.Add(new ItemData(5100, "사과", "사과", ItemData.ItemType.USE));
        itemList.Add(new ItemData(5102, "MP포션", "MP포션", ItemData.ItemType.USE));
        itemList.Add(new ItemData(5103, "고기", "고기", ItemData.ItemType.USE));
        itemList.Add(new ItemData(5104, "스크롤", "스크롤", ItemData.ItemType.USE));
        itemList.Add(new ItemData(5200, "가방", "가방", ItemData.ItemType.MATERIAL));
        itemList.Add(new ItemData(5201, "동전", "동전", ItemData.ItemType.MATERIAL));
        itemList.Add(new ItemData(5202, "보석", "보석", ItemData.ItemType.MATERIAL));
        itemList.Add(new ItemData(5203, "강철", "강철", ItemData.ItemType.MATERIAL));
      
    }
    

}
