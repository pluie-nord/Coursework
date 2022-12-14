using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue State")]
public class DialogueState : ScriptableObject
{
    public string Name;
    public string Text;
    public DialogueState NextState;
}
