using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public string npcName;

    

    // private void OnTriggerEnter(Collider other)
    // {
    //      if (!QuestManager.Instance.questStarted)
    //         {
    //             Debug.Log("Starting quest...");
    //             QuestManager.Instance.StartQuest();
    //             return;  // Stop here so you don't instantly complete the phase
    //     }
    //     if (other.CompareTag("Player"))
    //     {   
    //         Debug.Log("Gma Collision");
    //         QuestManager.Instance.CompletePhase();
    //     }
    // }
}