---
uid: NT_GET_BITRATE_DATA
---

# NT_GET_BITRATE_DATA (270)

Retrieves the raw counter information of the last two iterations.<!-- RN 2906 -->

```csharp
int groupID = 10;

object[] rawData = (object[])protocol.NotifyProtocol(270 /*NT_GET_BITRATE_DATA*/, groupID, null);

object[] previousData = (object[])rawData[0];
object[] currentData = (object[])rawData[1];
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

object[] rawData = (object[])protocol.NotifyProtocol(270 /*NT_GET_BITRATE_DATA*/, groupId, null);
object[] previousData = (object[])rawData[0];

protocol.Log(
    $@"QA{protocol.QActionID}|
    Previous raw data:
    Ticks when request enters SLSNMPManager: {previousData[0]} ms
    Ticks when request leaves SLSNMPManager: {previousData[1]} ms
    Ticks when first SNMP Request is sent: {previousData[2]} ms
    Ticks when last SNMP Response is received: {previousData[3]} ms
    Avg RTT between packets: {previousData[4]} ms
    Min RTT between packets: {previousData[5]} ms
    Max RTT between packets: {previousData[6]} ms
    Number of iterations: {previousData[7]}
    Bytes sent: {previousData[8]} B
    Bytes received: {previousData[9]} B
    Total RTT: {previousData[10]} ms
    Number of timeouts: {previousData[11]}",
    LogType.DebugInfo,
    LogLevel.NoLogging);

object[] currentData = (object[])rawData[1];

protocol.Log(
    $@"QA{protocol.QActionID}|
    Current raw data:
    Ticks when request enters SLSNMPManager: {currentData[0]} ms
    Ticks when request leaves SLSNMPManager: {currentData[1]} ms
    Ticks when first SNMP Request is sent: {currentData[2]} ms
    Ticks when last SNMP Response is received: {currentData[3]} ms
    Avg RTT between packets: {currentData[4]} ms
    Min RTT between packets: {currentData[5]} ms
    Max RTT between packets: {currentData[6]} ms
    Number of iterations: {currentData[7]}
    Bytes sent: {currentData[8]} B
    Bytes received: {currentData[9]} B
    Total RTT: {currentData[10]} ms
    Number of timeouts: {currentData[11]}",
    LogType.DebugInfo,
    LogLevel.NoLogging);
```

## See also

- Bitrate calculations
