using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogController : MonoBehaviour



 {

    public GameObject hidingObject;
    public GameObject dialogUI;
    public Text npcName;
    public Text dialogBody;
    public DialogData dialogData;
    public GameObject npcPortrait;
    public GameObject playerPortrait;
    public QuestManager questManager;
    public InventoryController inventoryController;
    public int dialogIdx=0;
    bool isTalking;
    Image npcPortraitImage;
    Image playerPortraitImage;
    void Start()
    {
        dialogIdx = 0;
        npcPortraitImage = npcPortrait.GetComponent<Image>();
        playerPortraitImage = playerPortrait.GetComponent<Image>();
    }       

    void Update()
    {
        
    }


    public void Action(GameObject objectData)
    {   
        ObjectData objData = objectData.GetComponent<ObjectData>();
        //만약 npc id가 현재 퀘스트의 
    
            Talk(objData);
       

        //Change ui status through isTalking flag.
        hidingObject.SetActive(!isTalking);
        dialogUI.SetActive(isTalking);
    }

    void Talk(ObjectData objectData)
    {
           
        if (objectData.tag == "npc") {
            int talkIdx = questManager.GetQuestTalkIndex(objectData.id);
            var response = dialogData.GetNpcDialog(talkIdx, dialogIdx);
            string nameText = objectData.GetComponent<NpcData>().npcName;
            string body = response.Item2;
            int isNpc = response.Item1;
            if (body == null)
            {
                questManager.CheckQuest(objectData.id);
                isTalking = false;
                npcPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                playerPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                dialogIdx = 0;
                return;
            }
            else
            {
                if (isNpc == 1)
                {
                    npcName.text = nameText;
                    dialogBody.text = body;
                    npcPortraitImage.sprite = objectData.GetComponent<NpcData>().npcEmotion[dialogData.GetNpcPortrait(objectData.id, dialogIdx)];

                    playerPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                    npcPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    isTalking = true;
                    dialogIdx++;
                }
                else
                {
                    npcName.text = "주인공";
                    dialogBody.text = body;
                    npcPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                    playerPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    playerPortraitImage.sprite = GameObject.Find("Player").GetComponent<PlayerData>().playerEmotion[dialogData.GetPlayerPortrait(objectData.id, dialogIdx)];
                    isTalking = true;
                    dialogIdx++;
                }
            }
        }
        else if (objectData.tag == "Item")
        {
        
            if (isTalking == false)
            {
                
                npcName.text = objectData.GetComponent<ItemObject>().itemData.itemName;
                dialogBody.text = objectData.GetComponent<ItemObject>().itemData.itemDescription;
    
                playerPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                npcPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                isTalking = true;
                
                dialogIdx = 0;
            }
            else
            {
 
                questManager.IncreaseIdx();
                isTalking = false;
            }
        }
        

    }
}
