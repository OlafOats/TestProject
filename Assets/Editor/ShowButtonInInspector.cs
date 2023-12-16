using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SerializePythonFields))]
public class ShowButtonInInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SerializePythonFields serializePythonFields = (SerializePythonFields)target;

        if (GUILayout.Button("updateFields"))
        {
            serializePythonFields.UpdateFields();
        }
    }
}
