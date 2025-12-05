using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialogPanel;
    public Image dialogImage;

    private Sprite[] currentSprites;
    private int index = 0;
    private System.Action onDialogComplete;

        private void Awake()
    {
        Instance = this;
        dialogPanel.SetActive(false);
    }

    private void Update()
    {
        if (dialogPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            Next();
        }
    }

    public void StartDialog(Sprite[] sprites, System.Action endCallback = null)
    {
        currentSprites = sprites;
        onDialogComplete = endCallback;

        index = 0;
        dialogPanel.SetActive(true);

        dialogImage.sprite = currentSprites[index];
    }

    private void Next()
    {
        index++;

        if (index >= currentSprites.Length)
        {
            EndDialog();
            return;
        }

        dialogImage.sprite = currentSprites[index];
    }

    private void EndDialog()
    {
        dialogPanel.SetActive(false);
        onDialogComplete?.Invoke();
    }
}
