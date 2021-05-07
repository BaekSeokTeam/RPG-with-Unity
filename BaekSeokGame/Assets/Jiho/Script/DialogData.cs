using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;




[System.Serializable]
public class MyTextData
{
    public int id;
    public int chapter;
    public int[] emotion;
    public int[] isNpc;
    public string[] script;

}
[System.Serializable]
public class MyTextDataArray
{
    public MyTextData[] data;
}
public class DialogData : MonoBehaviour
{
    public int chapterNo;
    TextAsset npcTextData;
    MyTextDataArray npcText;
    //TextAsset playerTextData;
    //MyTextDataArray playerText;
    public Sprite[] portraits;
    void Start()
    {
       
        GenerateData();
    }
    void GenerateData()
    {
        npcTextData = Resources.Load("npcScript") as TextAsset;
        npcText = JsonUtility.FromJson<MyTextDataArray>(npcTextData.ToString());

     

    }
    public Tuple<int,string> GetNpcDialog(int id, int idx)
    {
 
        int findIndex = 0;
        if (id % 100 != 0)
        {
            findIndex = Array.FindIndex(npcText.data, i => i.id == id && i.chapter == 0);
        }
        else
        {
            findIndex = Array.FindIndex(npcText.data, i => i.id == id && i.chapter == chapterNo);
        }
        if (idx >= npcText.data[findIndex].script.Length)
        {
            return Tuple.Create<int, string>(0, null);
        }
        else
        {
            string dialog= npcText.data[findIndex].script[idx];
            int isNpc= npcText.data[findIndex].isNpc[idx];
            return Tuple.Create<int, string>(isNpc, dialog);
        }

    }

    public int GetNpcPortrait(int id, int idx)
    {
        int findIndex = 0;
        if (id % 100 != 0)
        {
            findIndex = Array.FindIndex(npcText.data, i => i.id == id && i.chapter == 0);
        }
        else
        {
            findIndex = Array.FindIndex(npcText.data, i => i.id == id && i.chapter == chapterNo);
        }
        int emotionIdx = npcText.data[findIndex].emotion[idx];

        return emotionIdx;
    }


    public int GetPlayerPortrait(int id, int idx)
    {
        int findIndex = 0;
        if (id % 100 != 0)
        {
            findIndex = Array.FindIndex(npcText.data, i => i.id == id && i.chapter == 0);
        }
        else
        {
            findIndex = Array.FindIndex(npcText.data, i => i.id == id && i.chapter == chapterNo);
        }
        int emotionIdx = npcText.data[findIndex].emotion[idx];



        return emotionIdx;


    }
}





