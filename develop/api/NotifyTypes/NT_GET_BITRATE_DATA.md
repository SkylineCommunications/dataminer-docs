---
uid: NT_GET_BITRATE_DATA
---

# NT_GET_BITRATE_DATA (270)

Retrieves the raw counter information of the last two iterations.<!-- RN 2906 -->

```csharp
int groupID = 10;

object[] rawData = (object[])protocol.NotifyProtocol(270/*NT_GET_BITRATE_DATA*/ , groupID, null);

object[] previousData = (object[]) rawData[0];
object[] currentData = (object[]) rawData[1];
```

## Parameters

- groupID (int): ID of the group.

## Return Value

- rawData (object[]): Array containing two object arrays.
  - rawData[0] (object[]): The previous data details.
  - rawData[1] (object[]): The new data details.

    Each details array contains the following information:

    - details[0] (int): Ticks when request enters SLSNMPManager (ms).
    - details[1] (int): Ticks when request leaves SLSNMPManager (ms).
    - details[2] (int): Ticks when first SNMP request is sent (ms).
    - details[3] (int): Ticks when last SNMP response is received (ms).
    - details[4] (uint): Average RTT between packets (ms).
    - details[5] (uint): Minimum RTT between packets (ms).
    - details[6] (uint): Maximum RTT between packets (ms).
    - details[7] (uint): Number of iterations.
    - details[8] (uint): Bytes sent (B).
    - details[9] (uint): Bytes received (B).
    - details[10] (uint): Total RTT (ms).
    - details[11] (uint): Number of timeouts.

## Example

```csharp
int groupId = 1500;

object[] rawData = (object[])protocol.NotifyProtocol(270/*NT_GET_BITRATE_DATA*/, groupId, null);
object[] previousData = (object[])rawData[0];

protocol.Log(8, 5, string.Format(
    @"
    Previous raw data:
    Ticks when request enters SLSNMPManager: {0} ms
    Ticks when request leaves SLSNMPManager: {1} ms
    Ticks when first SNMP Request is sent: {2} ms
    Ticks when last SNMP Response is received: {3} ms
    Avg RTT between packets: {4} ms
    Min RTT between packets: {5} ms
    Max RTT between packets: {6} ms
    Number of iterations: {7}
    Bytes sent: {8} B
    Bytes received: {9} B
    Total RTT: {10} ms
    Number of timeouts: {11}",
    previousData[0], previousData[1], previousData[2], previousData[3], previousData[4], previousData[5],
    previousData[6], previousData[7], previousData[8], previousData[9], previousData[10], previousData[11]
    ));

    object[] currentData = (object[])rawData[1];

    protocol.Log(8, 5, string.Format(
    @"
    Current raw data:
    Ticks when request enters SLSNMPManager: {0} ms
    Ticks when request leaves SLSNMPManager: {1} ms
    Ticks when first SNMP Request is sent: {2} ms
    Ticks when last SNMP Response is received: {3} ms
    Avg RTT between packets: {4} ms
    Min RTT between packets: {5} ms
    Max RTT between packets: {6} ms
    Number of iterations: {7}
    Bytes sent: {8} B
    Bytes received: {9} B
    Total RTT: {10} ms
    Number of timeouts: {11}
     ",
    currentData[0], currentData[1], currentData[2], currentData[3], currentData[4], currentData[5],
    currentData[6], currentData[7], currentData[8], currentData[9], currentData[10], currentData[11]
    ));
```

## See also

- Bitrate calculations
