---
uid: SNMP.Configuration.Agent
---

# Agent element

Configures an Agent.

## Parents

[Configuration](xref:SNMP.Configuration)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [id](xref:SNMP.Configuration.Agent-id) | unsignedInt |  | Specifies the ID. |
| [type](xref:SNMP.Configuration.Agent-type) | string |  | Specifies the type (e.g., IPv4). |
| [value](xref:SNMP.Configuration.Agent-value) | string |  | Specifies the value (e.g., the IPv4 address). |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[AuthoritativeEngineID](xref:SNMP.Configuration.Agent.AuthoritativeEngineID) | [0, 1] | Specifies the authoritative engine ID. |
| &#160;&#160;[EngineBoots](xref:SNMP.Configuration.Agent.EngineBoots) | [0, 1] | Specifies the number of engine boots. |
