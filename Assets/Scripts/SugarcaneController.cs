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
        if (devilController.hasReported) // Reported to the Devil after chopping all sugarcane
        {
            collect.SetActive(true);
        }
    }

    public void ChopSugarcane()
    {
        chop.SetActive(false);
        _sr.color = Color.black; // Chopped
        
        // Start dialogue prompt after player chopped half of the sugarcane
        if (sugarcaneManager.sugarcaneChopped >= (sugarcaneManager.numSugarcane/2 - 1))
        {
            sugarcanePrompt.StartDialogue();
        }

        sugarcaneManager.incrementSugarcaneChopped(); // Update sugarcane chopped HUD
    }

    public void CollectSugarcane()
    {
        Destroy(gameObject); 

        // Start dialogue prompt after player collected half of the sugarcane
        if (sugarcaneManager.sugarcaneColl >= (sugarcaneManager.numSugarcane/2 - 1))
        {
            sugarcanePrompt.StartDialogue();; 
        }
        
        sugarcaneManager.incrementSugarcaneColl(); // Update sugarcane collected HUD
    }

    // public void BurnSugarcane()
    // {
    //     Destroy(gameObject);
    //     dialogueController.StartDialogue(); // Start dialogue prompt
    //     sugarcaneManager.incrementSugarcaneBurned(); // Update sugarcane burned HUD
    // }
}
