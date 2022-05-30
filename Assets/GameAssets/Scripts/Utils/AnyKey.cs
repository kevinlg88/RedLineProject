using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKey : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKeyDown)
        {
            if(TimelineManager.Instance.canSkip)
            {
                TimelineManager.Instance.TriggerInput();
            }
        }
    }
}
