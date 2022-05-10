using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionBox : MonoBehaviour
{
    public GameObject inputBoxPrefab;
    private List<GameObject> inputsOptions = new List<GameObject>();
    public void AddInputSentence(string sentence)
    {
        TimelineManager.Instance.canSkip = false;
        GameObject go = Instantiate(inputBoxPrefab,this.transform);
        TextMeshProUGUI text = go.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.text = sentence;
        inputsOptions.Add(go);
    }
}
