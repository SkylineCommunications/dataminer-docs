---
uid: Protocol-EnumQActionOption
---

# EnumQActionOption simple type

Specifies a QAction option.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|binary|If specified, all values in “inputParameters” are forwarded to the QAction as a byte array holding the raw content of the parameter.|
|&nbsp;&nbsp;Enumeration|debug|Compiles the QAction in debug mode.|
|&nbsp;&nbsp;Enumeration|dllName=|By default, every QAction is compiled into a DLL file at first use. This DLL file is stored in the C:\Skyline DataMiner\ProtocolScripts directory, and is assigned a name that is constructed in the following format: `[ProtocolName].[ProtocolVersion].QAction.[QactionID].dll`. When you want the DLL file to include a meaningful name, enter that name in this options attribute. This name will then replace the `QAction.[QActionID]` part. For more information, refer to the DataMiner Protocol Markup Language documentation.|
|&nbsp;&nbsp;Enumeration|group|When you specify this option, the “OldRow()” function will return the values retrieved by that group.|
|&nbsp;&nbsp;Enumeration|precompile|Compiles the QAction immediately, without waiting for it to be triggered for execution.|
|&nbsp;&nbsp;Enumeration|queued|The QAction will be executed asynchronously. This implies that the QAction is triggered and set in the background.|
