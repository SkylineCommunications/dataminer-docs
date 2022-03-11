---
uid: NT_ASSIGN_ALARM_TEMPLATE
---

# NT_ASSIGN_ALARM_TEMPLATE (117)

Assigns an alarm template to an element.

```csharp
uint agentId = 7004;
uint elementId = 267;
uint[] elementDetails = { agentId, elementId };
string[] alarmTemplate = new string[] { "Alarm Template 1" };

protocol.NotifyDataMiner(117/*NT_ASSIGN_ALARM_TEMPLATE*/, elementDetails, alarmTemplate);
```

## Parameters

- elementDetails (uint[]):
  - elementDetails[0]: Agent ID of the element.
  - elementDetails[1]: ID of the element.
- alarmTemplate (string[]): Name of the alarm template to assign.

## Return Value

- Does not return an object.

## Remarks

- In order to remove the alarm template assignment, provide an empty alarmTemplate string array.
