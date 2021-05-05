using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    //player위치
    public float playerX;
    public float playerY;
    //현재 맵
    public string currentMap;
    //퀘스트정보
    public int questId;
    public int questActionIdx;

    public int enemyCount;
}
