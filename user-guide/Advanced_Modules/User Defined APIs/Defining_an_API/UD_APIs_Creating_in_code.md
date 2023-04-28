---
uid: UD_APIs_Creating_in_code
---

# Creating APIs and tokens in code

Alongside Cube, it is also possible to create API definitions and tokens in code. This can be useful if an API setup should be deployed in the install script of an application package.

## UserDefinableApiHelper

The create, read, update and delete (CRUD) actions on tokens and definitions can be done in code using the `UserDefinableApiHelper`. This class accepts a message callback and will construct the required SLNet messages to create, read, update and delete these objects.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;

public class Script
{
    public void Run(Engine engine)
    {
        // Create the helper
        var helper = new UserDefinableApiHelper(engine.SendSLNetMessages);
    }
}
```

## Creating a token

To create an API token, you can simply instantiate a new instance of the `ApiToken` class. You need to provide a name and a secret where the latter can be generated using the `ApiTokenSecretGenerator` helper class. The token can then be passed to the `Create` method on the helper. Make sure to output the generated secret somewhere so this can be used to trigger the APIs. See the [ApiToken](xref:UD_APIs_Objects_ApiToken) page for more info on the possible configuration.

```csharp
using System.IO;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;
using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

namespace UserDefinableApiScripts.CreateToken
{
    public class Script
    {
        public void Run(Engine engine)
        {
            // Setup the helper
            var helper = new UserDefinableApiHelper(engine.SendSLNetMessages);

            // Define the token
            var token = new ApiToken()
            {
                Name = "Test Token A",
                Secret = ApiTokenSecretGenerator.GenerateSecret()
            };

            // Write the secret to an accessible location on the server so we can use it when we want to trigger and API
            File.WriteAllText(@"C:\Token.txt", token.Secret);

            // Create the token
            token = helper.ApiTokens.Create(token);
        }
    }
}
```

> [!CAUTION]
> If the secret for the token is pre-determined and has to be set during creation, make sure that these hardcoded values are not part of code that is publicly available. (e.g. GitHub)

## Creating an API definition

To create an API definition, you can simply instantiate a new instance of the `ApiDefinition` class. You need to provide a route, action type and action meta alongside a collection of the token IDs that have access to this API. The definition can then be passed to the `Create` method on the helper. See the [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) page for more info on the possible configuration.

```csharp
// Define the API
var definition = new ApiDefinition()
{
    Name = "Test API One",
    Description = "This is the first test API",
    Route = "test-apis/one",
    ActionType = ActionType.AutomationScript,
    ActionMeta = new AutomationScriptActionMeta()
    {
        InputType = InputType.RawBody,
        ScriptName = "MyApiAutomationScript"
    },
    SecuritySettings = new SecuritySettings()
    {
        AllowedTokens = { token.ID }
    }
};

// Create the definition
helper.ApiDefinitions.Create(definition);
```

## Other CRUD actions

Using the helper, it is also possible to read, update and delete these objects. Below you can find examples for an API token but remember that the exact same can be done for the definitions.

```csharp
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

namespace UserDefinableApiScripts.CrudActions
{
    public class Script
    {
        public void Run(Engine engine)
        {
            // Setup the helper
            var helper = new UserDefinableApiHelper(engine.SendSLNetMessages);

            // Get the token by name
            var tokenFilter = ApiTokenExposers.Name.Equal("Test Token A");
            var token = helper.ApiTokens.Read(tokenFilter).FirstOrDefault();
            if (token == null)
            {
                engine.ExitFail("The token was not found.");
            }

            // Update the name
            token.Name = "Updated Test Token A";
            token = helper.ApiTokens.Update(token);

            // Delete the token
            helper.ApiTokens.Delete(token);
        }
    }
}
```

## Failed CRUD actions

When doing these CRUD actions with the helper, it can happen that errors are returned when something goes wrong or the data that was passed to the helper method was not fully valid. Errors coming from the validation logic will cause a `CrudFailedException` to be thrown. Other, more unexpected errors will most likely throw another type of exception. This is why it is recommended to catch these exceptions like shown below.

```csharp
using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;
using Skyline.DataMiner.Net.ManagerStore;

namespace UserDefinableApiScripts.Exceptions
{
    public class Script
    {
        public void Run(Engine engine)
        {
            // Setup the helper
            var helper = new UserDefinableApiHelper(engine.SendSLNetMessages);

            // Try to create the token
            try
            {
                var token = CreateToken(helper);
            }
            catch (CrudFailedException ce)
            {
                engine.ExitFail($"A CrudFailedException was thrown: {ce.TraceData}");
            }
            catch (Exception e)
            {
                engine.ExitFail($"An unexpected exception occurred: {e}");
            }
        }

        public ApiToken CreateToken(UserDefinableApiHelper helper)
        {
            var token = new ApiToken("Test Token") { Secret = string.Empty };
            return helper.ApiTokens.Create(token);
        }
    }
}
```

As you can see in the example, the token creation should fail because we assign an empty string as the secret. When this script is run via Cube, a pop-up and information event will contain a human-readable version of the validation error. In this case, the 'InvalidSecret' error was returned alongside the ID of the invalid token.

```text
A CrudFailedException was thrown: TraceData: (amount = 1)
  - ErrorData: (amount = 1)
      - ErrorReason: InvalidSecret, Id: ApiTokenId[60e5a541-cc35-4f3d-a1c6-c0506fc698e0],
```

These validation errors are contained in the `TraceData` property of the `CrudFailedException`. It has multiple collections, but the `ErrorData` is the most important. This collection can contain instances like `ApiTokenError` or `ApiDefinitionError`. Each of these then contains a reason and some additional metadata depending on that reason. See the 'Errors' section on the [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition#errors) and [ApiToken](xref:UD_APIs_Objects_ApiToken#errors) pages for more info on what kind of errors you can expect.

It is also possible to disable the `CrudFailedException` from being thrown and instead check for errors in the `TraceData` yourself. To do this, set the `ThrowExceptionsOnErrorData` properties to false for all helper components. Then, after a CRUD action, call the `GetTraceDataLastCall()` method on the respective helper component. You can then either check the error collection or use the existing `HasSucceeded()` method to see whether the `TraceData` contains errors.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.UserDefinableApis;

namespace UserDefinableApiScripts.NoExceptions
{
    public class Script
    {
        public void Run(Engine engine)
        {
            // Setup the helper
            var helper = new UserDefinableApiHelper(engine.SendSLNetMessages)
            {
                ApiTokens = { ThrowExceptionsOnErrorData = false },
                ApiDefinitions = { ThrowExceptionsOnErrorData = false }
            };

            // Try to create the token
            var token = new ApiToken("Test Token") { Secret = string.Empty };
            token = helper.ApiTokens.Create(token);

            // Check the TraceData
            var traceData = helper.ApiTokens.GetTraceDataLastCall();
            if (!traceData.HasSucceeded())
            {
                engine.ExitFail($"The token creation failed with errors: {traceData}");
            }
        }
    }
}
```
