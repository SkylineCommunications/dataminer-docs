---
uid: UD_APIs_Using_existing_scripts
---

# Using existing scripts

There are two possible ways to create an API from an existing Automation script, which may or may not use script parameters.

- The recommended way is to [use the OnApiTrigger entry point](#using-the-script-with-the-onapitrigger-entry-point).
- Alternatively, you can also [use an existing script without the OnApiTrigger entry point](#using-the-script-without-the-onapitrigger-entry-point). However, while this has the advantage that you do not need to make changes to the script, this also has some major disadvantages.

## Example script

To illustrate how you can use an existing script, we will start from this example script. It uses script parameters to pass along the DMA ID and element ID to stop an element.

```csharp
using Skyline.DataMiner.Automation;

namespace UDAPIS_Example
{
    public class Script
    {
        public void Run(Engine engine)
        {
            var dmaIdParam = engine.GetScriptParam("DMAID").Value;
            var elementIdParam = engine.GetScriptParam("ELEMENTID").Value;

            if (!int.TryParse(dmaIdParam, out var dmaId))
            {
                engine.ExitFail("Failed to parse DMA ID");
                return;
            }

            if (!int.TryParse(elementIdParam, out var elementId))
            {
                engine.ExitFail("Failed to parse element ID");
                return;
            }

            var element = engine.FindElement(dmaId, elementId);
            element.Stop();
        }
    }
}
```

## Using the script with the OnApiTrigger entry point

The **preferred way of using an existing script** to define an API is similar to how you [create a new API](xref:UD_APIs_Define_New_API). To do so, you will need to implement some changes in your script:

- Add the `OnApiTrigger` entry point method.
- If necessary, refactor the script to make sure that it can use the same logic as it would with the `Run` method.
- Use the `RawBody` or `Parameters` properties of the `ApiTriggerInput` object instead of the script parameters.

For detailed info, refer to [Defining a new API](xref:UD_APIs_Define_New_API).

> [!NOTE]
>
> - If there are missing script parameters, the *MissingScriptParameters* error will not be returned. You will need to make sure the script verifies the parameters.
> - You can keep the existing script parameters of your script, as these will be ignored when the Automation script is executed as an API through the `OnApiTrigger` entry point method.
> - If the `Run` method stays in the script, it will still be possible to trigger the script via Cube or any other supported DataMiner module (Scheduler, Correlation, etc.).

To prepare the [example script](#example-script) so it can be used to handle API triggers, the following changes are needed:

- Add the `OnApiTrigger` method with the `AutomationEntryPoint` attribute.
- Move the actual script behavior (stopping an element) to a separate method.
- Add a call to this separate method in both the entry point method and the normal `Run` method.

This results in the script below, where the `Run` method and the entry point method both validate the input parameters and execute the `InnerRun` method that stops the element. However, the `Run` method uses the script parameters, while the entry point method uses the `Parameters` property from the `ApiTriggerInput`. Note also that with the entry point method, specific errors and success messages can be returned to the API users.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;
using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

namespace UserDefinableApiScripts.Examples.ExistingWithEntryPoint
{
    public class Script
    {
        
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            // Retrieve the values for the input parameters from the parsed API trigger request body.
            requestData.Parameters.TryGetValue("DMAID", out var dmaIdParam);
            requestData.Parameters.TryGetValue("ELEMENTID", out var elementIdParam);

            // Convert the string values to int.
            if (!int.TryParse(dmaIdParam, out var dmaId))
            {
                return new ApiTriggerOutput()
                {
                    ResponseBody = "Could not parse 'DMAID' parameter to int.",
                    ResponseCode = (int) StatusCode.BadRequest
                };
            }

            if (!int.TryParse(elementIdParam, out var elementId))
            {
                return new ApiTriggerOutput()
                {
                    ResponseBody = "Could not parse 'ELEMENTID' parameter to int.",
                    ResponseCode = (int) StatusCode.BadRequest
                };
            }

            // Call the InnerRun method with our input.
            InnerRun(engine as Engine, dmaId, elementId);

            return new ApiTriggerOutput()
            {
                ResponseBody = "Successfully stopped element",
                ResponseCode = (int) StatusCode.Ok
            };
        }

        public void Run(Engine engine)
        {
            var dmaId = engine.GetScriptParam("DMAID").Value;
            var elementId = engine.GetScriptParam("ELEMENTID").Value;

            if (!int.TryParse(dmaId, out var parsedDmaId))
            {
                engine.ExitFail("Failed to parse DMA ID");
                return;
            }

            if (!int.TryParse(elementId, out var parsedElementId))
            {
                engine.ExitFail("Failed to parse element ID");
                return;
            }

            InnerRun(engine, parsedDmaId, parsedElementId);
        }

        private void InnerRun(Engine engine, int dmaId, int elementId)
        {
            var element = engine.FindElement(dmaId, elementId);
            element?.Stop();
        }
    }
}
```

## Using the script without the OnApiTrigger entry point

It is possible to use a script such as the [example script](#example-script) as an API without making any changes to it. API triggers will be executed through the `Run` method as if you were executing the script from e.g. Cube.

To do this, define your API exactly as explained under [Creating an API and tokens](xref:UD_APIs_Define_New_API#creating-an-api-and-tokens-in-dataminer-automation), but next to *Method to be executed*, select *Run method*.

> [!IMPORTANT]
> If you use this approach, you will not have access to the `ApiTriggerInput` object and `ApiTriggerOutput` object in the script, and it will therefore not be possible to check the route or the request method, or to output anything back to the API caller.

When the API is triggered with valid input data, the script will succeed, and an empty HTTP response will be returned with status code 200. This is an example of a valid input body for the trigger:

```json
{
    "DMAID" : "837",
    "ELEMENTID" : "154"
}
```

When the API is triggered with input data that does not represent a number, the conversion in the script will fail and trigger the *ExitFail* method. This causes the script to fail, which will result in an [HTTP response](xref:UD_APIs_Triggering_an_API#errors) like this with status code 500:

```json
{
    "errors": [
        {
            "title": "Error occurred while handling the request, contact your admin with the provided errorCode and faultingNode ID.",
            "detail": "Something went wrong, contact the system administrator.",
            "errorCode": 8,
            "faultingNode": 837
        }
    ]
}
```

As there is no way of returning an `ApiTriggerOutput` instance with this approach, the error will be vague.

The input value conversion logic will return a clear error if an API configured with this option is triggered, but the input JSON does not contain a value for all Automation script parameters. The JSON error response will look like this:

```json
{
    "errors": [
        {
            "title": "Error occurred while handling the request, contact your admin with the provided errorCode and faultingNode ID.",
            "detail": "The request body is missing script parameters.",
            "errorCode": 16,
            "faultingNode": 686,
            "missingScriptParameters": [
                "ElementName",
                "Value"
            ]
        }
    ]
}
```
