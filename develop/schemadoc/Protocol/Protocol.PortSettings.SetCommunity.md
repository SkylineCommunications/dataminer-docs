---
metadata_version: 1
uid: Protocol.PortSettings.SetCommunity
description: "Learn how the SetCommunity element configures the default SNMP set community string or SNMPv3 encryption password and whether users can edit it."
---

# SetCommunity element

Specifies the SNMP set community string.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.SetCommunity.DefaultValue)|[0, 1]|Specifies the default value of the SNMP set community string that will be used.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.SetCommunity.Disabled)|[0, 1]|Specifies whether the SetCommunity string can be modified in the DataMiner user interface.|
