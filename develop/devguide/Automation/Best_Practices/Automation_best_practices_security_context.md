---
uid: Automation_best_practices_security_context
description: "Best practices for using the security context and permissions of the user who runs an automation script in DataMiner."
---

# Using the security context of the user running an automation script

When an automation script performs an operation on behalf of the user who triggered it, use an API that performs the operation in that user's security context. Do not assume that every API called by an automation script uses the same account. The security context depends on the API path.

Using the user's context ensures that the operation is subject to that user's permissions. Use a system-context API only when the operation is intended to run with system permissions.

## DataMinerSystem class library

When you access DataMiner through the DataMinerSystem class library, `engine.GetDms()` uses the System account. To perform operations in the security context of the user running the script, get the DMS connection by calling `engine.GetUserConnection().GetDms()`.

## Automation API

The Automation API also uses the System account for operations such as setting a parameter with `engine.FindElement`. Information events can still show the user who triggered the script. Therefore, do not rely on information event attribution to determine which account's permissions were used for an operation.

## Direct SLNet messages

When sending a direct SLNet message, the method you use determines the security context:

- `engine.SendSLNetSingleResponseMessage` uses the user account.
- `engine.GetUserConnection().HandleSingleResponseMessage` uses the user account.
- `Engine.SLNetRaw.HandleMessage` uses the System account.

## Example: applying a parameter set

The following example applies a parameter set through different API paths and labels the security context used by each path. It assumes that the IDs and helper methods shown, including `RunPath` and `CreateSetParameterMessage`, are defined elsewhere in the script.

```cs
// 1. DataMinerSystem class library

// System account
RunPath(engine, "DataMinerSystem class library - System user", delegate
{
    IDms dms = engine.GetDms();
    IDmsElement element = dms.GetElement(new DmsElementId(DataMinerId, ElementId));
    element.GetStandaloneParameter<double?>(ParameterId).SetValue(1);
});

// User account
RunPath(engine, "DataMinerSystem class library - Running script user", delegate
{
    IDms dms = engine.GetUserConnection().GetDms();
    IDmsElement element = dms.GetElement(new DmsElementId(DataMinerId, ElementId));
    element.GetStandaloneParameter<double?>(ParameterId).SetValue(2);
});

// 2. Automation API
// Uses the System account, although information events show the user.
RunPath(engine, "Engine element", delegate
{
    engine.FindElement(DataMinerId, ElementId).SetParameter(ParameterId, 3);
});

// 3. Direct SLNet messages

// User account
RunPath(engine, "SLNet messages - via Engine", delegate
{
    engine.SendSLNetSingleResponseMessage(CreateSetParameterMessage(4));
});

// User account
RunPath(engine, "SLNet messages - via GetUserConnection", delegate
{
    engine.GetUserConnection().HandleSingleResponseMessage(CreateSetParameterMessage(5));
});

// System account
RunPath(engine, "SLNet messages - via static Engine.SLNetRaw", delegate
{
    Engine.SLNetRaw.HandleMessage(CreateSetParameterMessage(6));
});
```
