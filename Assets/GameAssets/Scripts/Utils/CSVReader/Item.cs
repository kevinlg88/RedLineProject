using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public int textNumber;
    public string character;
    public string line;
    public Item(Item d)
    {
        textNumber = d.textNumber;
        string dataCharacter = d.character;
        character = dataCharacter != null ? dataCharacter : " ";
        string dataLine = d.line;
        line = dataLine != null ? dataLine : " ";
    }
}
