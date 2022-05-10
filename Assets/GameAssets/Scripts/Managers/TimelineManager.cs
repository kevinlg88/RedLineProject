using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    private static TimelineManager _instance;
    public static TimelineManager Instance { get { return _instance; } }

    public GameObject Timelines;
    [Header("Control Variables")]
    public bool canSkip = true;
    [Header("Debug")]
    public PlayableDirector director;
    //#### Control Variables ####
    private int index = 0;
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
    private void Start() {
        index = 0;
    }
    public void TriggerInput()
    {
        if(director.state == PlayState.Playing)
        {
            director.time = director.duration;
        }
        else if(director.state == PlayState.Paused)
        {
            DeactiveTimelineBindings(FindTimelineBindings(director));

            index++;
            GameObject GO_newScene = Timelines.transform.GetChild(index).gameObject;
            director.gameObject.SetActive(false);
            GO_newScene.SetActive(true);
            director = GO_newScene.GetComponent<PlayableDirector>();
        }
    }

    private List<GameObject> FindTimelineBindings(PlayableDirector playableDirector)
    {
        if(playableDirector.playableAsset == null)return null;
        List<GameObject> bindingAssets = new List<GameObject>();
        IEnumerable<PlayableBinding> outputs = director.playableAsset.outputs;
        foreach (PlayableBinding binding in outputs)
        {
            if(binding.streamName == "Activation Track")
            {
                bindingAssets.Add(playableDirector.GetGenericBinding(binding.sourceObject) as GameObject);
            }
        }
        return bindingAssets;
    }

    private void DeactiveTimelineBindings(List<GameObject> bindingAssets)
    {
        if(bindingAssets == null)return;
        foreach (GameObject item in bindingAssets)
        {
            item.SetActive(false);
        }
    }
}
