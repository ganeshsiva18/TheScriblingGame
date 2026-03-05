using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueText", menuName = "Scriptable Objects/DialogueText")]
public class DialogueText : ScriptableObject
{
    public string title;
    public string dialogue;
    public float[] pauses;
    public float waitTimeToExitDialogue;
}
