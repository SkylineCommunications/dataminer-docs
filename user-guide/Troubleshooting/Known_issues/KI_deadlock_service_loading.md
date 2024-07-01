---
uid: KI_deadlock_service_loading
---

# Deadlock in service loading during DataMiner startup

## Affected versions

- Main release versions from 10.3.0 [CU10] onwards.
- Feature release versions from 10.4.1 onwards.

## Cause

When services with duplicate IDs are loaded in, a deadlock can occur during startup of the SLDataMiner process.

## Workaround

Restart the DataMiner Agent.

## Fix

Install DataMiner 10.3.0 [CU16], 10.4.0 [CU4], or 10.4.7 [CU0].<!-- RN 39896 -->

## Description

DataMiner is stuck during startup. In the SLErrors.txt log file, log entries in the following format can be found:

```txt
Not updating service <ServiceName> for key <ServiceKey> since another service was already present for the same key <OtherName>.
Not updating service <ServiceName> for key <ServiceKey> since it was already marked for deletion.
```
