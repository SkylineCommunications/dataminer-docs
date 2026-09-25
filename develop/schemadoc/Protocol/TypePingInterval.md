---
metadata_version: 1
uid: Protocol-TypePingInterval
description: "Use the TypePingInterval simple type to validate ping intervals from 1000 to 300000 milliseconds in the DataMiner connector protocol schema."
---

# TypePingInterval simple type

Specifies the valid range for the ping interval setting (in ms).

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***unsignedInt restriction***|||
|&nbsp;&nbsp;Min inclusive|1000||
|&nbsp;&nbsp;Max inclusive|300000||
|&nbsp;&nbsp;Pattern|`^\d+000$`||
