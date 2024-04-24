using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    public enum Speaker
    {
        DEVIL = 0,
        GROSJEAN = 1,
        TIJEAN = 2
    };

    [System.Serializable]
    public struct TextandSpeaker
    {
        public string text;
        public Speaker speaker;
    };

    // Array of text and their corresponding speakers
    [SerializeField] TextandSpeaker[] textandSpeakers;

    // Portraits for each speaker
    [Tooltip("0. Devil 1. Gros Jean 2. Ti Jean")]
    [SerializeField] Sprite[] portraits;
    [SerializeField] GameObject dialoguePortrait;

    // Title for each speaker
    [SerializeField] TMP_Text title;

    // Dialogue variables
    private TMP_Text dialogue; // Dialogue box text
    [Tooltip("Speed of typing effect.")]
    [SerializeField] float textSpeed;
    private int index; // Line of dialogue

    [SerializeField] KeyCode interactKey;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log(index);

            if (dialogue.text == textandSpeakers[index].text)
            {
                NextLine();
            }
            else {
                StopAllCoroutines();
                dialogue.text = textandSpeakers[index].text;
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

        ChangeHeader(); // Change speaker header: portrait and title

        StartCoroutine(TypeText()); // Typing effect
    }

    // Change portrait and title depending on speaker
    public void ChangeHeader()
    {
        switch(textandSpeakers[index].speaker)
        {
            case Speaker.DEVIL:
                dialoguePortrait.GetComponent<Image>().sprite = portraits[0];
                title.text = "Devil";
                break;
            case Speaker.GROSJEAN:
                dialoguePortrait.GetComponent<Image>().sprite = portraits[1];
                title.text = "Gros Jean";
                break;
            case Speaker.TIJEAN:
                dialoguePortrait.GetComponent<Image>().sprite = portraits[2];
                title.text = "Ti Jean";
                break;
            default:
                break;
        }
    }

    private IEnumerator TypeText()
    {
        // Type each character individually
        string text = textandSpeakers[index].text;
        foreach(char c in text.ToCharArray())
        {
            dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < textandSpeakers.Length - 1)
        {
            index++;
            dialogue.text = string.Empty;
            
            ChangeHeader(); // Change speaker header: portrait and title

            StartCoroutine(TypeText());
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
