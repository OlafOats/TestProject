using UnityEngine;
using UnityEditor.Scripting.Python;
using System.IO;

public class PythonUpdate : MonoBehaviour
{
    public string fileName;
    string pythonScriptPath;
    string updateCommand;

    void Start()
    {
        pythonScriptPath = Path.Combine(Application.dataPath, "Python");
        updateCommand = $"import sys\nsys.path.append(\"{pythonScriptPath}\")\nimport {fileName}\n{fileName}.Update()";
    }

    void Update()
    {
        PythonRunner.RunString(updateCommand);
    }

    void OnDestroy()
    {
        string disableCommand = $"import UnityEngine as ue\nimport sys\nif '{fileName}' in sys.modules:\n  try:\n    del sys.modules['{fileName}']\n  except Exception as e:\n    ue.Debug.Log(f'Error deleting module: {fileName}')";
        PythonRunner.RunString(disableCommand);
    }
}