---
uid: UD_APIs_Using_existing_scripts
---

# Using existing scripts

> [!WARNING]
> The current feature is in preview and is not fully released yet. This feature should not be used in any staging or production environment.

If you want to create an API from an existing automation script that may or may not use script parameters, we provide two ways of defining it.

Imagine we have the following existing script that uses script parameters to pass along the DMA ID and Element ID to stop an element.

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

## Option 1: Using the script without the OnApiTrigger entrypoint

To use the above script as an API without doing any changes to it is possible, API triggers will be executed through the `Run` method as if you were executing the script from e.g. Cube. To do this, define your API exactly as explained on the [defining an API page](xref:UD_APIs_Define_New_API#2-creating-the-apidefinitions), but select the `Run` method option as 'Method to be executed'.

Using this method comes with some disadvantages, note that you do not have access to the `ApiTriggerInput` object and `ApiTriggerOutput` object in the script, meaning you cannot check the route or request method of the API trigger or output specific errors.

When the API is triggered with valid input data, the script will succeed and an empty HTTP response will be returned with status code 200. This is an example of a valid input body for the trigger.

```json
{
    "DMAID" : "837",
    "ELEMENTID" : "154"
}
```

When the API is triggered with input data that does not represent a number, the conversion in the script will fail and trigger the 'ExitFail' method. This causes the script to fail which will result in an [HTTP response](xref:UD_APIs_Triggering_an_API#errors) like this with status code 500:

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

As you can see, since we do not have a way of returning an `ApiTriggerOutput` instance, the error will be vague. This is why we always recommend spending the little extra time to use the 'OnApiTrigger' entrypoint. (See next option)

## Option 2: Using the script with the OnApiTrigger entrypoint

The second option is to define an API the same way as a new API. Instead of creating a new script, you will have to add the `OnApiTrigger` entrypoint method to your existing script, and possibly refactor some things so it can do the same logic as it would in the `Run` method. How the entrypoint method should look like can be found in the [defining an API page](xref:UD_APIs_Define_New_API#1-creating-the-api-automation-script). You can use the `ApiTriggerInput` 'RawBody' or 'Parameters' properties instead of the script parameters.

> [!NOTE]
> - With this option, the MissingScriptParameters error will not be returned if there are missing script parameters. The responsibility to verify the parameters is completely for the script.
> - You can keep the script parameters on your script, as executing the automation script as an API through the OnApiTrigger entrypoint method, will ignore the script parameters.
> - If the `Run` method remains in the script, it is still possible to trigger the script via Cube or any other supported DataMiner module. (Scheduler, Correlation, ...)

We have applied this option to the example script which results in the script below. We have:
- Added the 'OnApiTrigger' method with the 'AutomationEntryPoint' attribute.
- Split of the actual script behavior (stopping an element) to a separate method.
- Added a call to this separate method in both the entrypoint method and the normal `Run` method.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;
using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

namespace UDAPIS_Example
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

Basically both the `Run` method and the entrypoint method do the same thing, they validate the input parameters and execute the `InnerRun` method that stops the element. The difference is that the `Run` method uses the script parameters, and the entrypoint method uses the Parameters from the `ApiTriggerInput`. Another big difference is that with the entrypoint method, we can return specific errors and success messages to the API users.
