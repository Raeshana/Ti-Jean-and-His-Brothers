using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    [SerializeField] DialogueController dialogueController;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController.StartDialogue(); // Start time dialogue
    }
}