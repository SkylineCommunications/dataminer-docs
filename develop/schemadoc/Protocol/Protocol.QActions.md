---
uid: Protocol.QActions
---

# QActions element

Contains all the QActions defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[QAction](xref:Protocol.QActions.QAction)|[0, *]|Specifies the code that must execute when a parameter or a row has changed.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a QAction must be unique. |QAction |@id |
|Unique |The name of a QAction must be unique. |QAction |@name |

## Remarks

A QAction (i.e. Quick Action) is a script that can be executed when a parameter or row changes. Inside a QAction, C# should be used. In the past, JScript or VBScript could also be used, but this is [no longer supported](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement).
