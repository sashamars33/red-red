using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private Dictionary<string, int> collectedItems = new Dictionary<string, int>();

    public void AddItem(string questID)
    {
        if (!collectedItems.ContainsKey(questID))
            collectedItems[questID] = 0;

        collectedItems[questID]++;
    }

    public bool HasRequiredItems(string questID, int required)
    {
        return collectedItems.ContainsKey(questID) &&
               collectedItems[questID] >= required;
    }
}
