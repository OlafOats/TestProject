using UnityEngine;
using UnityEditor.Scripting.Python;
using System.IO;

public class PythonStartOnly : MonoBehaviour
{
    public string fileName;
    void Start()
    {
        PythonRunner.RunFile(Path.Combine(Application.dataPath, "Python", fileName + ".py"));
    }
}
