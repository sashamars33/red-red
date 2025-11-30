using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public Light sunLight;                 // Assign your Directional Light
    public List<Vector3> sunRotations;     // One rotation per phase
    public List<float> sunIntensities;

private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);  
    }
    else
    {
        Destroy(gameObject);
    }
}

    // Quest definition
    [System.Serializable]
    public class QuestPhase
    {
        public string phaseName;
        public List<string> requiredItems; // list of item IDs for this phase
    }

    public List<QuestPhase> questPhases = new List<QuestPhase>();

    private int currentPhaseIndex = 0;

    // Track collected items for the current phase
    private List<string> collectedItems = new List<string>();

    // Called when player collects an item
    public void CollectItem(string itemID)
    {
        // Only add if it's required in the current phase
        if (CurrentPhase().requiredItems.Contains(itemID) && !collectedItems.Contains(itemID))
        {
            collectedItems.Add(itemID);
            Debug.Log(collectedItems);
            Debug.Log($"Collected {itemID} for phase {CurrentPhase().phaseName}");
        }
    }

    // Check if the player has collected all items for the current phase
    public bool HasCollectedAllItems()
    {
        foreach (string itemID in CurrentPhase().requiredItems)
        {
            Debug.Log(itemID);
            if (!collectedItems.Contains(itemID)) return false;
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

            ApplySunSettings();

            if (currentPhaseIndex >= questPhases.Count)
            {
                Debug.Log("Quest completed!");
            }
            else
            {
                Debug.Log($"Next phase started: {CurrentPhase().phaseName}");
            }
        }
        else
        {
            Debug.Log("You haven't collected all required items yet!");
        }
    }

    public QuestPhase CurrentPhase()
    {
        if (currentPhaseIndex < questPhases.Count)
            return questPhases[currentPhaseIndex];
        return null;
    }
    private void ApplySunSettings()
{
    if (sunLight == null) return;

    if (currentPhaseIndex < sunRotations.Count)
    {
        sunLight.transform.rotation = Quaternion.Euler(sunRotations[currentPhaseIndex]);
    }

    if (currentPhaseIndex < sunIntensities.Count)
    {
        sunLight.intensity = sunIntensities[currentPhaseIndex];
    }
}



private void OnEnable()
{
    SceneManager.sceneLoaded += OnSceneLoaded;
}

private void OnDisable()
{
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    // Try to find a sun in the new scene
    if (sunLight == null)
    {
        sunLight = FindObjectOfType<Light>();
        ApplySunSettings();
    }
}

}


