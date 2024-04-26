using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SugarcanePrompt : MonoBehaviour
{
    [System.Serializable]
    public enum Speaker
    {
        DEVIL = 0,
        PLAYER = 1
    };

    [System.Serializable]
    public struct TextAndSpeaker
    {
        public string text;
        public Speaker speaker;
    };

    [System.Serializable]
    public struct SpeakerHeader
    {
        public Sprite portrait;
        public string title;
    };

    // Array of text and their corresponding speakers
    [Tooltip("Dialogue and corresponding speakers. Must have at least one.")]
    [SerializeField] TextAndSpeaker[] textAndSpeakers;

    // Portraits for each speaker
    [SerializeField] GameObject dialoguePortrait;

    // Title for each speaker
    [SerializeField] TMP_Text title;

    // Speaker headers
    [Tooltip("0. Devil 1. Player")]
    [SerializeField] SpeakerHeader[] speakerHeaders;

    // Game Object for angry prompt
    [SerializeField] GameObject angryPrompt;

    // Dialogue variables
    [Tooltip("Dialogue box text.")]
    [SerializeField] TMP_Text dialogue;
    [Tooltip("Speed of typing effect.")]
    [SerializeField] float textSpeed;
    private int index; // Line of dialogue
    [SerializeField] KeyCode interactKey; // Key to interact with
    //public bool endOfDialogue; // If true, dialogue has ended

    void Start()
    {
        //endOfDialogue = false;
    }
    
    void Update()
    {
        // Checks if button for the next dialogue to be played is pressed
        if (Input.GetKeyDown(interactKey))
        {
            if (dialogue.text == textAndSpeakers[index].text) // Text finished being displayed
            {
                NextLine();
            }
            else {
                StopAllCoroutines(); // Fast forward text display (no typing effect)
                dialogue.text = textAndSpeakers[index].text;
            }
        }
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true); // Enable dialogue box

        // Initialize dialogue text and index
        dialogue = GetComponentInChildren<TMP_Text>();
        dialogue.text = string.Empty;
        index = 0;
        //endOfDialogue = false;

        ChangeHeader(); // Change speaker header: portrait and title

        StartCoroutine(TypeText()); // Typing effect
    }

    // Change portrait and title depending on speaker
    public void ChangeHeader()
    {
        switch(textAndSpeakers[index].speaker)
        {
            case Speaker.DEVIL:
                dialoguePortrait.GetComponent<Image>().sprite = speakerHeaders[0].portrait;
                title.text = speakerHeaders[0].title;
                break;
            case Speaker.PLAYER:
                dialoguePortrait.GetComponent<Image>().sprite = speakerHeaders[1].portrait;
                title.text = speakerHeaders[1].title;
                break;
            default:
                break;
        }
    }

    private IEnumerator TypeText()
    {
        // Type each character individually
        string text = textAndSpeakers[index].text;
        foreach(char c in text.ToCharArray())
        {
            dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void EndDialogue()
    {
        //endOfDialogue = true;
        gameObject.SetActive(false);
        angryPrompt.SetActive(true);
    }

    public void NextLine()
    {
        if (index < textAndSpeakers.Length - 1)
        {
            index++;
            dialogue.text = string.Empty;
            
            ChangeHeader(); // Change speaker header: portrait and title

            StartCoroutine(TypeText());
        }
        else { // Diables angry prompt
            EndDialogue();
        }
    }
}