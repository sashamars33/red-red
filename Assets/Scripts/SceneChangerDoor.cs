using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerOnCollision : MonoBehaviour
{
    [Header("Name of the scene to load on collision")]
    public string sceneToLoad;

    [Header("Tag of the object that will trigger the scene change")]
    public string triggeringTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggeringTag))
        {
            LoadScene();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(triggeringTag))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("SceneChangerOnCollision: No scene name assigned!");
        }
    }
}