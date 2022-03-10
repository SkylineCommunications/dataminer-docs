---
uid: NT_SET_ID_RANGE
---

# NT_SET_ID_RANGE (335)

Sets a view ID range.

```csharp
int dmaID = 346;
bool setBackupRange = true;
uint rangeLowerBound = 20001;
uint rangeUpperBound = 30000;
object details = new object[] { 0, dmaID, setBackupRange };
object[] rangeSettings = new object[] { rangeLowerBound, rangeUpperBound };

protocol.NotifyDataMiner(335 /*NT_SET_ID_RANGE*/ , details, rangeSettings);
```

## Parameters

- details (object[]):
  - details[0]: 0 (view ID range).
  - details[1]: ID of the DataMiner Agent the new range should be assigned to.
  - details[2]: Optional (default False). False = Default normal DMS range. True = Set a backup range.
- rangeSettings (object[]):
  - rangeSettings[0] (uint): Lower bound of the range.
  - rangeSettings[1] (uint): Upper bound of the range.
  - rangeSettings[2] (uint): Optional. The current ID in this specific range to start using.

## Return Value

- Does not return an object.

## Remarks

- The view ID ranges are saved in the ClusterInfo.xml file (in C:\Skyline DataMiner\\). This file contains all information about all the ID ranges that are used for all DataMiner Agents in the DataMiner System. The current view ID and a backup view ID are saved in DataMiner.xml (in C:\Skyline DataMiner\\).

  Each DataMiner Agent receives a view range. When a new view ID is needed, it will be selected from this view range. These ID ranges are unique in the cluster to make sure that if a new view is added on several Agents at the same time, they do not pick the same view ID.
