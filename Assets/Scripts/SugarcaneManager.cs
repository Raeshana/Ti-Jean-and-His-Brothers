using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SugarcaneManager : MonoBehaviour
{
    [SerializeField] int numSugarcane;

    [SerializeField] TMP_Text sugarcaneChoppedHUD;
    private int sugarcaneChopped;

    [SerializeField] TMP_Text sugarcaneCollHUD;
    private int sugarcaneColl;

    [SerializeField] TMP_Text sugarcaneBurnedHUD;
    private int sugarcaneBurned;

    private int incrementSugarcane(int sugarcane, TMP_Text sugarcaneHUD, string message)
    {
        sugarcane++;
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
        sugarcaneChopped = incrementSugarcane(sugarcaneChopped, sugarcaneChoppedHUD, "Sugarcane Chopped: ");
    }

    public void incrementSugarcaneColl()
    {
        sugarcaneColl = incrementSugarcane(sugarcaneColl, sugarcaneCollHUD, "Sugarcane Collected: ");
    }

    public void incrementSugarcaneBurned()
    {
        sugarcaneBurned = incrementSugarcane(sugarcaneBurned, sugarcaneBurnedHUD, "Sugarcane Burned: ");
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
