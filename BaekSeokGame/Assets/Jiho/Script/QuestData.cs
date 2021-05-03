using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public int questId;
    public string questTitle;
    public int[] questNpcId;
    public string[] questDescription;
    public int maxQuestActionidx;

    public QuestData() { }
    public QuestData(int id,string title,int[] npcs,string[] descriptions,int idx) {
        questId = id;
        questTitle = title;
        questNpcId = npcs;
        questDescription = descriptions;
        maxQuestActionidx = idx;
   
    }


}
