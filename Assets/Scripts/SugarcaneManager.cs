using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SugarcaneManager : MonoBehaviour
{
    public int numSugarcane;
    private TMP_Text sugarcaneHUD;

    [Header("----------- Chopped Sugarcane Variables -----------")]
    [SerializeField] GameObject sugarcaneChoppedGO;
    public int sugarcaneChopped;

    [Header("----------- Collected Sugarcane Variables -----------")]
    [SerializeField] GameObject sugarcaneCollGO;
    public int sugarcaneColl;

    // [Header("----------- Burned Sugarcane Variables -----------")]
    // [SerializeField] GameObject sugarcaneBurnedGO;
    // public int sugarcaneBurned;

    [Header("----------- Other -----------")]
    [SerializeField] DevilController devilController;
    [SerializeField] GameObject timer;
    [SerializeField] SFXAudioManager audioManager;

    void Update()
    {
        // Enable chop HUD if player talked to Devil and it isn't already enabled
        if (devilController.hasTalked && !timer.activeSelf) 
        {
            initializeSugarcane(sugarcaneChoppedGO, sugarcaneChopped, "Sugarcane Chopped: ");
            sugarcaneChoppedGO.SetActive(true);
            timer.SetActive(true);
        }

        // Enable collect HUD and disable chop HUD if player has reproted to Devil
        if (devilController.hasReported) 
        {
            initializeSugarcane(sugarcaneCollGO, sugarcaneColl, "Sugarcane Collected: ");
            sugarcaneChoppedGO.SetActive(false);
            sugarcaneCollGO.SetActive(true);
        }
    }

    // Sets default HUD message
    private void initializeSugarcane(GameObject sugarcaneGO, int sugarcane, string message)
    {
        sugarcaneHUD = sugarcaneGO.GetComponentInChildren<TMP_Text>();
        sugarcaneHUD.text = message + sugarcane + "/" + numSugarcane;
    }

    // Increments the number of sugarcane chopped/ collected/ burned
    private int incrementSugarcane(GameObject sugarcaneGO, int sugarcane, string message)
    {
        sugarcane++;
        sugarcaneHUD = sugarcaneGO.GetComponentInChildren<TMP_Text>();
        sugarcaneHUD.text = message + sugarcane + "/" + numSugarcane;
        return sugarcane;
    }
    
    // Checks if all sugarcane was chopped/ collected/ burned
    private bool isAllSugarcane(int sugarcane)
    {
        if (sugarcane == numSugarcane)
        {
            return true;
        }
        return false;
    }

    [ContextMenu("Increments the number of chopped sugarcane")]
    public void incrementSugarcaneChopped()
    {
        audioManager.PlaySFX(audioManager.chop); // Play chop audio
        sugarcaneChopped = incrementSugarcane(sugarcaneChoppedGO, sugarcaneChopped, "Sugarcane Chopped: ");
    }

    [ContextMenu("Increments the number of collected sugarcane")]
    public void incrementSugarcaneColl()
    {
        audioManager.PlaySFX(audioManager.collect); // Play collect audio
        sugarcaneColl = incrementSugarcane(sugarcaneCollGO, sugarcaneColl, "Sugarcane Collected: ");
    }

    // [ContextMenu("Increments the number of burned sugarcane")]
    // public void incrementSugarcaneBurned()
    // {
    //     sugarcaneBurned = incrementSugarcane(sugarcaneBurnedGO, sugarcaneBurned, "Sugarcane Burned: ");
    // }

    [ContextMenu("Checks if all sugarcane is chopped")]
    public bool isAllChopped()
    {
        return (sugarcaneChopped == numSugarcane);
    }

    [ContextMenu("Checks if all sugarcane is collected")]
    public bool isAllCollected()
    {
        return (sugarcaneColl == numSugarcane);
    }

    // [ContextMenu("Checks if all sugarcane is burned")]
    // public bool isAllBurned()
    // {
    //     return (sugarcaneBurned == numSugarcane);
    // }
}
