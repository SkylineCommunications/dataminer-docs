---
uid: NT_ASSIGN_DYNAMIC_OID
---

# NT_ASSIGN_DYNAMIC_OID (248)

Assigns a dynamic OID to a parameter that will be read by a multithreaded timer.

```csharp
uint parameterID = 200;
uint groupID = 100;
uint[] info = new uint[] { parameterID, groupID };
string oid = "1.3.6.1.2.1.2.2.1.8";

protocol.NotifyProtocol(248 /*NT_ASSIGN_DYNAMIC_OID*/ , info, oid);
```

## Parameters

- info (uint[]): Array containing the parameter ID and the group ID.
  - info[0]: parameter ID
  - info[1…n]: group ID
- oid (string): The OID that needs to be set.

## Return Value

- Used in multithreaded timers.
