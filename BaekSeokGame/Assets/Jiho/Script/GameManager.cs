using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

  
 
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    public void saveData()
    {
        DataController.Instance.SaveGameData();
    }

    void Update()
    {
       
     
        
    }
}
