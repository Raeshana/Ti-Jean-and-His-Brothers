using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
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

    [Header("-------- Dialogue and Corresponding Speakers ---------")]
    [Tooltip("Must have at least one.")]
    [SerializeField] TextAndSpeaker[] textAndSpeakers;

    [Header("-------- Attributes ---------")]
    [SerializeField] GameObject dialoguePortrait;
    [SerializeField] TMP_Text title;

    [Header("-------- Speaker Headers: Portraits and Titles ---------")]
    [Tooltip("0. Devil 1. Player")]
    [SerializeField] SpeakerHeader[] speakerHeaders;

    [Header("-------- Dialogue Variables ---------")]
    private TMP_Text dialogue; // Dialogue box text
    [Tooltip("Speed of typing effect.")]
    [SerializeField] float textSpeed;
    private int index; // Line of dialogue
    [SerializeField] KeyCode interactKey; // Key to interact with
    public bool endOfDialogue; // If true, dialogue has ended
    [SerializeField] SFXAudioManager audioManager;
    
    void Start()
    {
        endOfDialogue = false;
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
        endOfDialogue = false;

        ChangeHeader(); // Change speaker header: portrait and title
        StartCoroutine(TypeText()); // Typing effect
    }

    // Change portrait and title depending on speaker
    // Play typing audio when character changes
    private void ChangeHeader()
    {
        switch(textAndSpeakers[index].speaker)
        {
            case Speaker.DEVIL:
                dialoguePortrait.GetComponent<Image>().sprite = speakerHeaders[0].portrait;
                title.text = speakerHeaders[0].title;
                audioManager.PlaySFX(audioManager.typing); // Play typing audio
                break;
            case Speaker.PLAYER:
                dialoguePortrait.GetComponent<Image>().sprite = speakerHeaders[1].portrait;
                title.text = speakerHeaders[1].title;
                audioManager.PlaySFX(audioManager.typing); // Play typing audio
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
    
    [ContextMenu("Set end of dialogue to true and disable")]
    public void EndDialogue()
    {
        endOfDialogue = true;
        gameObject.SetActive(false);
    }

    [ContextMenu("Set end of angry prompt to true")]
    public void EndAngryPrompt()
    {
        endOfDialogue = true;
    }

    [ContextMenu("Remove angry prompt")]
    public void RemoveAngryPrompt()
    {
        Destroy(gameObject);
    }

    private void NextLine()
    {
        if (index < textAndSpeakers.Length - 1) // Not the last line of dialogue
        {
            index++;
            dialogue.text = string.Empty;
            
            ChangeHeader(); // Change speaker header: portrait and title

            StartCoroutine(TypeText());
        }
        else if (gameObject.CompareTag("AngryPrompt")) { // Last line of dialogue, angry prompt
            EndAngryPrompt();
        }
        else { // Last line of dialogue, normal dialogue
            EndDialogue();
        }
    }
}
