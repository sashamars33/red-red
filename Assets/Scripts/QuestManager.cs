using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public TMP_Text CollectionText;       
    public GameObject gameOverScreen;     // Assign your Directional Light
    
    public bool questStarted = false;

    [Header("Dialog Sprites")]
    public Sprite[] dialogueSpritesPhaseI;
    public Sprite[] dialogueSpritesPhaseII;
    public Sprite[] dialogueSpritesPhaseIII;

     // Quest definition
    [System.Serializable]
    public class QuestPhase
    {
        public string phaseName;
        public List<string> requiredItems; // list of item IDs for this phase
    }

    public List<QuestPhase> questPhases = new List<QuestPhase>();

    public int currentPhaseIndex = 0;

    // Track collected items for the current phase
    private List<string> collectedItems = new List<string>();

    


private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // <-- keeps the object alive
    }
    else
    {
        Destroy(gameObject);
    }
}

public void StartQuest()
    {
        if (questStarted) return;

        questStarted = true;
        CollectionText.text = "";
    }

       private void Start()
{
    if (QuestManager.Instance == null || DialogueManager.Instance == null)
    {
        CollectionText.text = "Managers not found!";
    }
}


    // Called when player collects an item
    public void CollectItem(string itemID)
    {

        if (!questStarted)
        {
            Debug.Log("You must talk to the NPC to start the quest!");
            CollectionText.text = "Gammy has a Quest for you! Head home and talk to her ASAP..";
            return;
        }
        // Only add if it's required in the current phase
        if (CurrentPhase().requiredItems.Contains(itemID) && !collectedItems.Contains(itemID))
        {
            
            collectedItems.Add(itemID);
            CollectionText.text = CollectionText.text + itemID + "\n";
            
            Debug.Log($"Collected {itemID} for phase {CurrentPhase().phaseName}");
            if (HasCollectedAllItems())
            {
               CollectionText.text = "All Items Collected!" + "\n" + "Go talk to Gammy.."; 
            }
        }
    }

    // Check if the player has collected all items for the current phase
    public bool HasCollectedAllItems()
    {
        foreach (string itemID in CurrentPhase().requiredItems)
        {
            Debug.Log(itemID);
            if (!collectedItems.Contains(itemID)) {
                Debug.Log("need more items");
                return false;
            }
        }
        return true;
    }

    // Call this when player returns to NPC
    public void CompletePhase()
    {
        if (HasCollectedAllItems())
        {
            Debug.Log($"Phase {CurrentPhase().phaseName} completed!");
            collectedItems.Clear(); // reset for next phase
            currentPhaseIndex++;

            if (currentPhaseIndex >= questPhases.Count)
            {
                CollectionText.text = "";
                Debug.Log("Quest completed!");
            }
            else
            {
                CollectionText.text = "";
                Debug.Log($"Next phase started: {CurrentPhase().phaseName}");
            }
        }
        else
        {
            CollectionText.text = "You haven't collected all required items yet!";
        }
    }

    public QuestPhase CurrentPhase()
    {
        if (currentPhaseIndex < questPhases.Count)
            return questPhases[currentPhaseIndex];
        return null;
    }


public void OnNPCInteraction()
{
   Sprite[] spritesToUse = null;

    if (!questStarted)
    {
        // Intro dialogue before the quest actually starts
        spritesToUse = dialogueSpritesPhaseI;
        DialogueManager.Instance.StartDialogue(spritesToUse, StartQuest);
    }
    else if (currentPhaseIndex == 0)
    {
        // First real phase turn-in
        spritesToUse = dialogueSpritesPhaseII;
        DialogueManager.Instance.StartDialogue(spritesToUse, CompletePhase);
    }
    else if (currentPhaseIndex == 1)
    {
        // Second phase turn-in
        spritesToUse = dialogueSpritesPhaseIII;
        DialogueManager.Instance.StartDialogue(spritesToUse, CompletePhase);
    }
    else
    {
        Debug.Log($"OnNPCInteraction: No dialogue defined for currentPhaseIndex = {currentPhaseIndex}");
        Die();
    }
}
 public void Die()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

}


