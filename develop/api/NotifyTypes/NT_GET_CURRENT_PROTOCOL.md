---
uid: NT_GET_CURRENT_PROTOCOL
---

# NT_GET_CURRENT_PROTOCOL (56)

Gets the version of the protocol that is set as production.

```csharp
string protocolName = "Nevion TNS4200";

string protocolVersion = (string) protocol.NotifyDataMiner(56 /*NT_GET_CURRENT_PROTOCOL*/, protocolName, null);
 
if(protocolVersion != null)
{
   // The value will be e.g., "1.0.1.1".
}
else
{
   // The production version of the specified protocol not found.
}
```

## Parameters

- protocolName (string): The protocol name. 

## Return Value

- (string): The version of the specified protocol that is set as production version, or null if the production version was not found.

## Remarks

- In case the production version of the specified protocol was not found, the element log file will contain the following error code: 0x80040208 (SL_PROTOCOL_FILE_NOT_FOUND).
