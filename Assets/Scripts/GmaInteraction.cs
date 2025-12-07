using UnityEngine;

public class GmaInteraction : MonoBehaviour, IInteractable
{
    public string npcName;

    private void Awake()
    {
        // Optional: make NPC persistent if needed
        if (FindObjectsOfType<GmaInteraction>().Length > 1)
        {
            Destroy(gameObject); // destroy duplicate
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Interact()
    {
        Debug.Log($"{npcName} interacted with player!");

        // Let the QuestManager handle the rest
        QuestManager.Instance.OnNPCInteraction();
    }
}
