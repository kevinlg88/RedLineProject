using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    [Header("Colocar como singleton")]
    [SerializeField] private TextWitter textWitter;
    [Header("Setup")]
    [SerializeField] private string characterName;
    [SerializeField] private string sentence;
    [SerializeField] private float timer;
    private TextMeshProUGUI dialogText;
    private void Awake() {
        dialogText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        TextMeshProUGUI characterNameUI = transform.Find("Character").GetComponent<TextMeshProUGUI>();
        characterNameUI.text = characterName;
        textWitter.AddWriter(dialogText, sentence, timer);
    }
}
