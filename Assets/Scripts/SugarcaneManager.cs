using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SugarcaneManager : MonoBehaviour
{
    [SerializeField] int numSugarcane;
    private TMP_Text sugarcaneHUD;

    [SerializeField] GameObject sugarcaneChoppedGO;
    private int sugarcaneChopped;

    [SerializeField] GameObject sugarcaneCollGO;
    private int sugarcaneColl;

    [SerializeField] GameObject sugarcaneBurnedGO;
    private int sugarcaneBurned;

    [SerializeField] DevilController devilController;

    void Update()
    {
        if (devilController.hasReported) // reported to the Devil after chopping all sugarcane
        {
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
        return isAllSugarcane(sugarcaneChopped);
    }

    public bool isAllCollected()
    {
        return isAllSugarcane(sugarcaneColl);
    }

    public bool isAllBurned()
    {
        return isAllSugarcane(sugarcaneBurned);
    }
}
