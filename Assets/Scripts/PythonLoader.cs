
using UnityEngine;
using System.Collections;

public class PythonLoader : MonoBehaviour
{
    void Start()
    {
        var script = Resources.Load<TextAsset>("test").text;
        var scriptEngine = IronPython.Hosting.Python.CreateEngine();
        var scriptScope = scriptEngine.CreateScope();
        var scriptSource = scriptEngine.CreateScriptSourceFromString(script);

        scriptSource.Execute(scriptScope);
    }
}