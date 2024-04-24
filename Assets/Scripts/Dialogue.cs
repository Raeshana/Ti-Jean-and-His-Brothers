using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    private TMP_Text dialogue;
    [SerializeField] string[] text;
    [SerializeField] float textSpeed;
    private int index;

    [SerializeField] KeyCode interactKey;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (dialogue.text == text[index])
            {
                NextLine();
            }
            else {
                StopAllCoroutines();
                dialogue.text = text[index];
            }
        }
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);

        dialogue = GetComponentInChildren<TMP_Text>();
        dialogue.text = string.Empty;

        index = 0;
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        // Type each character individually
        foreach(char c in text[index].ToCharArray())
        {
            dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < text.Length - 1)
        {
            index++;
            dialogue.text = string.Empty;
            StartCoroutine(TypeText());
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
