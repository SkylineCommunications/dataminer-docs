---
uid: KI_Incorrect_RTE_counts_in_SLWatchdog2txt_and_Alarm_Console
---

# Incorrect RTE counts in SLWatchdog2.txt and Alarm Console

## Affected versions

- 9.6.0 [CU19] – 9.6.0 [CU21] 
- 10.0.0 [CU7] – 10.0.0 [CU9]
- 10.0.12 – 10.0.13 [CU1]

## Cause

Improvement of RTE count [[ID_27387](https://community.dataminer.services/documentation/dataminer-v10-0-0-release-notes/#27387)]

## Fix

Total number of processes of which at least one thread has a run-time error no longer replaced by total number of threads with a run-time error [[ID_28360](https://community.dataminer.services/documentation/dataminer-v10-0-0-release-notes/#28360)]

## Issue description

An improvement to the RTE count was implemented; however, in some scenarios where multiple threads of the same process were affected, each thread was counted as one RTE, while there should instead be one RTE count per process.

Example of an SLProtocol process with multiple threads with RTE:

```txt
18404|Send alarm for process SLProtocol.exe (bSignaled = FALSE, bStopped = FALSE) for iCookie = 11036 (RTE Count = 78)
```
