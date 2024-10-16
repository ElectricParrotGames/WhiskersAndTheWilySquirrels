using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text Narrator", menuName = "TextNarrator")]
public class TextNarrator : ScriptableObject
{
    [TextArea(15, 20)]
    public string text;
    public float displayDuration;


}
