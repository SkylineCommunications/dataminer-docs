---
uid: NT_DELETE_SERVICE
---

# NT_DELETE_SERVICE (74)

Removes a service.

```csharp
string serviceName = "Service A";

protocol.NotifyDataMiner(74 /*NT_DELETE_SERVICE*/ , serviceName, null);
```

or

```csharp
uint agentId = 346;
uint serviceId = 530253;
uint[] serviceDetails = new uint[] { agentId, serviceId };

protocol.NotifyDataMiner(74 /*NT_DELETE_SERVICE*/ , serviceDetails, null);
```

## Parameters

- serviceName (string): Name of the service to remove.

or

serviceDetails (uint[]):

- serviceDetails[0]: Agent ID of the service
- serviceDetails[1]: Service ID

## Return Value

- Does not return an object.

## Remarks

- You can use this call to delete services in a cluster on a remote DMA.<!-- RN 10032 -->
