---
metadata_version: 1
uid: Protocol.Commands
description: "Learn how the Commands element contains the uniquely identified and named commands sent to a data source in a DataMiner connector protocol."
---

# Commands element

Contains all commands defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Command](xref:Protocol.Commands.Command)|[0, *]|Defines a complete command.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a command must be unique. |Command |@id |
|Unique |The name of a command must be unique. |Command |dis:Name |

## Remarks

Commands are sent from DataMiner to the data source:

- to request information from the data source, or
- to change a setting of the data source.
