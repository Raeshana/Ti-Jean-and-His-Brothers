using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    [SerializeField] KeyCode interactKey;
    [SerializeField] UnityEvent interactAction;

    // Update is called once per frame
    void Update()
    {
        if (isInRange) // in range to interact
        {
            if (Input.GetKeyDown(interactKey)) // player presses key
            {
                interactAction.Invoke(); // fire event
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player not in range");
        }
    }
}
