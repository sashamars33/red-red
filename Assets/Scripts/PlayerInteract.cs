using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance;
    public TMP_Text interactText;

    private IInteractable currentInteractable;
    // Start is called before the first frame update
    void Start()
    {
        interactText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteractable();
        CheckInteractionInput();
    }

    public void CheckForInteractable()
    {
        currentInteractable = null;
        interactText.text = "";
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, interactDistance)) //here we are sending out a raycast in front of the player, which is constantly checking if it is touching objects that we can interact with, so it can prompt the player to interact. in this case, we just have an interactable door, so if the player raycast hits an object tagged as Door, it will show us the prompt that this object is interactable.
        { 
            //checking if raycast is hitting an interactible object
            IInteractable interactObj = hit.collider.GetComponent<IInteractable>();
            currentInteractable = interactObj;

            //this raycast also uses a distance we set in the inspector, which we can mess around with so make sure we can't interact with things too far away from us, as well as to make sure we can interact with things that feel close enough to be able to. 

            if (interactObj != null)
            {
                interactText.text = "E";
            }
            else
            {
                interactText.text = "";
            }
        }
        else
        {
            interactText.text = "";
        }
    }
    private void CheckInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentInteractable != null)
            {
                currentInteractable.Interact();
            }
            else
            {
                Debug.Log("Pressed E, but nothing interactable in front.");
            }
        }
    }

    }
