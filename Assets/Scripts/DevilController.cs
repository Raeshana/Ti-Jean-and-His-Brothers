using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilController : MonoBehaviour
{
    [SerializeField] SugarcaneManager sugarcaneManager;

    // Interactables
    [SerializeField] GameObject talkIntr;
    [SerializeField] GameObject reportIntr;
    [SerializeField] GameObject giveIntr;

    // Dialogue Boxes
    [SerializeField] DialogueController talkDialogue;
    [SerializeField] DialogueController reportDialogue;
    [SerializeField] DialogueController giveDialogue;

    public bool hasTalked;
    public bool hasReported;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sugarcaneManager.isAllChopped())
        {
            talkIntr.SetActive(false);
            reportIntr.SetActive(true);
        }

        if (sugarcaneManager.isAllCollected())
        {
            reportIntr.SetActive(false);
            giveIntr.SetActive(true);
        }
    }

    public void Talk()
    {
        hasTalked = true;
        talkDialogue.StartDialogue();
    }

    public void Report()
    {
        hasReported = true;
        reportDialogue.StartDialogue();
    }

    public void GiveSugarcane()
    {
        giveDialogue.StartDialogue();
    }
}
