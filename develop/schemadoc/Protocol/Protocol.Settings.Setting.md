---
uid: Protocol.Settings.Setting
---

# Setting element

Contains a protocol setting.

## Parent

[Settings](xref:Protocol.Settings)

## Children

|Name|Occurrences|Description
|--- |--- |--- |
|***Choice***|||
|&nbsp;&nbsp;[Text](xref:Protocol.Settings.Setting.Text)||Specifies a free-form text setting.|
|&nbsp;&nbsp;[DropDown](xref:Protocol.Settings.Setting.DropDown)||Specifies a setting whose value is selected from a list of options.|
|&nbsp;&nbsp;[UsernamePasswordCredential](xref:Protocol.Settings.Setting.UsernamePasswordCredential)||Specifies a username and password credential setting.|
|&nbsp;&nbsp;[TokenCredential](xref:Protocol.Settings.Setting.TokenCredential)||Specifies a token credential setting.|
|&nbsp;&nbsp;[SNMPv3Credential](xref:Protocol.Settings.Setting.SNMPv3Credential)||Specifies an SNMPv3 credential setting.|
|&nbsp;&nbsp;[SNMPCommunityCredential](xref:Protocol.Settings.Setting.SNMPCommunityCredential)||Specifies an SNMP community credential setting.|
|&nbsp;&nbsp;[IPAddress](xref:Protocol.Settings.Setting.IPAddress)||Specifies an IP address setting.|
|&nbsp;&nbsp;[IPPort](xref:Protocol.Settings.Setting.IPPort)||Specifies an IP port setting.|
|&nbsp;&nbsp;[Number](xref:Protocol.Settings.Setting.Number)||Specifies a numeric setting.|

## Attributes

|Name|Type|Required|Description
|--- |--- |--- |--- |
|[id](xref:Protocol.Settings.Setting-id)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the unique ID of the setting.|
|[displayName](xref:Protocol.Settings.Setting-displayName)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the name shown to the user for this setting.|
