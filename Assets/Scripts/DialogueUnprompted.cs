using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUnprompted : MonoBehaviour
{
    [SerializeField] DialogueController dialogueController;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController.StartDialogue();
    }
}
