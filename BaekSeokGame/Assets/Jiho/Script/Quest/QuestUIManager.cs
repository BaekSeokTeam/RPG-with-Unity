using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    public Text head;
    public Text body;
    
    // Start is called before the first frame update


    // Update is called once per frame
    public void Change(string head,string body)
    {
        if (head == null)
        {
            this.head.text = "퀘스트가 없습니다.";
            this.body.text = "";
        }
        else
        {
            this.head.text = head;
            this.body.text = body;

        }

    }
}
