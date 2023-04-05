---
uid: NT_GET_BITRATE_DELTA
---

# NT_GET_BITRATE_DELTA (269)

Retrieves the time between two consecutive executions of the specified SNMP group (in ms).

```csharp
int groupID = 10;

int delta = Convert.ToInt32(protocol.NotifyProtocol(269/*NT_GET_BITRATE_DELTA*/, groupID, null));
```

## Parameters

- groupID (int): ID of the group. 

## Return Value

- delta (int): The time between two consecutive executions of the specified group (in ms) or -1 if the specified group has not yet been executed twice.

## Remarks

- Supported since DataMiner version 6.5.4 (RN 2906).
- When a retry is performed because of a timeout, this will be considered a new execution of the group.
- From DataMiner 10.1.6 (RN 29445) onwards, you can retrieve the time delta per row when polling an SNMP table. This will only work for the multipleGetNext and multipleGetBulk polling schemes, since only these polling schemes retrieve entire rows per request.

  It is advised to enable this feature at startup using the notify protocol command NT_SET_BITRATE_DELTA_INDEX_TRACKING (see [NT_SET_BITRATE_DELTA_INDEX_TRACKING (448)](xref:NT_SET_BITRATE_DELTA_INDEX_TRACKING)) with either a single parameter ID or multiple parameter IDs. This information will not be saved and will only be kept as long as the element is running.

  Once tracking has been enabled, the information can be retrieved by using the notify protocol command NT_GET_BITRATE_DELTA with a string as the second argument. In the following example, the command will return the delta value for the specified key ("1") of the specified parameter (100).

  ```csharp
  int parameterId = 100;
  string rowKey = "1";

  object delta = protocol.NotifyProtocol(269 /*NT_GET_BITRATE_DELTA*/, parameterId, rowKey);
  ```

  Parameters:

  - parameterID (int): ID of the parameter.
  - rowKey (string): Key of the row for which the delta should be returned. If an empty string ("") is specified, all currently tracked keys for the specified parameter will be returned.

  Return value:

  - deltas (object[]): The delta values for the specified rows structured as follows:

     ```csharp
     object[] { object[] {string key1, int delta1}, object[] {string key2, int delta2}}
     ```

    > [!NOTE]
    >
    > - If the requested key could not be found, or if no polling happened since the tracking was enabled, an empty array will be returned.
    > - If there were no 2 poll cycles, or if the requested key was only present in 1 poll cycle, then the delta value will be returned as -1.

## Example

```csharp
using System.IO;
using System;
using System.Text;
using Skyline.DataMiner.Scripting;

public class QAction
{
    public static void Run(SLProtocol protocol)
    {
        // Retrieve old and new data.
        object[] oldData = (object[])protocol.OldRow();
        object[] newData = (object[])protocol.NewRow();

        if (oldData == null || oldData.Length < 5 || newData == null || newData.Length < 5)       
            return;

        // Total rate is in column 4.
        uint oldRate = Convert.ToUInt32(((object[])oldData[4])[0]);
        uint newRate = Convert.ToUInt32(((object[])newData[4])[0]);

        // Group in which the data is retrieved.
        int groupId = 100;

        // Delta between the 2 retrievals in ms.
        int delta = Convert.ToInt32(protocol.NotifyProtocol(269/*NT_GET_BITRATE_DELTA*/, groupId, null));

        // Bit rate in seconds.
        double ratePerSecond = ((newRate - oldRate) / delta) * 1000;
    }
}
```

## See also

- [Bitrate calculations](xref:ConnectionsSnmpBitRateCalculations)
