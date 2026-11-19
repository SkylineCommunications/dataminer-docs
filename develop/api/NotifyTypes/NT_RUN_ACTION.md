---
uid: NT_RUN_ACTION
---

# NT_RUN_ACTION (221)

Runs an action.

> [!NOTE]
> Rather than calling `NotifyProtocol(221, ...)` directly, we recommend using the `RunAction` extension method from the [Skyline.DataMiner.Utils.Protocol.Extension](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Protocol.Extension) NuGet package.

```csharp
int actionID = 1;

protocol.NotifyProtocol(221 /*NT_RUN_ACTION*/, actionID, null);
```

## Parameters

- actionID (int): ID of the action to run.

## Return Value

- Does not return an object.
