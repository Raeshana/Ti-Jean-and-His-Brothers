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

    // Start is called before the first frame update
    void Start()
    {
        // initialize HUD messages
        sugarcaneChoppedHUD.text = "Sugarcane Chopped: " + sugarcaneChopped + "/" + numSugarcane;
        sugarcaneCollHUD.text = "Sugarcane Collected: " + sugarcaneColl + "/" + numSugarcane;
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
}
