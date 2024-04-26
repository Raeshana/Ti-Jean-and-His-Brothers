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

    [SerializeField] DialogueController sugarcanePrompt;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Player can collect sugarcane after reporting to Devil
        if (devilController.hasReported) 
        {
            collect.SetActive(true); 
        }
    }

    public void ChopSugarcane()
    {
        // Chopped
        chop.SetActive(false); // Cannot chop same sugarcane more than once
        _sr.color = Color.black; // Change sugarcane sprite
        sugarcaneManager.incrementSugarcaneChopped(); // Update sugarcane chopped HUD
        
        // Start dialogue prompt after player chopped half of the sugarcane
        if (sugarcaneManager.sugarcaneChopped >= (sugarcaneManager.numSugarcane/2 - 1))
        {
            sugarcanePrompt.StartDialogue();
        }
    }

    public void CollectSugarcane()
    {
        // Collected
        Destroy(gameObject); // Remove sugarcane
        sugarcaneManager.incrementSugarcaneColl(); // Update sugarcane collected HUD

        // Start dialogue prompt after player collected half of the sugarcane
        if (sugarcaneManager.sugarcaneColl >= (sugarcaneManager.numSugarcane/2 - 1))
        {
            sugarcanePrompt.StartDialogue();; 
        }
    }

    // public void BurnSugarcane()
    // {
    //     Destroy(gameObject);
    //     dialogueController.StartDialogue(); // Start dialogue prompt
    //     sugarcaneManager.incrementSugarcaneBurned(); // Update sugarcane burned HUD
    // }
}
