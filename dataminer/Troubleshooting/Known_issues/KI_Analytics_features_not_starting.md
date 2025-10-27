---
uid: KI_Analytics_features_not_starting
---

# One or multiple Analytics features fail to start

## Affected versions

From DataMiner 10.2.0 [CU13]/10.3.0 [CU2]/10.3.5 onwards.

## Cause

During the startup of DataMiner, there may be a connection drop between SLAnalytics and SLNet, which can lead to a failed database read before the connection is recovered.

> [!NOTE]
> This issue is isolated to DataMiner Analytics features and does not affect any other functionalities.

## Workaround

Restart the *SLAnalytics* service (e.g. via the Task Manager) after DataMiner has successfully started up.

## Fix

Install DataMiner 10.3.0 [CU12] or 10.4.3<!--38600-->.

## Description

After starting DataMiner, one or multiple DataMiner Analytics features fail to start:

- The following notification is displayed in the Alarm Console: `Failed to start X Analytics feature(s). Check the Analytics logging (SLAnalytics.txt) for more information.`

- *SLAnalytics.txt* shows errors similar to the example below:

  ```txt
  2024/01/25 15:42:26.097|SLAnalytics|ManagedDataSource.cpp(50): datastores::sources::ManagedDataSource<WaveletLevelRecordID,WaveletLevelRecord>::readFromRepository)|ERR|0|Exception while reading from repository Error: 
  Read from DataSetRepository<WaveletLevelRecord> failed after 5 retries with error:
    (Code: 0x80131500) Skyline.DataMiner.Net.Exceptions.DataMinerOfflineException: Connection SLNet down.
  ```
