---
uid: SNMP.SnmpManagers.SnmpManager
---

# SnmpManager element

Specifies the configuration of an SNMP Manager.

## Parents

[SnmpManagers](xref:SNMP.SnmpManagers)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [codepage](xref:SNMP.SnmpManagers.SnmpManager-codepage) | integer |  | Specifies the code page. |
| [delay](xref:SNMP.SnmpManagers.SnmpManager-delay) | string |  | Specifies the delay. |
| [id](xref:SNMP.SnmpManagers.SnmpManager-id) | integer |  | Specifies the ID of the SNMP Manager. |
| [sourceDMA](xref:SNMP.SnmpManagers.SnmpManager-sourceDMA) | integer |  | Specifies the ID of the Agent via which all notifications are sent (-1 if disabled). |
| [winSNMP](xref:SNMP.SnmpManagers.SnmpManager-winSNMP) | boolean |  | Specifies whether WinSNMP is used. |

## Children

| Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;| Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[AlarmStorm](xref:SNMP.SnmpManagers.SnmpManager.AlarmStorm) | [0, 1] | Specifies settings related to alarm storm prevention. |
| &#160;&#160;[CommunityString](xref:SNMP.SnmpManagers.SnmpManager.CommunityString) | [0, 1] | Specifies the community string. |
| &#160;&#160;[Description](xref:SNMP.SnmpManagers.SnmpManager.Description) | [0, 1] | Specifies the custom notification description. |
| &#160;&#160;[DeviceOid](xref:SNMP.SnmpManagers.SnmpManager.DeviceOid) | [0, 1] | Indicates whether a device-specific OID is used. |
| &#160;&#160;[Filter](xref:SNMP.SnmpManagers.SnmpManager.Filter) | [0, 1] | Specifies the alarm filter. |
| &#160;&#160;[InformAckTracking](xref:SNMP.SnmpManagers.SnmpManager.InformAckTracking) | [0, 1] | Set to "true" to enable tracking and avoid duplicate inform acknowledgments (ACKs). |
| &#160;&#160;[IP](xref:SNMP.SnmpManagers.SnmpManager.IP) | [0, 1] | Specifies the IP address of the SNMP manager, i.e. the address to which the SNMP notifications will be sent. |
| &#160;&#160;[Name](xref:SNMP.SnmpManagers.SnmpManager.Name) | [0, 1] | Specifies the name of the SNMP manager (e.g. "HP OpenView", "IBM Tivoli Netcool", etc.). |
| &#160;&#160;[ResendTime](xref:SNMP.SnmpManagers.SnmpManager.ResendTime) | [0, 1] | Specifies settings related to resend notifications. |
| &#160;&#160;[SendTraps](xref:SNMP.SnmpManagers.SnmpManager.SendTraps) | [0, 1] | When set to "true", enables the forwarding of SNMP notifications. |
| &#160;&#160;[SNMPv3](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3) | [0, 1] | Configures SNMPv3-related settings. |
| &#160;&#160;[SnmpVersion](xref:SNMP.SnmpManagers.SnmpManager.SnmpVersion) | [0, 1] | Specifies the SNMP version: SNMPv1, SNMPv2 (default), or SNMPv3, and the notification type (traps or inform messages). |
| &#160;&#160;[TrapLayout](xref:SNMP.SnmpManagers.SnmpManager.TrapLayout) | [0, 1] | Configures the trap layout. |
