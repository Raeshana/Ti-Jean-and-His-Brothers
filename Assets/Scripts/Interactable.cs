using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    [SerializeField] KeyCode interactKey;
    [SerializeField] UnityEvent interactAction;

    private TMP_Text _instruction;
    [SerializeField] string instructionMsg;
    [SerializeField] GameObject instructionPanel;

    void Start()
    {
        _instruction = GetComponentInChildren<TextMeshProUGUI>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (isInRange) // in range to interact
        {
            _instruction.text = instructionMsg; // makes instructions visible
            instructionPanel.SetActive(true); // makes instruction panel visible

            if (Input.GetKeyDown(interactKey)) // player presses key
            {
                interactAction.Invoke(); // fire event
            }
        }
        else{
            _instruction.text = ""; // makes instructions invisible
            instructionPanel.SetActive(false); // makes instruction panel invisible
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            //Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            //Debug.Log("Player not in range");
        }
    }
}
