using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilController : MonoBehaviour
{
    [SerializeField] SugarcaneManager sugarcaneManager;
    [SerializeField] GameObject talk;
    [SerializeField] GameObject report;
    [SerializeField] GameObject give;

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
            talk.SetActive(false);
            report.SetActive(true);
        }

        if (sugarcaneManager.isAllCollected())
        {
            report.SetActive(false);
            give.SetActive(true);
        }
    }

    public void Talk()
    {
        Debug.Log("Go and chop down all dem sugarcane in de field boy. And when yuh done, bring it here fi me.");
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
