---
uid: NT_TRENDING_ASSIGN_TEMPLATE
---

# NT_TRENDING_ASSIGN_TEMPLATE (14)

Assigns a trend template to an element.

```csharp
uint agentId = 400;
uint elementId = 200;
uint[] elementDetails = { agentId, elementId };
string[] trendTemplate = new string[] { "Template 1" };

protocol.NotifyDataMiner(14 /*NT_TRENDING_ASSIGN_TEMPLATE*/, elementDetails, trendTemplate);
```

## Parameters

- elementDetails (uint[]):
  - elementDetails[0]: Agent ID.
  - elementDetails[1]: Element ID.
- trendTemplate (string[]): Name of the template to assign.

## Return Value

- Does not return an object.

## Remarks

- In order to remove the trend template assignment, provide an empty string array for trendTemplate.
