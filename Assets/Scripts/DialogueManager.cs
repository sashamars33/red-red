using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private string[] currentLines;
    private int lineIndex;
    private string currentSpeaker;

    public void StartDialogue(string speaker, string[] lines)
    {
        currentSpeaker = speaker;
        currentLines = lines;
        lineIndex = 0;

        // Show the UI and display first line
        DialogueUI.Instance.Show();
        DialogueUI.Instance.SetSpeaker(speaker);
        DialogueUI.Instance.SetDialogue(currentLines[lineIndex]);
    }

    public void NextLine()
    {
        lineIndex++;

        if (lineIndex >= currentLines.Length)
        {
            EndDialogue();
            return;
        }

        DialogueUI.Instance.SetDialogue(currentLines[lineIndex]);
    }

    private void EndDialogue()
    {
        DialogueUI.Instance.Hide();
        currentLines = null;
    }
}
