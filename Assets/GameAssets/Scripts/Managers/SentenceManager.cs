using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceManager : MonoBehaviour
{
    private static SentenceManager _instance;
    public static SentenceManager Instance { get { return _instance; } }
    // Start is called before the first frame update

    public string currentSentence {
        get
        {
            return currentSentence;
        }
        set
        {
            sentence = value;
            HidePanelInputBox();
        }
    }
    
    [SerializeField]private string sentence;
    private void Awake() 
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            _instance = this;
        }
    }
    public void HidePanelInputBox()
    {
        Debug.Log("HidePanel");
        TimelineManager.Instance.canSkip = true;
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject currentChild = transform.GetChild(i).gameObject;
            currentChild.SetActive(false);
            int optionBoxCount = currentChild.transform.childCount;
            for(int j=0; j < optionBoxCount; j++)
            {
                GameObject child = currentChild.transform.GetChild(j).gameObject;
                Destroy(child);
            }
        }
    }
}
