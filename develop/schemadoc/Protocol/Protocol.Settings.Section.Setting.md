---
uid: Protocol.Settings.Section.Setting
description: "Use the Setting element under Section in a DataMiner protocol to define an individual configuration setting within a section."
---

# Setting element

Contains a setting in this section.

## Parent

[Section](xref:Protocol.Settings.Section)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Choice***|||
|&nbsp;&nbsp;[Text](xref:Protocol.Settings.Section.Setting.Text)||Specifies a free-form text setting.|
|&nbsp;&nbsp;[DropDown](xref:Protocol.Settings.Section.Setting.DropDown)||Specifies a setting whose value is selected from a list of options.|
|&nbsp;&nbsp;[UsernamePasswordCredential](xref:Protocol.Settings.Section.Setting.UsernamePasswordCredential)||Specifies a username and password credential setting.|
|&nbsp;&nbsp;[TokenCredential](xref:Protocol.Settings.Section.Setting.TokenCredential)||Specifies a token credential setting.|
|&nbsp;&nbsp;[SNMPv3Credential](xref:Protocol.Settings.Section.Setting.SNMPv3Credential)||Specifies an SNMPv3 credential setting.|
|&nbsp;&nbsp;[SNMPCommunityCredential](xref:Protocol.Settings.Section.Setting.SNMPCommunityCredential)||Specifies an SNMP community credential setting.|
|&nbsp;&nbsp;[IPAddress](xref:Protocol.Settings.Section.Setting.IPAddress)||Specifies an IP address setting.|
|&nbsp;&nbsp;[IPPort](xref:Protocol.Settings.Section.Setting.IPPort)||Specifies an IP port setting.|
|&nbsp;&nbsp;[Number](xref:Protocol.Settings.Section.Setting.Number)||Specifies a numeric setting.|

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Settings.Section.Setting-id)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the unique ID of the setting.|
|[displayName](xref:Protocol.Settings.Section.Setting-displayName)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the name shown to the user for this setting.|
