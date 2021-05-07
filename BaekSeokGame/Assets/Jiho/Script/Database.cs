using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ItemData> itemList = new List<ItemData>();
   void Start()

    {
       // itemList.Add(new ItemData("명검", "무신 덕규가 사용하던 검이다.상당히 좋아 보인다", ItemData.ItemType.IMPORTANT));
    }
    

}
