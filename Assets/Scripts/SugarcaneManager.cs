using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SugarcaneManager : MonoBehaviour
{
    public int numSugarcane;
    private TMP_Text sugarcaneHUD;

    [SerializeField] GameObject sugarcaneChoppedGO;
    public int sugarcaneChopped;

    [SerializeField] GameObject sugarcaneCollGO;
    public int sugarcaneColl;

    [SerializeField] GameObject sugarcaneBurnedGO;
    public int sugarcaneBurned;

    [SerializeField] DevilController devilController;

    [SerializeField] GameObject timer;
 
    void Update()
    {
        if (devilController.hasTalked) // Talked to the Devil, enable HUD
        {
            sugarcaneChoppedGO.SetActive(true);
            timer.SetActive(true);
        }

        if (devilController.hasReported) // Reported to the Devil after chopping all sugarcane
        {
            sugarcaneChoppedGO.SetActive(false);
            sugarcaneCollGO.SetActive(true);
        }
    }

    private int incrementSugarcane(GameObject sugarcaneGO, int sugarcane, string message)
    {
        sugarcane++;
        sugarcaneHUD = sugarcaneGO.GetComponentInChildren<TMP_Text>();
        sugarcaneHUD.text = message + sugarcane + "/" + numSugarcane;
        return sugarcane;
    }
    
    private bool isAllSugarcane(int sugarcane)
    {
        if (sugarcane == numSugarcane)
        {
            return true;
        }
        return false;
    }

    public void incrementSugarcaneChopped()
    {
        sugarcaneChopped = incrementSugarcane(sugarcaneChoppedGO, sugarcaneChopped, "Sugarcane Chopped: ");
    }

    public void incrementSugarcaneColl()
    {
        sugarcaneColl = incrementSugarcane(sugarcaneCollGO, sugarcaneColl, "Sugarcane Collected: ");
    }

    public void incrementSugarcaneBurned()
    {
        sugarcaneBurned = incrementSugarcane(sugarcaneBurnedGO, sugarcaneBurned, "Sugarcane Burned: ");
    }

    public bool isAllChopped()
    {
        return (sugarcaneChopped == numSugarcane);
    }

    public bool isAllCollected()
    {
        return (sugarcaneColl == numSugarcane);
    }

    public bool isAllBurned()
    {
        return (sugarcaneBurned == numSugarcane);
    }
}
