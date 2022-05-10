using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void OnEnable()
    {
        TimelineManager.Instance.canSkip = false;
        Application.Quit();
    }
}
