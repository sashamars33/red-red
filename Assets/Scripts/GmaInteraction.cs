using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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


    public Sprite[] dialogueSpritesPhaseI;
    public Sprite[] dialogueSpritesPhaseII;
    public Sprite[] dialogueSpritesPhaseIII; 



    public void Interact()
    {
        Debug.Log("Interaction GMA", dialogueSpritesPhaseI[0]);
        if (!QuestManager.Instance.questStarted)
        {
            DialogueManager.Instance.StartDialogue(
                dialogueSpritesPhaseI,
                () =>
                {
                    QuestManager.Instance.StartQuest();
                    Debug.Log("Quest Started", dialogueSpritesPhaseI[0]);
                }
            );
        }
        else
        {
            if(QuestManager.Instance.currentPhaseIndex == 1)
            {
                DialogueManager.Instance.StartDialogue(
                dialogueSpritesPhaseII,
                () =>
                {
                    QuestManager.Instance.CompletePhase();
                }
            );
            }else if(QuestManager.Instance.currentPhaseIndex == 2)
            {
                 DialogueManager.Instance.StartDialogue(
                dialogueSpritesPhaseIII,
                () =>
                {
                    QuestManager.Instance.CompletePhase();
                }
            );
            }
            
        }
    }
}
