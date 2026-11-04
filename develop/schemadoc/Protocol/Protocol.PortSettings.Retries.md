---
uid: Protocol.PortSettings.Retries
description: "Use the Retries element in a DataMiner protocol to configure the maximum request retry count for an element connection and whether users can modify it."
---

# Retries element

Configures the number of retries.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.Retries.DefaultValue)|[0, 1]|Specifies the default value for the maximum number of times that a request will be re-sent.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.Retries.Disabled)|[0, 1]|Specifies whether the maximum number of retries can be modified in the DataMiner user interface.|
