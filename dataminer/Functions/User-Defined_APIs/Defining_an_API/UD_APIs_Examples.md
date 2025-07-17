---
uid: UD_APIs_API_script_examples
---

# API script examples

This page contains basic examples that can be used to better understand the various ways you can define API scripts.

> [!NOTE]
> These examples have been simplified and do not include input validation or error handling. While these scripts are functional, they are not robust enough to be used in a production environment. However, you can use them as a starting point to create your own scripts.

## Input examples

This section contains API script examples of the same use case, demonstrating the various ways of getting input from the API trigger and the configuration required for this. This data is then used to do a parameter set on a certain element by way of example.

For each of these examples, the input JSON could look like this:

```json
{
  "ElementName" : "INT-CHAIN-BRU-SAT-002",
  "ParameterName" : "State",
  "Value" : "Backup"
}
```

The difference is that this JSON is either parsed by the script, automatically parsed to a dictionary in the input, or automatically parsed to Automation script parameter values.

You can test these examples yourself by adjusting the input to an element and parameter that exist in your DMS. However, make sure that the values that will be set will not harm your setup.

### OnApiTrigger method with raw body

This is the most powerful way of defining API scripts. It provides the most flexibility, as it allows you to parse the input from any format you like. The example uses Newtonsoft's Json.NET library to deserialize the input body, but you could use almost anything you prefer (XML, other JSON serializers, no input, etc.).

**Configuration:**

- **API definition in Cube**: Select the method *OnApiTrigger method with argument Raw body*.
- **API definition in code**:
  - Property `ActionType` should contain the default value [AutomationScript](xref:UD_APIs_Objects_ApiDefinition#automationscript).
  - Property `ActionMeta` should contain an `AutomationScriptActionMeta` instance with the `ScriptName` property filled in and the `InputType` property set to the default value `RawBody`.
- **Automation script DLL references:** As an external DLL is used to parse the JSON, when you configure the Automation script in Cube, expand the *Advanced* section at the bottom of the C# block and add the path to the DLL in the *DLL references* box. In this case, this is `C:\Skyline DataMiner\Files\Newtonsoft.Json.dll`.

**Example:**

```csharp
using Newtonsoft.Json;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;

namespace UserDefinableApiScripts.Examples.OnApiTriggerWithRawBody
{
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            var data = JsonConvert.DeserializeObject<InputData>(requestData.RawBody);

            var chain = engine.FindElement(data.ElementName);
            chain.SetParameter(data.ParameterName, data.Value);

            return new ApiTriggerOutput
            {
                ResponseBody = $"Parameter '{data.ParameterName}' of element '{data.ElementName}' has been set to '{data.Value}'",
                ResponseCode = (int) StatusCode.Ok,
            };
        }
    }

    /// <summary>
    /// Class that represents the input data that will be used to deserialize the input body JSON
    /// </summary>
    public class InputData
    {
        public string ElementName { get; set; }

        public string ParameterName { get; set; }

        public string Value { get; set; }
    }
}
```

### OnApiTrigger method with dictionary parsing from JSON

With this approach, it is easier to handle basic user input, as you do not need to parse the JSON data yourself. The user input (if formatted correctly as described under [User input data](xref:UD_APIs_Define_New_API#user-input-data)) is available in an easy-to-use dictionary.

**Configuration:**

- **API definition in Cube**: Select the method *OnApiTrigger method with argument Dictionary (parsed from JSON)*.
- **API definition in code**:
  - Property `ActionType` should contain the default value of `AutomationScript`.
  - Property `ActionMeta` should contain an `AutomationScriptActionMeta` instance with the `ScriptName` property filled in and the `InputType` property set to the value of `Parameters`.

**Example:**

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;

namespace UserDefinableApiScripts.Examples.OnApiTriggerWithDictionaryParsing
{
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            var elementName = requestData.Parameters["ElementName"];
            var parameterName = requestData.Parameters["ParameterName"];
            var value = requestData.Parameters["Value"];

            var chain = engine.FindElement(elementName);
            chain.SetParameter(parameterName, value);

            return new ApiTriggerOutput
            {
                ResponseBody = $"Parameter '{parameterName}' of element '{elementName}' has been set to '{value}'",
                ResponseCode = (int)StatusCode.Ok,
            };
        }
    }
}
```

### Run method

While this approach makes it easy to use existing scripts as the logic for APIs, it does have several limitations:

- It is only possible to have user input via the Automation script parameters.
- It is not possible to know any other metadata of the API trigger (route, request method, etc.).
- It is not possible to provide output.

> [!NOTE]
> To avoid these limitations, we recommend adjusting your existing scripts to add the entry point instead. See [Using existing scripts](xref:UD_APIs_Using_existing_scripts#using-the-script-with-the-onapitrigger-entry-point).

**Configuration:**

- **API definition in Cube**: Select the method *Run method (no output)*.
- **API definition in code**:
  - Property `ActionType` should contain the value of `AutomationScriptNoEntryPoint`.
  - Property `ActionMeta` should contain an `AutomationScriptNoEntryPointActionMeta` instance where the `ScriptName` property is filled in.
- **Automation script parameter**: As three values should be passed to the script in this example, the script must be configured to have three script parameters with the correct names (in this case *ElementName*, *ParameterName*, and *Value*).

**Example:**

```csharp
using Skyline.DataMiner.Automation;

namespace UserDefinableApiScripts.Examples.RunMethod
{
    public class Script
    {
        public void Run(Engine engine)
        {
            var elementName = engine.GetScriptParam("ElementName").Value;
            var parameterName = engine.GetScriptParam("ParameterName").Value;
            var value = engine.GetScriptParam("Value").Value;

            var chain = engine.FindElement(elementName);
            chain.SetParameter(parameterName, value);
        }
    }
}
```

## Other examples

### Using the RequestMethod and Route

You can use the `RequestMethod` and `Route` properties on the `ApiTriggerInput` in your script to determine which actions should be executed. This allows you to build a single API script that can be used for multiple APIs.

In the example below, you can see that the script is used for two similar routes. It also only allows specific request methods depending on the route.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;

namespace UserDefinableApiScripts.Examples.RequestMethodAndRoute
{
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            switch (requestData.Route)
            {
                case "chains/change-status":
                    return HandleStateChangeRequest(requestData);

                case "chains/status":
                    return HandleStateRetrievalRequests(requestData);
            }

            return new ApiTriggerOutput
            {
                ResponseCode = (int) StatusCode.NotFound
            };
        }

        private ApiTriggerOutput HandleStateChangeRequest(ApiTriggerInput requestData)
        {
            if (requestData.RequestMethod != RequestMethod.Post)
            {
                return new ApiTriggerOutput
                {
                    ResponseCode = (int) StatusCode.MethodNotAllowed // We only allow POST
                };
            }

            // Handle request...
        }

        private ApiTriggerOutput HandleStateRetrievalRequests(ApiTriggerInput requestData)
        {
            // Handle request...
        }
    }
}
```

### Starting long-running actions asynchronously

When you trigger the execution of a long-running action or script, we recommend executing this asynchronously and not blocking the HTTP trigger until the action is completed. The example below shows how you can start an asynchronous subscript in your entry point method.

As the HTTP call will immediately return after it is started, it will not be possible to return any result of this subscript. If you want to know whether the action is completed, you can implement a second API that polls a part of your solution that is altered by this long-running action to see if that action is finished. This could for example be the status of a DOM instance, the status of a booking, or a value of a parameter of a specific element. There is currently no reliable built-in way of knowing whether the subscript is finished.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;

namespace UserDefinableApiScripts.Examples.LongRunningScripts
{
    public class Script
    {
        private const string ScriptName = "NameOfLongRunningScript";

        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            var subscript = engine.PrepareSubScript(ScriptName);
            subscript.Synchronous = false;
            subscript.StartScript();

            return new ApiTriggerOutput()
            {
                ResponseBody = "The long running action was started...",
                ResponseCode = (int) StatusCode.Accepted
            };
        }
    }
}
```
