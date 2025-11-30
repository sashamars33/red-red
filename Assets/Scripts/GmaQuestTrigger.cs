using System;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public string npcName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            Debug.Log("Gma Collision");
            QuestManager.Instance.CompletePhase();
        }
    }
}