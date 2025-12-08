using UnityEngine;

public class GmaInteraction : MonoBehaviour, IInteractable
{
    public string npcName;


    public void Interact()
    {
        Debug.Log($"{npcName} interacted with player!");

        // Let the QuestManager handle the rest
        QuestManager.Instance.OnNPCInteraction();
    }
}
