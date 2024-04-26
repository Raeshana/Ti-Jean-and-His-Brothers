using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilController : MonoBehaviour
{
    [SerializeField] SugarcaneManager sugarcaneManager;

    [Header("----------- Interactables -----------")]
    [SerializeField] GameObject talkIntr;
    [SerializeField] GameObject reportIntr;
    [SerializeField] GameObject giveIntr;

    [Header("----------- Dialogue Boxes -----------")]
    [SerializeField] DialogueController talkDialogue;
    [SerializeField] DialogueController reportDialogue;
    [SerializeField] DialogueController giveDialogue;

    [Header("----------- Flags -----------")]
    public bool hasTalked;
    public bool hasReported;

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

    [ContextMenu("Sets talk flag to true and begins talk dialogue")]
    public void Talk()
    {
        hasTalked = true;
        talkDialogue.StartDialogue();
    }

    [ContextMenu("Sets reported flag to true and begins report dialogue")]
    public void Report()
    {
        hasReported = true;
        reportDialogue.StartDialogue();
    }

    [ContextMenu("Begins give dialogue")]
    public void GiveSugarcane()
    {
        giveDialogue.StartDialogue();
    }
}
