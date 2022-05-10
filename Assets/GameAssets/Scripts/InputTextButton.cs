using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputTextButton : MonoBehaviour
{
    public void Selected()
    {
        Debug.Log("Selected");
        string sentence = transform.Find("Text").GetComponent<TextMeshProUGUI>().text;
        SentenceManager.Instance.currentSentence = sentence;
    }
}
