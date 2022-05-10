using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class ChooseClip : PlayableAsset, ITimelineClipAsset
{
    public ChooseBehaviour template = new ChooseBehaviour();
    public ClipCaps clipCaps
    {
        get{return ClipCaps.None;}
    }
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<ChooseBehaviour>.Create(graph, template);
    }
}
