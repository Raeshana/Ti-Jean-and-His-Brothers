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
 
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GetComponentInChildren<TMP_Text>();
        dialogue.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        // Type each character individually
        foreach(char c in text[index].ToCharArray())
        {
            dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
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
