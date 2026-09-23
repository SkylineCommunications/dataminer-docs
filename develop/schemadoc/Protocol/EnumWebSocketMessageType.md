---
metadata_version: 1
uid: Protocol-EnumWebSocketMessageType
description: "Reference the DataMiner connector protocol schema entry for EnumWebSocketMessageType simple type, including its documented structure, attributes, values."
content_type: schema
applies_to:
  - DataMiner
---

# EnumWebSocketMessageType simple type

Specifies the WebSocket message type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|binary|The message will be sent as binary data (Default).|
|&nbsp;&nbsp;Enumeration|text|The message will be sent in plain text format using UTF-8 encoding.|
