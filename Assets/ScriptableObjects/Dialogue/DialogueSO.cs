using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Dialogue")]
public class DialogueSO : ScriptableObject
{
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

    [SerializeField] TextAndSpeaker[] textAndSpeakers;
}
