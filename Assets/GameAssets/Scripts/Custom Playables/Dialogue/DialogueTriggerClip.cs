using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DialogueTriggerClip : PlayableAsset, ITimelineClipAsset
{
    public DialogueTriggerBehaviour template = new DialogueTriggerBehaviour();

    public ClipCaps clipCaps
    {
        get{return ClipCaps.None;}
    }
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<DialogueTriggerBehaviour>.Create(graph, template);
    }
}
