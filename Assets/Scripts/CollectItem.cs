using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItem : MonoBehaviour
{
    // Camomile, Poppy, Angelica, Coriander, Red Cap Mushroom, Blue drippy mushroom, newt, bat
    private int collectibleCount;
    public TMP_Text countText;

    public int winCount;
    public GameObject winScreen;

    public AudioSource collectSound;
    // Start is called before the first frame update
    void Start()
    {
        countText.text = "";
        if (winScreen != null)
            winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collect")
        {
            PrefabID prefabID = other.GetComponent<PrefabID>();
            // collectibleCount++;
            if (prefabID != null)
            {
                countText.text = countText.text  + prefabID.ID + "\n";
                // CollectionManager.Instance.Add(prefabID.ID);
            }
            
            if(collectSound != null)
            {
                collectSound.Play();
            }
            
            Destroy(other.gameObject);
            
            // if(collectibleCount == winCount)
            // {
            //     winScreen.SetActive(true);
            //     Cursor.lockState = CursorLockMode.Confined;
            //     Cursor.visible = true;
            //     Time.timeScale = 0;
            // }
        }
    }
}
