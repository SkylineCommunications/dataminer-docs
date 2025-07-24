---
uid: SNMP.SnmpManagers.SnmpManager.SNMPv3
---

# SNMPv3 element

Configures SNMPv3-related settings.

## Parents

[SnmpManager](xref:SNMP.SnmpManagers.SnmpManager)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [authPass](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3-authPass) | string |  | Specifies the authentication password. |
| [privPass](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3-privPass) | string |  | Specifies the privacy password. |
| [securityName](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3-securityName) | string |  | Specifies the security name. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[AuthenticationProtocol](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3.AuthenticationProtocol) | [0, 1] | Specifies the authentication protocol. |
| &#160;&#160;[ContextEngineID](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3.ContextEngineID) | [0, 1] | Specifies the context engine ID: A hexadecimal string of maximum 64 characters. If left empty, DataMiner will automatically generate an ID. |
| &#160;&#160;[ContextName](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3.ContextName) | [0, 1] | Specifies the name that identifies the specific context. This field can be left empty. |
| &#160;&#160;[PrivacyProtocol](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3.PrivacyProtocol) | [0, 1] | Specifies the privacy protocol. |
| &#160;&#160;[SecurityLevel](xref:SNMP.SnmpManagers.SnmpManager.SNMPv3.SecurityLevel) | [0, 1] | Specifies the security level. |
