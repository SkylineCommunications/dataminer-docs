---
uid: KI_Prerequisites_fail_when_upgrading_from_10.4.0-to-10.5.3-CU3
---

# Prerequisites fail when upgrading from 10.4.0-10.4.4 to 10.5.0 CU3, 10.5.6, or 10.5.7

## Affected versions

Upgrade path from DataMiner 10.4.0, 10.4.1, 10.4.2, 10.4.3 or 10.4.4 to 10.5.0 CU3, 10.5.6, or 10.5.7

## Cause

Some prerequisite checks included in the upgrade to 10.5.0 [CU3], 10.5.6, and 10.5.7 rely on a version of the `System.Text.Json` library that is not present in 10.4.0, 10.4.1, 10.4.2, 10.4.3 and 10.4.4. This causes specific prerequisites to fail during the upgrade process.

In addition, although the `VerifyNATSMigrationPrerequisites.dll` check was reverted in code in 10.5.0 [CU3], the corresponding file still remains in the installation packages, which may result in the check being executed anyway. In DataMiner 10.5.6/10.5.7 installation packages, this file has been removed.

## Fix

Install DataMiner 10.5.0 [CU5] or 10.5.8<!--RN 43099-->.

## Workaround

1. Upgrade from DataMiner 10.4.0, 10.4.1, 10.4.2, 10.4.3 or 10.4.4 to any of the following versions first:

   - 10.5.0 [CU0]

   - 10.5.0 [CU1]

   - 10.5.0 [CU2]

1. Proceed with the upgrade to DataMiner 10.5.0 CU3, 10.5.6, or 10.5.7.

## Description

When upgrading directly from DataMiner 10.4.0, 10.4.1, 10.4.2, 10.4.3 or 10.4.4 to 10.5.0 CU3, 10.5.6, or 10.5.7, the upgrade process fails, with the following lines in the logging:

```txt
DataMiner Agent: 4 error(s) and 0 notice(s)
    - Prerequisite VerifyClusterPorts.dll failed: Exception: Exception has been thrown by the target of an invocation.
    - Prerequisite VerifyNatsCluster.dll failed: Could not load file or assembly 'System.Text.Json, Version=9.0.0.1, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
    - Prerequisite VerifyNATSMigrationPrerequisites.dll failed: Exception: This BPA cannot run on 10.4.0-CU4
- One or more prerequisites failed
```
