---
uid: NT_UPDATE_DESCRIPTION_XML
---

# NT_UPDATE_DESCRIPTION_XML (127)

Adjusts parameter settings at runtime.<!-- RN 4938 -->

```csharp
uint agentId = 400;
uint elementId = 200;
uint[] elementDetails = new uint[] { agentId, elementId };
string[] update1 = new string[] { "1", "Main Device A", "10"};
string[] update2 = new string[] { "1", "Backup Device A", "14" };
object[] updates = new object[] { update1, update2 };

int result = (int) protocol.NotifyDataMinerQueued(127/*NT_UPDATE_DESCRIPTION_XML */ , elementDetails, updates);
```

## Parameters

- elementDetails (uint[]):
  - elementDetails[0]: agent ID
  - elementDetails[1]: element ID
- updates (object[]): Array containing a string array for every update that needs to be performed.
  - update[0] (string): Update type: 1 = Description, 2 = Unit, 3 = Range low, 4 = Range high, 5 = Step size.
  - update[1] (string): Updated value.
  - update[2] (string): ID of the parameter this update applies to.

## Return Value

- (int): 0 indicates the method call succeeded.

## Remarks

- Use NotifyDataMinerQueued in case a parameter of the element executing this call must be performed.
- Editing the units (Update type 2) is possible from DataMiner 10.2.5/10.3.0 (RN 32891) onwards.
