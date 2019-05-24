using System.Collections.Generic;
using UnityEngine;
using IronPython.Hosting;

public class test : MonoBehaviour
{

    [SerializeField]
    TextAsset pythonScript;

    // Use this for initialization
    void Start()
    {
        var scriptCreator = new PythonScriptCreator(pythonScript);
        scriptCreator.CallScript();
    }

    // Update is called once per frame
    void Update()
    {

    }
}


public class PythonScriptCreator
{
    //pythonのスクリプトを文字列としてそのまま持つ
    //改行などもそのまま使える
    string script;

    Microsoft.Scripting.Hosting.ScriptEngine scriptEngine;
    Microsoft.Scripting.Hosting.ScriptScope scriptScope;
    Microsoft.Scripting.Hosting.ScriptSource scriptSource;

    public PythonScriptCreator(TextAsset PythonFile)
    {
        //TextAssetからstringに変換
        this.script = PythonFile.text;

        this.scriptEngine = Python.CreateEngine();

        scriptEngine.Runtime.LoadAssembly(typeof(GameObject).Assembly);
        this.scriptScope = scriptEngine.CreateScope();

        //stringを渡すとpythonスクリプトとして読み込んでくれる
        this.scriptSource = scriptEngine.CreateScriptSourceFromString(script);

        var log = new Log();
        log.debugLog();
        //scriptScope.SetVariable("scope", log);
        log.debugLog();
    }

    public void CallScript()
    {
        //実行
        this.scriptSource.Execute();
    }
}

public class Log
{
    public int testInt = 0;

    public void debugLog()
    {
        Debug.Log("Debug Log " + testInt);
    }
}