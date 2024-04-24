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
    [SerializeField] GameObject talkDialogue;
    [SerializeField] GameObject reportDialogue;
    [SerializeField] GameObject giveDialogue;

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
        talkDialogue.SetActive(true);
    }

    public void Report()
    {
        hasReported = true;
        Debug.Log("Oh? You chop all de sugarcane? Well where it? Huh? I din tell you to collect it? Well I probably forget oui! You not vex right? Go and collect de sugarcane fi me.");
    }

    public void GiveSugarcane()
    {
        Debug.Log("Sugarcane given. Dialogue prompt.");
    }
}
