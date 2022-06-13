using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WindowLoadLines : EditorWindow
{
    [MenuItem("Tools/LoadLines")]
    public static void ShowWindow()
    {
        GetWindow<WindowLoadLines>("LoadLines");
    }

    private void OnGUI()
    {
        GUILayout.Label("Reload Item Database", EditorStyles.boldLabel);
        if(GUILayout.Button("Load Lines"))
        {
            GameObject.Find("Reader").GetComponent<LoadExcel>().LoadItemData();
        }
        GUILayout.Label("Clear Item Database", EditorStyles.boldLabel);
        if(GUILayout.Button("Clear Lines"))
        {
            GameObject.Find("Reader").GetComponent<LoadExcel>().itemDatabase.Clear();
        }
    }
}
