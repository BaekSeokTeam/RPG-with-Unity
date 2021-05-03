using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public int questId;
    Dictionary<int,QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int,QuestData>();
        GenerateData();
    }


    void GenerateData()
    {
        //생성자 이용 (string name, int[] npcid)
        questList.Add(10,new QuestData(10, "모험의시작", new int[] { 1000, 1100 }, new string[] { "덕규에게 말을 걸어라", "조갓에게 말을 걸어라" }, 2));
    }
}
