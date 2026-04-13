---
uid: NT_CHANGE_COMMUNICATION_STATE
---

# NT_CHANGE_COMMUNICATION_STATE (249)

Sets the communication state of an element.

## Parameters

To set the communication state of a **local element**:

```csharp
bool isResponding = false;
int connectionID = 0;

protocol.NotifyProtocol(249 /*NT_CHANGE_COMMUNICATION_STATE*/, isResponding, connectionID);
```

- isResponding (bool): Communication state. False = timeout, True = responding.
- connectionID (int): Connection ID (0 for the main connection.

    > [!NOTE]
    > It is also possible to specify a fictitious connection ID, e.g., -1. For real connections, the connection state will automatically switch from/to timeout when communication on that connection succeeds/fails. For a fictitious connection, there is no real communication on that connection, so you can only change it by using this notify call. The element will go into timeout as soon as one connection is in timeout for the period of time specified in the element timeout setting.

To set the communication state of a **remote element**:

```csharp
uint dmaID = 346;
uint elementID = 116;
uint[] data = new uint[3];
data[0] = dmaID;
data[1] = elementID;
data[2] = Convert.ToUInt32(isResponding);
 
protocol.NotifyDataMiner(249/*NT_CHANGE_COMMUNICATION_STATE*/ , data, connectionID);
```

- data (uint[]):
  - data[0]: DMA ID
  - data[1]: Element ID
  - data[2]: Communication state. 0 = timeout, 1 = responding.
- connectionID (int): Connection ID (0 for the main connection).

To set the communication state of a **DVE**:<!-- RN 4184 -->

Use the same call as for setting the communication state of a remote element, but set the connectionID to -1.

> [!NOTE]
> Note that the behavior for a DVE is different than for a normal element. When calling the DataMiner notify with a 0, the element goes directly into timeout; no timeout time is waited (to save resources e.g., an element with 5000 DVEs = 5000 Timers/Threads possibly extra). The clear behavior, however, is the same.

## Return Value

- Does not return an object.

## Remarks

- In case DVEs should reflect the communication state of the main element, set the overrideTimeoutDVE attribute to true instead of using a NT_CHANGE_COMMUNICATION_STATE call.

  This notify call only works on DVE child elements in case the DVE parent has not set the overrideTimeoutDVE option to "true".
