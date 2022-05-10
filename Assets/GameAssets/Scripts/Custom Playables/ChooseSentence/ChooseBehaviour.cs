using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

[Serializable]
public class ChooseBehaviour : PlayableBehaviour
{
    public List<string> sentences;

    private PlayableGraph graph;
    private Playable thisPlayable;

    private GameObject inputBox;

    private bool isPaused = false;
    private bool oneFrame = false;

    public override void OnPlayableCreate(Playable playable)
    {
        graph = playable.GetGraph();
        thisPlayable = playable;
    }
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if(isPaused)return;
        Debug.Log("Choose Behauviour Pausou");
        graph.Stop();
        isPaused = true;
    }
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {   if(oneFrame)return;
        oneFrame = true;
        inputBox = playerData as GameObject;
        OptionBox optionBox = inputBox.GetComponent<OptionBox>();
        foreach(string sentence in sentences)
        {
            optionBox.AddInputSentence(sentence);
        }
    }
}
