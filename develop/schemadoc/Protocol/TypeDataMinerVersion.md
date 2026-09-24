---
metadata_version: 1
uid: Protocol-TypeDataMinerVersion
description: "Use the TypeDataMinerVersion simple type to validate four-part DataMiner versions with a 5-digit build number in the DataMiner connector protocol schema."
---

# TypeDataMinerVersion simple type

Represents a DataMiner version.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`([0-9]+\.){3}[0-9]+( - [0-9]{5})`||
