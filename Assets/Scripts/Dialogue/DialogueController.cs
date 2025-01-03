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
        PLANTER,
        DEVIL,
        GROSJEAN,
        MIJEAN,
        TIJEAN
    };

    [System.Serializable]
    public struct TextAndSpeaker
    {
        public string text;
        public Speaker speaker;
    };

    [Header("-------- Dialogue and Corresponding Speakers ---------")]
    [Tooltip("Must have at least one.")]
    [SerializeField] TextAndSpeaker[] textAndSpeakers;

    [Header("-------- Attributes ---------")]
    [SerializeField] GameObject dialoguePortrait;
    [SerializeField] TMP_Text title;

    [Header("-------- Speaker Headers: Portraits and Titles ---------")]
    [SerializeField] CharacterManager characterManager;

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
        audioManager.PlaySFX(audioManager.typing); // Play typing audio

        switch(textAndSpeakers[index].speaker)
        {
            case Speaker.PLANTER:
                dialoguePortrait.GetComponent<Image>().sprite = characterManager.PlanterSO.portrait;
                title.text = characterManager.PlanterSO.title;
                break;
            case Speaker.DEVIL:
                dialoguePortrait.GetComponent<Image>().sprite = characterManager.DevilSO.portrait;
                title.text = characterManager.DevilSO.title;
                break;
            case Speaker.GROSJEAN:
                dialoguePortrait.GetComponent<Image>().sprite = characterManager.GrosJeanSO.portrait;
                title.text = characterManager.GrosJeanSO.title;
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
