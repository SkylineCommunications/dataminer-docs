---
uid: NT_SET_AS_CURRENT_PROTOCOL
---

# NT_SET_AS_CURRENT_PROTOCOL (55)

Sets the specified protocol as the production version.

```csharp
string protocolName = "Nevion TNS4200";
string protocolVersion = "1.0.1.1";

string[] protocolInfo = new string[2];

protocolInfo[0] = protocolName;
protocolInfo[1] = protocolVersion;

bool isProduction = true;

protocol.NotifyDataMiner(55 /*NT_SET_CURRENT_PROTOCOL*/, protocolInfo, isProduction);
```

## Parameters

- protocolInfo (string[]):
  - protocolInfo[0]: protocol name
  - protocolInfo[1]: protocol version
- isProduction (bool): true 
