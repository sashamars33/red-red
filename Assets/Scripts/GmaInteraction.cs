using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmaInteraction : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public string npcName;

    public void Interact()
    {
        Debug.Log("Talking to NPC: " + npcName);
        // Start dialogue system here
    }
}
