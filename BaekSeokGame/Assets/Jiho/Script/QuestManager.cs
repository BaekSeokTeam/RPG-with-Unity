using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    static bool onLoad = false;
    public int questId;
    public int questActionIdx;
    Dictionary<int, QuestData> questList;
    public GameObject[] questObject;
    public GameObject uiManager;
    public InventoryController inventory;
    int maxEnemyCount;
    int enemyCount;
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();

        if (!onLoad)
        {
            questId = DataController.Instance.gameData.questId;
            questActionIdx = DataController.Instance.gameData.questActionIdx;
            enemyCount = DataController.Instance.gameData.enemyCount;
            onLoad = true;

        }
        QuestObjectController();
        EnemyQuestControl();
        ChangeQuestUI();

    }
    private void FixedUpdate()
    {
        DataController.Instance.gameData.questId = questId;
        DataController.Instance.gameData.questActionIdx = questActionIdx;
        DataController.Instance.gameData.enemyCount = enemyCount;
    }
    void ChangeQuestUI()
    {
        if (questId == 0)
        {
            uiManager.GetComponent<QuestUIManager>().Change(null, null);
        }
        else
        {
            uiManager.GetComponent<QuestUIManager>().Change(questList[questId].questTitle, questList[questId].questDescription[questActionIdx]);
        }
    }


    void GenerateData()
    {
        //생성자 이용 (string name, int[] npcid)
        questList.Add(10, new QuestData("모험의시작", new int[] { 1000, 1100 }, new string[] { "덕규에게 말을 걸어라", "조갓에게 말을 걸어라" }));
        questList.Add(20, new QuestData("몬스터 사냥", new int[] { 1100, 0, 1100 }, new string[] { "조갓과 대화하라", "몬스터를 잡아라", "조갓과 대화하라" }));
        questList.Add(30, new QuestData("무기 획득", new int[] { 1100, 0, 1000 }, new string[] { "조갓과 대화하라", "무기를 찾아라", "덕규와 대화하라" }));
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
            QuestObjectController();
            ChangeQuestUI();
            return;
        }
        if (questList[questId].questNpc[questActionIdx] == id)
        {
            questActionIdx += 1;

            EnemyQuestControl();
        }
        if (questList[questId].questNpc.Length == questActionIdx)
        {
            nextQuest();

            EnemyQuestControl();
        }
        QuestObjectController();
        ChangeQuestUI();
    }
    void nextQuest()
    {
        questId += 10;
        questActionIdx = 0;
        if (questId == 40)
        {
            questId = 0;    
        }
        QuestObjectController();
    }
    public void CheckQuest()
    {
        if (questList[questId].questNpc.Length == questActionIdx)
        {
            questId = 0;
            questActionIdx = 0;
            ChangeQuestUI();
            EnemyQuestControl();
            QuestObjectController(); 
        }
    }
    public void IncreaseIdx()
    {
        questActionIdx += 1;
        EnemyQuestControl();
        ChangeQuestUI();
        QuestObjectController();
    }
    public void QuestEmemyDied(int enemyId)
    {


        if (questId == 20 && questActionIdx == 1 && enemyId == 10000)
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
    void QuestObjectController()
    {
        for (int i = 0; i < questObject.Length; i++)
        {
            questObject[i].SetActive(false);
        }
        switch (questId)
        {
            case 30:
                if (questActionIdx == 1)
                {
                    questObject[0].SetActive(true);
                }
                else if (questActionIdx == 2)
                {
                    inventory.AddItem(questObject[0].GetComponent<ItemObject>().itemData);
                }
                return;
            default:
                return;
        }
    }
}
