using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;
using System.IO;

public class SerializePythonFields : MonoBehaviour
{
    public string fileName;
    public List<float> variebalsList = new List<float>();
    public void UpdateFields()
    {
        string currentFile = Path.Combine(Application.dataPath, "Python", fileName + ".py");
    }
}
