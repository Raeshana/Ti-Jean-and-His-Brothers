using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngryPrompt : MonoBehaviour
{
    [Tooltip("Dialogue box text.")]
    [SerializeField] TMP_Text dialogue;
    [Tooltip("Speed of typing effect.")]
    [SerializeField] float textSpeed;
    [SerializeField] string text;
    // [SerializeField] KeyCode interactKey; // Key to interact with

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(interactKey))
        // {
        //     if (dialogue.text != text) // Text finished being displayed
        //     {
        //         StopAllCoroutines(); // Fast forward text display (no typing effect)
        //         dialogue.text = text;
        //     }
        // }
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true); // Enable dialogue box

        // Initialize dialogue text and index
        dialogue = GetComponentInChildren<TMP_Text>();
        dialogue.text = string.Empty;

        //StartCoroutine(TypeText()); // Typing effect
    }

    public void EndDialogue()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator TypeText()
    {
        // Type each character individually
        foreach(char c in text.ToCharArray())
        {
            dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
