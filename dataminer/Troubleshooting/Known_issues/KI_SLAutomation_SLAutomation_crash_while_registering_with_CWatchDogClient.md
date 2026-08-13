---
uid: KI_SLAutomation_SLAutomation_crash_while_registering_with_CWatchDogClient
---

# SLAutomation crash during DataMiner startup

## Affected versions

- All DataMiner versions.

## Cause

When a DataMiner Agent starts up, the SLAutomation process registers with the CWatchDogClient as part of its initialization. In rare cases, this registration step fails in a way that causes SLAutomation to crash. The process will then be automatically restarted by SLWatchdog, which will allow SLAutomation to function normally after the crash. However, this can lead to a longer startup time for the DataMiner Agent.

## Fix

No fix is available yet.<!-- https://collaboration.dataminer.services/task/296159 -->

## Issue description

When a DataMiner Agent is restarted or upgraded, the SLAutomation process crashes after trying to initialize CWatchDogClient. It is then automatically restarted by SLWatchdog. This causes DataMiner startup to take longer than expected.

When this issue occurs, the *SLErrors.txt* log file displays errors similar to the example below:

```txt
2026/01/27 11:02:27.474|SLDMS.txt|SLDMS.exe 10.4.2343.27106|683172|697776|CDMS::Init()|ERR|-1|Init Automation failed. The remote procedure call failed. (hr = 0x800706BE)
[...]
2026/01/27 11:04:27.512|SLDMS.txt|SLDMS.exe 10.4.2343.27106|683172|409812|CDMS::NotifyFunc|ERR|-1|CoCreateInstance the SLAutomation failed with Server execution failed (hr = 0x80080005)
```
