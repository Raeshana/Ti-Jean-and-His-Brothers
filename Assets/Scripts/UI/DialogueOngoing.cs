using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOngoing : MonoBehaviour
{
    [SerializeField] DialogueController[] dialogueControllers;
    public bool dialogueOngoing; // true if dialogue is ongoing

    void Start(){
        dialogueOngoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(DialogueController dialogueController in dialogueControllers)
        {
            dialogueOngoing = dialogueOngoing || !dialogueController.endOfDialogue;
        }
    }
}
