using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

[Serializable]
public class DialogueTriggerBehaviour : PlayableBehaviour
{
    private int textNumber;
    private string characterName;
    private string sentence;
    public float timePerCharacter;

    private PlayableDirector director; 
    private PlayableGraph graph;
    private Playable thisPlayable;
    private TextMeshProUGUI dialogueText;

    private GameObject dialogueBox;
    private bool firstTime = false;
    private int index;
    private double timeDelay;
    private float timer;
    public override void OnPlayableCreate(Playable playable)
    {
        graph = playable.GetGraph();
        thisPlayable = playable;
        director = playable.GetGraph().GetResolver() as PlayableDirector;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        dialogueBox = playerData as GameObject;

        if(dialogueBox == null)return;
        if(!firstTime)
        {
            firstTime = true;
            index = 0;

            //Setup Sentence
            textNumber = director.gameObject.GetComponent<DialogueNumber>().textNumber;
            string dataCharacter = LoadExcel.instance.GetItem(textNumber).character;
            characterName = dataCharacter != null ? dataCharacter : " ";
            string dataLine = LoadExcel.instance.GetItem(textNumber).line;
            sentence = dataLine != null ? dataLine : " ";

            //Getting GameObjects
            dialogueText = dialogueBox.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI characterNameText = dialogueBox.transform.Find("Character")
                                                    .GetComponent<TextMeshProUGUI>();
            characterNameText.text = characterName;
            timeDelay = timePerCharacter;
            dialogueText.text = "";
        }
        WriteChar();
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if(dialogueText != null)
        {
            dialogueText.text = sentence;
        }
    }

    private void WriteChar()
    {
        if(dialogueText != null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                timer += timePerCharacter;
                index++;
                dialogueText.text = sentence.Substring(0, index);
                if(index >= sentence.Length)
                {
                    dialogueText = null;
                    return;
                }
            }
        }
    }
}
