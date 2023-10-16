/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
public class EditorButton_TransformRandom : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Transform updater = (Transform)target;

        if (GUILayout.Button("Randomise Rotation"))
        {
            updater.eulerAngles = new Vector3 (Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
        }
    }
}
*/