---
uid: NT_GET_CAPABILITIES
---

# NT_GET_CAPABILITIES (322)

Retrieves the defined Notify Types and provides some information about the expected format and content of the parameter values for the corresponding NotifyProtocol or NotifyDataMiner(Queued) method call.

```csharp
object[] result = (object[]) protocol.NotifyDataMiner(322/*NT_GET_CAPABILITIES*/, null, null);
object[] ids = (object[]) result[0];
object[] names = (object[]) result[1];
object[] comment = (object[]) result[2];
object[] field1 = (object[]) result[3];
object[] field2 = (object[]) result[4];
```
