using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ItemData> itemList = new List<ItemData>();
   void Start()

    {
   
        itemList.Add(new ItemData(5000,"명검", "무신 덕규가 사용하던 검이다.상당히 좋아 보인다", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5001, "방패", "방어력이 올라간다", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5002, "어깨보호대", "방어력이 올라간다", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5003, "도끼", "초보자들이 사용하기 좋은 무기", ItemData.ItemType.EQUIP));
        itemList.Add(new ItemData(5004, "활", "원거리공격 가능", ItemData.ItemType.EQUIP));
    }
    

}
