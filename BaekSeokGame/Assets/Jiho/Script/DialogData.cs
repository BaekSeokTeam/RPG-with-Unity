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
    Dictionary<int, Sprite> portraitData;
    MyTextDataArray npcText;
    //TextAsset playerTextData;
    //MyTextDataArray playerText;
    public Sprite[] portraits;
    void Start()
    {
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }
    void GenerateData()
    {
        npcTextData = Resources.Load("npcScript") as TextAsset;
        npcText = JsonUtility.FromJson<MyTextDataArray>(npcTextData.ToString());
        //playerTextData = Resources.Load("playerScript") as TextAsset;
        //playerText = JsonUtility.FromJson<MyTextDataArray>(playerTextData.ToString());
        portraitData.Add(0 + 0, portraits[0]);
        portraitData.Add(0+1, portraits[1]);
        portraitData.Add(1000 + 0, portraits[1]);
        portraitData.Add(1000 + 1, portraits[0]);
        portraitData.Add(1100 + 0, portraits[0]);
        portraitData.Add(1100 + 1, portraits[1]);

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

    public Sprite GetNpcPortrait(int id, int idx)
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

        return portraitData[id + emotionIdx];
    }

    //public string GetNpcDialog(int id, int idx)
    //{
    //    int findIndex = 0;
    //    if (id % 100 != 0)
    //    {
    //        findIndex = Array.FindIndex(npcText.data, i => i.id == id && i.chapter == 0);
    //    }
    //    else
    //    {
    //        findIndex = Array.FindIndex(npcText.data, i => i.id == id && i.chapter == chapterNo);
    //    }
    //    if (idx >= npcText.data[findIndex].script.Length)
    //    {
    //        return null;
    //    }
    //    else
    //    {
    //        return npcText.data[findIndex].script[idx];
    //    }

    //}

    //public Sprite GetNpcPortrait(int id, int idx)
    //{
    //    int findIndex = Array.FindIndex(npcText.data, i => i.id == id&& i.chapter == chapterNo);
    //    int emotionIdx = npcText.data[findIndex].emotion[idx];

    //    return portraitData[id + emotionIdx];
    //}
    //public string GetPlayerDialog(int id, int idx)
    //{
    //    int findIndex = 0;
    //    if (id % 100 != 0)
    //    {
    //        findIndex = Array.FindIndex(playerText.data, i => i.id == id && i.chapter == 0);
    //    }
    //    else
    //    {
    //        findIndex = Array.FindIndex(playerText.data, i => i.id == id && i.chapter == chapterNo);
    //    }

    //    if (idx >= playerText.data[findIndex].script.Length)
    //    {
    //        return null;
    //    }
    //    else
    //    {
    //        return playerText.data[findIndex].script[idx];
    //    }

    //}

    public Sprite GetPlayerPortrait(int id, int idx)
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



        return portraitData[0 + emotionIdx];
    }


}





