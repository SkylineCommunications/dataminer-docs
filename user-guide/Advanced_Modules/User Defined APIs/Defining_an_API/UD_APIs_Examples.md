---
uid: UD_APIs_API_script_examples
---

# API script examples

This page contains some basic examples which can be used to better understand the various ways of defining API scripts. Do note that these have been simplified and do not include input validation or error handling. These scripts are functional, but are not robust enough to be used in a production environment. These can however be used as a starting point.

## Input Examples

This section contains a few API script examples of the same use case that shows you the various ways of getting input from the API trigger and what configuration is required for this. As a demonstration, this data is then used to do a parameter set on a certain element.

For all three cases, the input JSON could look like this. The difference is that this JSON is either parsed by our script, automatically parsed to a dictionary in our input or automatically parsed to automation script parameter values. You can test these examples yourself by adjusting the input to an element and parameter that exists in your DMS. Make sure that the values which will be set won't harm your setup.

```json
{
  "ElementName" : "INT-CHAIN-BRU-SAT-002",
  "ParameterName" : "State",
  "Value" : "Backup"
}
```

### OnApiTrigger method with raw body

This is the most powerful option of defining your API scripts. This gives you the most flexibility since it allows you to parse the input from any format that you like. The example uses Newtonsoft's Json.NET library to deserialize the input body, but you could use almost anything you prefer (XML, other JSON serializers, no input...).

**Configuration:**

- **API definition in Cube**: "OnApiTrigger method with argument Raw body"
- **API definition in code**:
  - Property `ActionType` should contain the default value of `AutomationScript`.
  - Property `ActionMeta` should contain an `AutomationScriptActionMeta` instance where the `ScriptName` property is filled in and the `InputType` property is set to the default value of `RawBody`.
- **Automation Script DLL References:** Since we use an external DLL to parse the JSON, we need to reference this in the Automation script by adding the path to the 'DLL references' text box in Cube. In this case, it is "C:\Skyline DataMiner\Files\Newtonsoft.Json.dll".

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
    /// Class that represents the input data which will be used to deserialize the input body JSON
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

This option makes it easier to handle basic user input since you are not required to parse the JSON data yourself. The user input (if formatted correctly as described [here](xref:UD_APIs_Define_New_API#user-input-data)) is available in an easy to use dictionary.

**Configuration:**

- **API definition in Cube**: "OnApiTrigger method with argument Dictionary (parsed from JSON)"
- **API definition in code**:
  - Property `ActionType` should contain the default value of `AutomationScript`.
  - Property `ActionMeta` should contain an `AutomationScriptActionMeta` instance where the `ScriptName` property is filled in and the `InputType` property is set to the value of `Parameters`.

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

This option makes it easy to use existing scripts as the logic for APIs. Do note that this imposes a lot of limitations.

- It is only possible to have user input via the Automation script parameters.
- It is not possible to know any other metadata of the API trigger (route, request method etc.).
- It is also not possible to provide output.

We recommend adjusting your existing scripts to add the entry point as mentioned on the [Using existing scripts](xref:UD_APIs_Using_existing_scripts#using-the-script-with-the-onapitrigger-entry-point) page.

**Configuration:**

- **API definition in Cube**: "Run method (no output)"
- **API definition in code**:
  - Property `ActionType` should contain the value of `AutomationScriptNoEntryPoint`.
  - Property `ActionMeta` should contain an `AutomationScriptNoEntryPointActionMeta` instance where the `ScriptName` property is filled in.
- **Automation script Parameter**: Since we want to pass three values to the script, there should be three script parameters configured with the same names as defined in the script. (ElementName, ParameterName & Value)

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

The `RequestMethod` and `Route` properties on the `ApiTriggerInput` can be used in your script to determine what actions should be executed. This allows you to build a single API script which can be used for multiple APIs. In the example below you can see that the script is used for two similar routes. It also only allows specific request methods depending on the route.

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

### Starting long running actions asynchronous

When you would want to trigger the execution of a long running action or script, it is recommended to execute this asynchronously and not block the HTTP trigger until the action is completed. The example below shows how you can start an asynchronous subscript in your entry point method. It will thus not be possible to return any result of this subscript since the HTTP call will immediately return after we started it.

If you would want to know whether the action is completed, you could implement a second API that polls a part of your solution which was altered by this long running action to see if the that action was finished. This could for example be the status of a DOM instance, status of a booking or a value of a parameter on a specific element. There is currently no reliable built in way of knowing whether the subscript was finished.

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
