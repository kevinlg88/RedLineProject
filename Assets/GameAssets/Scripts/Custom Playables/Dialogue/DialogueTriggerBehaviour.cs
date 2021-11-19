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
    public string characterName;
    public string sentence;
    public float timePerCharacter;

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
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        dialogueBox = playerData as GameObject;

        if(dialogueBox == null)return;
        if(!firstTime)
        {
            firstTime = true;
            index = 0;
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
