---
uid: NT_SET_BITRATE_DELTA_INDEX_TRACKING
---

# NT_SET_BITRATE_DELTA_INDEX_TRACKING (448)

Enables or disables the bitrate delta tracking for the specified table parameters.

```csharp
int[] parameterIds = new int[] { 100, 200 };
bool isTrackingEnabled = true;

protocol.NotifyProtocol(/*NT_SET_BITRATE_DELTA_INDEX_TRACKING*/ 448, parameterIds, isTrackingEnabled);

int parameterId = 100;
bool isTrackingEnabled = false;

protocol.NotifyProtocol(/*NT_SET_BITRATE_DELTA_INDEX_TRACKING*/ 448, parameterId, isTrackingEnabled);
```

## Parameters

- parameterIds (int or int[]): IDs of the table parameters.
- isTrackingEnabled (bool): true to start tracking, false to stop tracking.

## Return Value

- Does not return an object.

## Remarks

- It is advised to enable this feature at startup using the notify protocol command NT_SET_BITRATE_DELTA_INDEX_TRACKING with either a single parameter ID or multiple parameter IDs. This information will not be saved and will only be kept as long as the element is running.
- Only supported with the multipleGetNext and multipleGetBulk polling schemes since only these polling schemes retrieve entire rows per request.
- See also [NT_GET_BITRATE_DELTA (269)](xref:NT_GET_BITRATE_DELTA).
- Feature introduced in DataMiner 10.1.6 (RN 29445).
