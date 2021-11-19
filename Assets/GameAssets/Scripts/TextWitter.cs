using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextWitter : MonoBehaviour
{
    private static TextWitter _instance;
    public static TextWitter Instance { get { return _instance; } }

    private TextMeshProUGUI uiText;
    private string textToWrite;
    private int characterIndex = 0;
    private float timePerCharacter;
    private float timer;

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
    }
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

    private void Update() {
        if(uiText != null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);
                if(characterIndex >= textToWrite.Length)
                {
                    characterIndex = 0;
                    uiText = null;
                    return;
                }
            }
        }
    }
}
