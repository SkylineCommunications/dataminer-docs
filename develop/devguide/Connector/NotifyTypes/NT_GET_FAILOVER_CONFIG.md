---
uid: NT_GET_FAILOVER_CONFIG
---

# NT_GET_FAILOVER_CONFIG (324)

Retrieves the Failover configuration.

```csharp
object[] result = (object[])protocol.NotifyDataMiner(324 /*NT_GET_FAILOVER_CONFIG*/ , null, null);
```

## Parameters

- This method call does not need any additional parameters.

## Return Value

- result (object[]):
  - result[0] (int): isActive (0=Inactive, 1=Active).
  - result[1] (int): isOnline (0=Not online, 1=Online).
  - result[2] (object[]): NIC info (for primary and secondary NIC)
  - result[3] (string[]): [0]: Virtual IP, [1] Local IP
