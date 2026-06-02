---
uid: KI_SLAutomation_SLAutomation_crash_while_registering_with_CWatchDogClient
---

# SLAutomation might crash during initialization while registering

## Affected versions

- All DataMiner versions

## Cause

While initializing, SLAutomation registers with the CWatchDogClient. In some cases, this registration can cause the SLAutomation process to crash.

## Fix

No fix is available yet. <!--Task ID: 296159--> The SLAutomation process will automatically be restarted by the *SLWatchdog*.

## Issue description

When a DataMiner Agent starts up, the SLAutomation process registers with the CWatchDogClient as part of its initialization. In rare cases, this registration step fails in a way [that crashes SLAutomation](https://collaboration.dataminer.services/task/296159). The process will then be automatically restarted by SLWatchdog, which will allow SLAutomation to function normally after the crash. However, this can lead to a longer startup time for the DataMiner Agent.
