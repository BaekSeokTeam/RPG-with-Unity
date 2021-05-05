using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public int questId;
    public int questActionIdx;
    Dictionary<int,QuestData> questList;
    public GameObject[] questObject;
    int maxEnemyCount;
    int enemyCount;
    void Awake()
    {
        questList = new Dictionary<int,QuestData>();

        GenerateData();
    }


    void GenerateData()
    {
        //생성자 이용 (string name, int[] npcid)
        questList.Add(10,new QuestData("모험의시작", new int[] { 1000, 1100 }, new string[] { "덕규에게 말을 걸어라", "조갓에게 말을 걸어라" }));
        questList.Add(20,new QuestData("몬스터 사냥", new int[] { 1100, 0, 1100 }, new string[] { "조갓과 대화하라", "몬스터를 잡아라", "조갓과 대화하라" }));
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
            EnemyQuestControl();
        }
        if (questList[questId].questNpc.Length == questActionIdx)
        {
            questId = 0;
            questActionIdx=0;
            EnemyQuestControl();
        }
    }
    public void CheckQuest()
    {
        if (questList[questId].questNpc.Length == questActionIdx)
        {
            questId = 0;
            questActionIdx = 0;
            EnemyQuestControl();
        }
    }
    public void IncreaseIdx()
    {
        questActionIdx += 1;
        EnemyQuestControl();
    }
    public void QuestEmemyDied(int enemyId)
    {
        

        if (questId==20 && questActionIdx == 1 && enemyId == 10000)
        {

            enemyCount += 1;
            if (enemyCount == maxEnemyCount)
            {
                IncreaseIdx();
            }
        }

        return;

     
        }
    
    void EnemyQuestControl()
    {
        switch (questId)
        {
            case 20:
                if (questActionIdx == 1)
                {
                    maxEnemyCount=1;
                    enemyCount=0;
                }
                return;
            default:
                maxEnemyCount = 0;
                enemyCount = 0;
                return;
        }
    }
}
