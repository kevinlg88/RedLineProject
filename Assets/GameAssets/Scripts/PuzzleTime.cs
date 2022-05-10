using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTime : MonoBehaviour
{
    public GameObject puzzle;
    private void OnEnable()
    {
        puzzle.SetActive(true);
        TimelineManager.Instance.canSkip = false;
    }
}
