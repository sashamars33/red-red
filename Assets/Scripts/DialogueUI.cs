using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;
    public Sprite[] dialogSpritesGma;
    public Sprite[] dialogSpritesRRH; 


     public Sprite[] dialogSprites; // Images with text baked in

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!QuestManager.Instance.questStarted)
        {
            DialogueManager.Instance.StartDialog(
                dialogSprites,
                () =>
                {
                    QuestManager.Instance.StartQuest();
                }
            );
        }
        else
        {
            QuestManager.Instance.CompletePhase();
        }
    }

}
