using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    public Sprite portrait;
    public string title;
}
