using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    public GameObject panel;
    public TMP_Text speakerNameText;
    public TMP_Text dialogueText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Hide();
    }

    public void Show()
    {
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    public void SetSpeaker(string name)
    {
        speakerNameText.text = name;
    }

    public void SetDialogue(string line)
    {
        dialogueText.text = line;
    }
}
