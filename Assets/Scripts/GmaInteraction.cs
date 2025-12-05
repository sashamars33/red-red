using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmaInteraction : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public string npcName;

    // public void Interact()
    // {
    //     if (!QuestManager.Instance.questStarted)
    //         {
    //             Debug.Log("Starting quest...");
    //             QuestManager.Instance.StartQuest();
    //             return;  // Stop here so you don't instantly complete the phase
    //     }
    //     if (QuestManager.Instance.questStarted)
    //     {   
    //         QuestManager.Instance.CompletePhase();
    //     }
    // }

     public static DialogueUI Instance;
    public Sprite[] dialogSpritesPhaseI;
    public Sprite[] dialogSpritesPhaseII;
    public Sprite[] dialogSpritesPhaseIII; 



    public void Interact()
    {
        if (!QuestManager.Instance.questStarted)
        {
            DialogueManager.Instance.StartDialog(
                dialogSpritesPhaseI,
                () =>
                {
                    QuestManager.Instance.StartQuest();
                }
            );
        }
        else
        {
            if(QuestManager.Instance.currentPhaseIndex == 1)
            {
                DialogueManager.Instance.StartDialog(
                dialogSpritesPhaseII,
                () =>
                {
                    QuestManager.Instance.CompletePhase();
                }
            );
            }else if(QuestManager.Instance.currentPhaseIndex == 1)
            {
                 DialogueManager.Instance.StartDialog(
                dialogSpritesPhaseIII,
                () =>
                {
                    QuestManager.Instance.CompletePhase();
                }
            );
            }
            
        }
    }
}
