---
uid: Implementing_OnRequestScriptInfo_Entry_Point
---

# Implementing the OnRequestScriptInfo entry point

From DataMiner 10.5.7/10.6.0 <!-- RN 42969 --> onwards, the [OnRequestScriptInfo](xref:Skyline.DataMiner.Automation.AutomationEntryPointType.Types.OnRequestScriptInfo) entry point can be implemented in an automation script. This will allow other Automation scripts (or any other code) to request information about the script in question.

The [example](#orchestration-script-example) below uses the entry point to find out which profile parameter values a script needs in order to orchestrate a device.

## Using the entry point

To use the entry point, add a method with the following signature to a public class in a *C# code* block of a script:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnRequestScriptInfo)]
public RequestScriptInfoOutput OnRequestScriptInfoRequest(IEngine engine, RequestScriptInfoInput inputData)
```

Both [RequestScriptInfoInput](xref:Skyline.DataMiner.Net.Automation.RequestScriptInfoInput) and [RequestScriptInfoOutput](xref:Skyline.DataMiner.Net.Automation.RequestScriptInfoOutput) have a `Data` property of type `Dictionary<string, string>`, which can be used to exchange information between the script and other code. We strongly recommend keeping the passed data below 20 MB. If larger chunks need to be passed, a reference to that information should be passed instead.

When the script info is requested, the method marked with the `AutomationEntryPoint` attribute in a *C# code* block is executed. The *C# code* block should not be marked to be compiled as a library. The method can also be defined in a base class that is inherited by a class in the *C# code* block.

> [!IMPORTANT]
> If no *C# code* block has the required `AutomationEntryPoint` attribute, the request will fail, but the script will still execute code blocks of other types.

## Arguments

If the script has any script parameters, dummies or memory files, then these are not required when executing the `OnRequestScriptInfo` entry point. However, they are required when executing the `Run` method of that same script.

If the entry point would make use of them, we recommend providing all defined arguments in the code that is executing the entry point. In case that is not possible, the following should be taken into account when an argument is used in the entry point code:

- When an omitted script parameter is used in the entry point logic, retrieving the script parameter is possible, but its value will be an empty string.
- When an omitted dummy is used in the entry point logic, retrieving the dummy is possible, but it will refer to DMA ID -1 and element ID -1. Any actions that use the dummy will fail with an exception.
- When an omitted memory file is used in the entry point logic, retrieving the memory file is possible, but it will refer to a linked file that is empty. Retrieving a value using the memory file will fail with an exception.

## Starting the entry point

To start the `OnRequestScriptInfo` entry point, you can use the below-mentioned methods. Within an automation script, the entry point should be executed as a [subscript](#subscript).

### Subscript

To execute the `OnRequestScriptInfo` entry point within Automation, you have to use the [PrepareSubScript](xref:Skyline.DataMiner.Automation.Engine.PrepareSubScript(System.String,Skyline.DataMiner.Net.Automation.RequestScriptInfoInput)) method.

In the following snippet, the entry point of the script "Script with entry point" will be started. The "Action" key with value "RequestValues" is used as input data. After the script's entry point has been executed synchronously (i.e. the default behavior), the returned output is checked for the value of the "ActionResult" key.

```csharp
var input = new RequestScriptInfoInput
{
    Data = new Dictionary<string, string>
    {
        { "Action", "RequestValues" },
    },
};

var subscriptOptions = engine.PrepareSubScript("Script with entry point", input);
subscriptOptions.StartScript();

if (subscriptOptions.Output?.Data is null ||
    !subscriptOptions.Output.Data.TryGetValue("ActionResult", out string resultKeyValue))
{
    engine.ExitFail("Expected an ActionResult in the output of the subscript.");
}
```

The `input` passed when preparing the subscript can be used to sent the data to the script. The data can be updated using the `Input` property of the options. The script should be started synchronously. It will return a subscript options object with an `Output` property containing the information returned by the script.

### ExecuteScriptMessage

The `ExecuteScriptMessage` can be used to trigger the entry point using an SLNet connection. This message should **not** be used to request the information in an automation script.

In the following snippet, the entry point of the script "Script with entry point" will be started. The "Action" key with value "RequestValues" is used as input data. After the script's entry point has been executed synchronously, the returned output is checked for the value of the "ActionResult" key.

```csharp
var input = new RequestScriptInfoInput
{
    Data = new Dictionary<string, string>
    {
        { "Action", "RequestValues" },
    },
};

var msg = new ExecuteScriptMessage
{
    ScriptName = "Script with entry point",
    Options = new SA(new[] { "DEFER:FALSE" }),
    CustomEntryPoint = new AutomationEntryPoint
    {
        EntryPointType = AutomationEntryPoint.Types.OnRequestScriptInfo,
        Parameters = new List<object> { input },
    },
};

var response = slnetConnection.HandleSingleResponseMessage(msg) as ExecuteScriptResponseMessage;
var output = response?.EntryPointResult?.Result as RequestScriptInfoOutput;

if (output?.Data is null ||
    !output.Data.TryGetValue("ActionResult", out string resultKeyValue))
{
    throw new InvalidOperationException("Expected an ActionResult in the output of the subscript.");
}
```

When an `ExecuteScriptMessage` is sent, an `ExecuteScriptResponseMessage` will be returned. The information is returned in an `EntryPointResult.Result` property of type `RequestScriptInfoOutput`.

## Orchestration script example

In this example, a library was created to implement Automation scripts that orchestrate a function of a device, resource or element. The `OnRequestScriptInfo` entry point is used to find out which values (defined as profile parameters) such a script needs in order to perform the orchestration.

The [OrchestrationHelperExample repository](https://github.com/SkylineCommunications/SLC-S-OrchestrationHelperExample) is available on GitHub.

A more detailed explanation, as well as the script flow, is available in [the project's README file](https://github.com/SkylineCommunications/SLC-S-OrchestrationHelperExample?tab=readme-ov-file#technical-documentation-for-the-orchestrationhelper-example).
