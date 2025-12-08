using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialoguePanel;
    public Image dialogueImage;
    public Image blackScreenImage; 

    private Sprite[] currentSprites;
    private int index = 0;
    private System.Action onDialogueComplete;

        private void Awake()
    {
        
         if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // <-- persists across scenes
    }
    else
    {
        Destroy(gameObject);
    }

    }

    private void Start()
{
    if (QuestManager.Instance == null || DialogueManager.Instance == null)
    {
        Debug.LogError("Managers not found!");
    }
}


    private void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            Next();
            Debug.Log("Next..");
        }
    }

    public void StartDialogue(Sprite[] sprites, System.Action endCallback = null)
    {
        
        currentSprites = sprites;
        onDialogueComplete = endCallback;

        index = 0;
        dialoguePanel.SetActive(true);

        dialogueImage.sprite = currentSprites[index];
        Debug.Log("Dialogue Started", sprites[0]);
    }

    private void Next()
    {
        index++;

        if (index >= currentSprites.Length)
        {
            EndDialogue();
            return;
        }

        dialogueImage.sprite = currentSprites[index];
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        onDialogueComplete?.Invoke();
        Debug.Log("Dialogue Ended");
    }
}
