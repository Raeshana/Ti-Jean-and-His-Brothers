using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButtons : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    public void Enable()
    {
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
}
