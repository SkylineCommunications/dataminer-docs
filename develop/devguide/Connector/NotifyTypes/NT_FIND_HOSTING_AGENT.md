---
uid: NT_FIND_HOSTING_AGENT
---

# NT_FIND_HOSTING_AGENT (369)

Retrieves the DataMiner Agent ID of the Agent hosting the specified element.

```csharp
string elementId = "7/17599";

int agentId = (int) protocol.NotifyDataMiner(369 /* NT_FIND_HOSTING_AGENT */, elementId, null);
```

## Parameters

- elementId (string): The element ID.

## Return Value

- agentId (int): The ID of the hosting DataMiner Agent.
