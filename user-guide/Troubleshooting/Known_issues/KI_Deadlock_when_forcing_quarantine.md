---
uid: KI_Deadlock_when_forcing_quarantine
---

# Deadlock when forcing quarantine during booking update

## Affected versions

DataMiner 10.4.6

## Cause

In specific circumstances, a new feature introduced in DataMiner 10.4.6 ([ID 39264](xref:General_Feature_Release_10.4.6#service--resource-management-queue-will-now-be-skipped-when-processing-setsrmjsonserializableproperties-requests-id-39264)) could cause a deadlock if a quarantine was forced during a booking update.

## Fix

Install DataMiner 10.4.6 [CU1].<!-- RN 39755 -->

## Description

After a quarantine is forced during a booking update, it can occur that the SRM framework stops responding.

An entry similar to the following example can be found in the SLNet logging:

```txt
2024-05-23 21:54:31 33188|HALFOPEN RTE: - (611469) Not signaled 1 (since 1899-12-30 00:00:00): SLNet - SRM event thread for booking with id a1fbcb55-5c6c-4a35-8fad-cd4e73e1ccf2 [pid 114796 - thread 133] in Process: SLNet for Thread: SRM event thread for booking with id a1fbcb55-5c6c-4a35-8fad-cd4e73e1ccf2 notificationID created: 50393
2024-05-23 22:02:02 33188|>>>>>>> (611469) THREAD PROBLEM : SLNet - SRM event thread for booking with id a1fbcb55-5c6c-4a35-8fad-cd4e73e1ccf2 [pid 114796 - thread 133]
```
