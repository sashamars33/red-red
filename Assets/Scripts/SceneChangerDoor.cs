using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerOnCollision : MonoBehaviour, IInteractable
{
    [Header("Add Loading Scene")]
    public string sceneToLoad;

    public void Interact()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("DoorInteractable: No scene assigned!");
        }
    }
}