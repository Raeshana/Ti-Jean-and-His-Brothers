using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTransition : MonoBehaviour
{
    [SerializeField] DialogueController prev;
    [SerializeField] DialogueController next;

    // Angry prompt 
    [SerializeField] DialogueController angryPrompt;
    private DialogueController angryPromptInstance;

    void Update()
    {
        if (prev.endOfDialogue)
        {
            prev.endOfDialogue = false; // End previous dialogue
            
            // Creates and starts dialogue of an instance of an angry prompt
            angryPromptInstance = Instantiate(angryPrompt, transform.position, Quaternion.identity, transform);
            angryPromptInstance.StartDialogue();
        }
    }

    public void AngryPromptTransition()
    {
        next.StartDialogue();
    }
}
