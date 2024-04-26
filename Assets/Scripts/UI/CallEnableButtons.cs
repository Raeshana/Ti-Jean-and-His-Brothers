using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnableButtons : MonoBehaviour
{
    [SerializeField] DialogueController prev;
    [SerializeField] EnableButtons enableButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (prev.endOfDialogue)
        {
            prev.endOfDialogue = false; // End previous dialogue
            enableButtons.Enable(); // enable buttons
        }
    }
}
