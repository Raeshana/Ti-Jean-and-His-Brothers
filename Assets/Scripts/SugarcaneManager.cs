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

    // Start is called before the first frame update
    void Start()
    {
    }

    public void incrementSugarcaneChopped()
    {
        sugarcaneChopped++;
        sugarcaneChoppedHUD.text = "Sugarcane Chopped: " + sugarcaneChopped + "/" + numSugarcane;
    }

    public void incrementSugarcaneColl()
    {
        sugarcaneColl++;
        sugarcaneCollHUD.text = "Sugarcane Collected: " + sugarcaneColl + "/" + numSugarcane;
    }

    public void incrementSugarcaneBurned()
    {
        sugarcaneBurned++;
        sugarcaneBurnedHUD.text = "Sugarcane Burned: " + sugarcaneBurned + "/" + numSugarcane;
    }

    public bool isAllChopped()
    {
        if (sugarcaneChopped == numSugarcane)
        {
            return true;
        }
        return false;
    }

    public bool isAllCollected()
    {
        if (sugarcaneColl == numSugarcane)
        {
            return true;
        }
        return false;
    }

    public bool isAllBurned()
    {
        if (sugarcaneBurned == numSugarcane)
        {
            return true;
        }
        return false;
    }
}
