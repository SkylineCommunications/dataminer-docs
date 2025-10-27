---
uid: KI_SLProtocol_RTE_SNMP_group_condition
---

# SLProtocol RTE caused by SNMP group with condition

## Affected versions

From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards.

## Cause

If a protocol contains an SNMP group with a condition, and such a group is first executed with the condition being false and then with the condition being true, this can trigger an SLProtocol runtime error depending on how quickly the device responds.

## Workaround

In the affected protocol.xml, execute a group of type "poll trigger" instead of the group with the condition, and configure it so that its trigger will contain the condition, and if the condition is met, it will call an action of type "execute next" to execute the original poll group. Make sure the condition is removed from the original group.

## Fix

Install DataMiner 10.3.0 [CU17], 10.4.0 [CU5], or 10.4.8.<!-- RN 39885 -->

## Issue description

In the Alarm Console, a DataMiner runtime error is displayed with description "Thread problem in SLProtocol.exe", mentioning a protocol that contains an SNMP group with a condition.
