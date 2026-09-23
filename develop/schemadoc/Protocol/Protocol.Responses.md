---
metadata_version: 1
uid: Protocol.Responses
description: "Reference the DataMiner connector protocol schema entry for Responses element, including its documented structure, attributes, values, and constraints."
---

# Responses element

Contains all responses defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Response](xref:Protocol.Responses.Response)|[0, *]|Specifies a response that DataMiner can expect after having sent a specific command to the device.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a response must be unique. |Response |@id |
|Unique |The name of a response must be unique. |Response |dis:Name |
