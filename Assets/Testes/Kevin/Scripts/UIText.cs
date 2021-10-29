using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    [SerializeField] private TextWitter textWitter;
    private TextMeshProUGUI dialogText;
    private void Awake() {
        dialogText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        textWitter.AddWriter(dialogText, "Frase de Teste!", 0.3f);
    }
}
