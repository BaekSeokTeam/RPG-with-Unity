using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public int questId;
    public int questActionIdx;
    Dictionary<int,QuestData> questList;
    public GameObject[] questObject;
    public GameObject[] questMonster;   
    void Awake()
    {
        questList = new Dictionary<int,QuestData>();

        GenerateData();
    }


    void GenerateData()
    {
        //생성자 이용 (string name, int[] npcid)
        questList.Add(10,new QuestData("모험의시작", new int[] { 1000, 1100 }, new string[] { "덕규에게 말을 걸어라", "조갓에게 말을 걸어라" }));
    }
    public int GetQuestTalkIndex(int id)
    {
        if (questId == 0)
        {
            return id;
        }
        else if (questList[questId].questNpc[questActionIdx] == id)
        {
            return id + questId + questActionIdx;
        }
        else
        {
            return id;
        }
    }
    public void CheckQuest(int id)
    {
        if (questId == 0)
        {
            return;
        }
        if (questList[questId].questNpc[questActionIdx] == id)
        {
             questActionIdx+=1;
        }
        if (questList[questId].questNpc.Length == questActionIdx)
        {
            questId = 0;
            questActionIdx=0;
        }
    }
    public void IncreaseIdx()
    {
        questActionIdx += 1;
    }
}
