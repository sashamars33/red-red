using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangerOnCollision : MonoBehaviour, IInteractable
{
    [Header("Add Loading Scene")]
    public string sceneToLoad;
    public Image blackScreenImage; 

    public void Interact()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            StartCoroutine(SceneLoadTimer(1));
            
        }
        else
        {
            Debug.LogError("DoorInteractable: No scene assigned!");
        }
    }

    IEnumerator SceneLoadTimer(int scene)
    {
        float timer = 0f;
        float duration = 0.5f;

        while(timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            float lerp = timer / duration;

            blackScreenImage.color = Color.Lerp(Color.clear, Color.black, lerp);

            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.8f);

        SceneManager.LoadScene(sceneToLoad);
    }
}