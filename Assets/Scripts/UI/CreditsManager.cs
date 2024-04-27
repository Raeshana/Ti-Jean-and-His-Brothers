using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] GameObject[] credits;
    [SerializeField] Button next;
    [SerializeField] Button back;
    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    void Update()
    {
        // Disable next button if credits is on last page
        if (index == (credits.Length - 1))
        {
            next.gameObject.SetActive(false);
        } 
        else {
            next.gameObject.SetActive(true);
        }

        // Disable back button if credits is on first page
        if (index == 0)
        {
            back.gameObject.SetActive(false);
        } 
        else {
            back.gameObject.SetActive(true);
        }
    }

    public void NextCredits()
    {
        credits[index].SetActive(false);
        index++;
        credits[index].SetActive(true);
    }

    public void BackCredits()
    {
        credits[index].SetActive(false);
        index--;
        credits[index].SetActive(true);
    }
}
