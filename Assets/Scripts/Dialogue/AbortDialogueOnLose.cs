using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbortDialogueOnLose : MonoBehaviour
{
    [SerializeField] TimerController timer;
    private DialogueController dialogueController;

    void Start()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If timer is not running, disable dialogue
        if (timer.remainingTime <= 0)
        {
            dialogueController.EndDialogue();
        }
    }
}
