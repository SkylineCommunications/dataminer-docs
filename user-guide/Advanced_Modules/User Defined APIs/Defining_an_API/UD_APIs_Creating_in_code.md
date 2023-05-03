---
uid: UD_APIs_Creating_in_code
---

# Creating APIs and tokens in code

Instead of creating API definitions and tokens in Cube, you can also create them in code, using the [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) and [ApiToken](xref:UD_APIs_Objects_ApiToken) classes available in the SLNetTypes.dll. This can for example be useful if an API setup needs to be deployed in the install script of an application package.

## UserDefinableApiHelper

The create, read, update, and delete (CRUD) actions on tokens and definitions can be done in code using the `UserDefinableApiHelper`. This class accepts a message callback and will construct the required SLNet messages to create, read, update, and delete these objects.

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

To create an API token, instantiate a new instance of the `ApiToken` class.

You will need to provide a name and a secret. The secret can be generated using the `ApiTokenSecretGenerator` helper class.

The token can then be passed to the `Create` method of the helper. Make sure to output the generated secret somewhere so this can be used to trigger the APIs.

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
> If the secret for the token is pre-determined and has to be set during creation, make sure that these hard-coded values are not part of code that is publicly available (e.g. on GitHub).

> [!TIP]
> For more information on the token configuration, see [ApiToken object](xref:UD_APIs_Objects_ApiToken).

## Creating an API definition

To create an API definition, instantiate a new instance of the `ApiDefinition` class.

You will need to provide a route, action type, and action meta alongside a collection of the token IDs that have access to this API.

The definition can then be passed to the `Create` method of the helper.

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

> [!TIP]
> For more information on the API definition configuration, see [ApiDefinition object](xref:UD_APIs_Objects_ApiDefinition).

## Doing other CRUD actions

Using the helper, you can also read, update, and delete these objects.

Below, you can find examples for an API token. For a definition, you can do this in the same way.

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

## Handling failed CRUD actions

When something goes wrong during the CRUD actions, or when the data that was passed to a helper method was not fully valid, errors can be returned.

Errors that result from the validation logic will cause a `CrudFailedException` to be thrown. Other, more unexpected errors will most likely throw another type of exception. Because of this, we recommend catching these exceptions as shown in the example below.

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

In this example, the token creation will fail because an empty string was assigned as the secret. When this script is run via Cube, a pop-up message and information event will contain a human-readable version of the validation error. In this case, the *InvalidSecret* error is returned alongside the ID of the invalid token.

```txt
A CrudFailedException was thrown: TraceData: (amount = 1)
  - ErrorData: (amount = 1)
      - ErrorReason: InvalidSecret, Id: ApiTokenId[60e5a541-cc35-4f3d-a1c6-c0506fc698e0],
```

These validation errors are contained in the `TraceData` property of the `CrudFailedException`. It has multiple collections, but the `ErrorData` is the most important. This collection can contain instances like `ApiTokenError` or `ApiDefinitionError`. Each of these then contains a reason and some additional metadata depending on that reason. For more information on the kind of errors you can expect, refer to [ApiDefinition errors](xref:UD_APIs_Objects_ApiDefinition#errors) and [ApiToken errors](xref:UD_APIs_Objects_ApiToken#errors).

You can also prevent the `CrudFailedException` from being thrown and instead check for errors in the `TraceData` yourself. To do so, set the `ThrowExceptionsOnErrorData` properties to false for all helper components. Then, after a CRUD action, call the `GetTraceDataLastCall()` method on the respective helper component. You can then either check the error collection or use the existing `HasSucceeded()` method to see whether the `TraceData` contains errors.

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
