---
uid: SNMP.SnmpManagers.SnmpManager.ResendTime
---

# ResendTime element

Specifies settings related to resend notifications.

## Type

[NillablePositiveOrZeroInteger](xref:SNMP-NillablePositiveOrZeroInteger)

## Content Type

[NillablePositiveOrZeroInteger](xref:SNMP-NillablePositiveOrZeroInteger)

## Parents

[SnmpManager](xref:SNMP.SnmpManagers.SnmpManager)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [endTrap](xref:SNMP.SnmpManagers.SnmpManager.ResendTime-endTrap) | boolean |  | Specifies whether an extra ending ping notification during resent is sent. |
| [oid](xref:SNMP.SnmpManagers.SnmpManager.ResendTime-oid) | string |  | Specifies a custom OID used for resend. |
| [pingOID](xref:SNMP.SnmpManagers.SnmpManager.ResendTime-pingOID) | string |  | Specifies a custom OID for the ping notifications. |
| [startTrap](xref:SNMP.SnmpManagers.SnmpManager.ResendTime-startTrap) | boolean |  | Specifies whether an extra starting ping notification during resent is sent. |
