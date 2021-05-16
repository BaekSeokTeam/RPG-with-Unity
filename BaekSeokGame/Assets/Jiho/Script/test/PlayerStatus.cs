using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerStatusData
{
    public int playerLevel;
    public string playerName;

    public int playerMaxHealth;
    public int playerCurrentHealth;

}


public class PlayerStatus : MonoBehaviour
{


    TextAsset statusData;
    PlayerStatusData playerStatusData;


    // Start is called before the first frame update
    void Start()
    {

        GenerateData();
    }
    void GenerateData()
    {
        statusData = Resources.Load("sex") as TextAsset;
        playerStatusData = JsonUtility.FromJson<PlayerStatusData>(statusData.ToString());

        Debug.Log(playerStatusData.playerLevel);
        Debug.Log(playerStatusData.playerName);
        Debug.Log(playerStatusData.playerMaxHealth);
        Debug.Log(playerStatusData.playerCurrentHealth);

    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
