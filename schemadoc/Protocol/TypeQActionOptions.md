---
uid: Protocol-TypeQActionOptions
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
