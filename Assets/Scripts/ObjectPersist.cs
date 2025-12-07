using UnityEngine;

public class PersistentUI : MonoBehaviour

{
    public static PersistentUI Instance;
    private void Awake()
    {
         if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // <-- keeps the object alive
    }
    else
    {
        Destroy(gameObject);
    }
}
}