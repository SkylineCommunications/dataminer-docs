---
uid: KI_SLProtocol_RTE_SNMP_group_condition
---

# SLProtocol RTE caused by SNMP group with condition

## Affected versions

This issue has been found in DataMiner 10.3.0 CU13 and 10.4.6. Investigation is still going on to verify if other DataMiner versions are affected.

## Cause

If a protocol contains an SNMP group with a condition, and such a group is executed for the first time with the condition being false and then a next time with the condition being true, this can trigger an SLProtocol run-time error depending on how quickly the device respond.

## Fix

No fix is available yet.

## Issue description

