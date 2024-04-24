using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTransition : MonoBehaviour
{
    [SerializeField] DialogueController prev;
    [SerializeField] DialogueController next;

    void Update()
    {
        if (prev.endOfDialogue)
        {
            next.StartDialogue();
            prev.endOfDialogue = false;
        }
    }
}