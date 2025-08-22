---
uid: SNMP.SnmpManagers.SnmpManager.SnmpVersion
---

# SnmpVersion element

Specifies the SNMP version: SNMPv1, SNMPv2 (default), or SNMPv3, and the notification type (traps or inform messages).

## Type

integer

## Content Type

integer

## Parents

[SnmpManager](xref:SNMP.SnmpManagers.SnmpManager)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [retries](xref:SNMP.SnmpManagers.SnmpManager.SnmpVersion-retries) | integer |  | Specifies the maximum number of retries for resending a notification. Only applicable when notification type is set to inform messages. |
| [timeout](xref:SNMP.SnmpManagers.SnmpManager.SnmpVersion-timeout) | integer |  | Specifies the timeout (in ms) of a notification that is sent. Only applicable when notification type is set to inform messages. |
