using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{

    public string questTitle;
    public int[] questNpc;
    public string[] questDescription;


    public QuestData() { }
    public QuestData(string title,int[] npcs,string[] description) {

        questTitle = title;
        questNpc = npcs;
        questDescription = description;

   
    }


}
