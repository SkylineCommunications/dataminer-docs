---
uid: SubscriptOptions_methods
---

## SubscriptOptions methods

- [GetScriptResult](#getscriptresult)

- [SelectDummy](#selectdummy)

- [SelectMemory](#selectmemory)

- [SelectScriptParam](#selectscriptparam)

- [StartScript](#startscript)

#### GetScriptResult

Returns a copy of the script output of the current script and, if the *InheritScriptOutput* option is set to "true", the child scripts. Can be used to pass information from a subscript to the parent script. <br>Available from DataMiner 9.6.8 onwards.

```txt
Dictionary<string, string> GetScriptResult()
```

#### SelectDummy

Links a dummy from the main script to a dummy from a subscript.

```txt
void SelectDummy(int dummyId, ScriptDummy dummy)
void SelectDummy(int dummyId, Element dummy)
void SelectDummy(string dummyName, ScriptDummy dummy)
void SelectDummy(string dummyName, Element dummy)
void SelectDummy(int dummyId, int dmaid, int eid)
void SelectDummy(string dummyName, int dmaid, int eid)
```

Examples:

```txt
var dummy = engine.GetDummy("myDummy");

var script = engine.PrepareSubScript("My SubScript");
script.SelectDummy(1, dummy);
script.SelectScriptParam("input", Convert.ToString(inputId));
script.SelectScriptParam("output", Convert.ToString(outputId));
script.StartScript();
```

```txt
var dummy = engine.GetDummy("myDummy");

var script = engine.PrepareSubScript("My SubScript");
script.SelectDummy("matrix", dummy);
script.SelectScriptParam("input", Convert.ToString(inputId));
script.SelectScriptParam("output", Convert.ToString(outputId));
script.StartScript();
```

```txt
var script = engine.PrepareSubScript("My SubScript");

script.SelectDummy(1, 200, 400);
script.SelectScriptParam("input", Convert.ToString(inputId));
script.SelectScriptParam("output", Convert.ToString(outputId));
script.StartScript();
```

```txt
var script = engine.PrepareSubScript("My SubScript");

script.SelectDummy("matrix", 200, 400);
script.SelectScriptParam("input", Convert.ToString(inputId));
script.SelectScriptParam("output", Convert.ToString(outputId));
script.StartScript();
```

#### SelectMemory

Selects a script memory from the main script to be used as the script memory in the subscript.

```txt
void SelectMemory(int id, ScriptMemory mem)
void SelectMemory(int id, string val)
void SelectMemory(string name, ScriptMemory mem)
void SelectMemory(string name, string val)
```

Examples:

- SelectMemory (Int32, ScriptMemory)

    Main script:

    ```txt
    var memory = engine.GetMemory("parentMemory"); // The parent script has a script memory with name "parentMemory".
    memory.Set(1, "MyValue"); // The first entry of this memory is set to the value "MyValue".

    var subscript = engine.PrepareSubScript("MySubscript");

    subscript.SelectMemory(1, memory); // The subscript has a script memory with ID 1 and this memory will be linked to the parent memory.
    subscript.StartScript();
    ```

    Subscript:

    ```txt
    var memory = engine.GetMemory(1);
    engine.GenerateInformation(Convert.ToString(memory.Get(1))); // This will generate an information event with value: "MyValue".
    ```

- SelectMemory (Int32, String)

    ```txt
    var subscript = engine.PrepareSubScript("MySybscript");
    subscript.SelectMemory(1, "file1"); // The script memory of the subscript with ID 1 will be linked to the physical memory file with name "file1".

    subscript.StartScript();
    ```

- SelectMemory(String, ScriptMemory)

    Main script:

    ```txt
    var memory = engine.GetMemory("parentMemory"); // The parent script has a script memory with name "parentMemory".
    memory.Set(1, "MyValue"); // The first entry of this memory is set to the value "MyValue".

    var subscript = engine.PrepareSubScript("MySubscript");

    subscript.SelectMemory("subscriptMemory", memory); // The subscript has a script memory with name "subscriptMemory" and this memory will be linked to the parent memory.
    subscript.StartScript();
    ```

    Subscript:

    ```txt
    var memory = engine.GetMemory("subscriptMemory");
    engine.GenerateInformation(Convert.ToString(memory.Get(1))); // This will generate an information event with value: "MyValue".
    ```

- SelectMemory(String, String)

    ```txt
    var subscript = engine.PrepareSubScript("MySubscript");
    subscript.SelectMemory("memory1", "file1"); // The script memory of the subscript with name "memory1" will be linked to the physical memory file with name "file1".

    subscript.StartScript();
    ```

#### SelectScriptParam

Links a script parameter from the main script to a script parameter from a subscript.

```txt
void SelectScriptParam(int id, ScriptParam param)
void SelectScriptParam(int id, string val)
void SelectScriptParam(string name, ScriptParam param)
void SelectScriptParam(string name, string val)
```

Examples:

- SelectScriptParam (Int32, ScriptParam)

    Parent script:

    ```txt
    var myParam = engine.GetScriptParam("parentParam");
    myParam.SetParamValue("MyValue");

    var subscript = engine.PrepareSubScript("MySybscript");

    subscript.SelectScriptParam(1, myParam);

    subscript.StartScript();
    ```

    Subscript:

    ```txt
    var myParam = engine.GetScriptParam(1);

    engine.GenerateInformation(myParam.Value); // This will generate an information event with value "MyValue".
    ```

- SelectScriptParam (Int32, String)

    ```txt
    var subscript = engine.PrepareSubScript("MySybscript");

    subscript.SelectScriptParam(1, "myValue");

    subscript.StartScript();
    ```

- SelectScriptParam (String, ScriptParam)

    Parent script:

    ```txt
    var myParam = engine.GetScriptParam("parentParam");
    myParam.SetParamValue("MyValue");

    var subscript = engine.PrepareSubScript("MySybscript");

    subscript.SelectScriptParam("subscriptParam", myParam);

    subscript.StartScript();
    ```

    Subscript:

    ```txt
    var myParam = engine.GetScriptParam("subscriptParam");

    engine.GenerateInformation(myParam.Value); // This will generate an information event with value "MyValue".
    ```

- SelectScriptParam (String, String)

    ```txt
    var subscript = engine.PrepareSubScript("MySybscript");

    subscript.SelectScriptParam("subscriptParam", "myValue");

    subscript.StartScript();
    ```

#### StartScript

Starts the subscript.

```txt
void StartScript()
```

Example:

```txt
var script = engine.PrepareSubScript("My SubScript");

script.SelectDummy("matrix", 200, 400);
script.SelectScriptParam("input", Convert.ToString(inputId));
script.SelectScriptParam("output", Convert.ToString(outputId));
script.StartScript();
```
