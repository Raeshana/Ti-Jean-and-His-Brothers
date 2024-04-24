using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarcaneController : MonoBehaviour
{
    [SerializeField] GameObject chop;
    [SerializeField] GameObject collect;
    private SpriteRenderer _sr;

    [SerializeField] SugarcaneManager sugarcaneManager;
    [SerializeField] DevilController devilController;

    [SerializeField] DialogueController dialogueController;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (devilController.hasReported) // reported to the Devil after chopping all sugarcane
        {
            collect.SetActive(true);
        }
    }

    public void ChopSugarcane()
    {
        _sr.color = Color.black; // chopped
        dialogueController.StartDialogue();

        chop.SetActive(false);

        // update sugarcane chopped HUD
        sugarcaneManager.incrementSugarcaneChopped();
    }

    public void CollectSugarcane()
    {
        Destroy(gameObject);
        dialogueController.StartDialogue();

        // update sugarcane collected HUD
        sugarcaneManager.incrementSugarcaneColl();
    }

    public void BurnSugarcane()
    {
        Destroy(gameObject);
        dialogueController.StartDialogue();

        // update sugarcane burned HUD
        sugarcaneManager.incrementSugarcaneBurned();
    }
}
