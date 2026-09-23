---
metadata_version: 1
uid: Protocol-TypeQActionOptions
description: "Use the TypeQActionOptions simple type to validate supported QAction option strings and DLL names in the DataMiner connector protocol schema."
---

# TypeQActionOptions simple type

Specifies the QAction options string.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;[EnumQActionOption](xref:Protocol-EnumQActionOption)|||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`^(binary(?:;)?|debug(?:;)?|group(?:;)?|(precompile(?:;)?|queued(?:;)?|(dllName=[^;]+(?:;)?)))+\z`||
