using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public string textNumber;
    public string character;
    public string line;
    public Item(Item d)
    {
        textNumber = d.textNumber;
        character = d.character;
        line = d.line;
    }
}
