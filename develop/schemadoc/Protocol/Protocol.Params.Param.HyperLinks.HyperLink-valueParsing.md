---
metadata_version: 1
uid: Protocol.Params.Param.HyperLinks.HyperLink-valueParsing
description: "Learn how the valueParsing attribute matches alarm values to control when a custom shortcut command appears in a DataMiner connector protocol."
---

# valueParsing attribute

Makes the command appear on the shortcut menu of specific alarms and information events.

## Content Type

string

## Parent

[HyperLink](xref:Protocol.Params.Param.HyperLinks.HyperLink)

## Remarks

If you specify a string in this attribute, the command will only appear on the shortcut menu of alarms and information events of which the value matches the string you specified.

If you leave this attribute empty, the command will appear on the shortcut menu of every alarm and information event.

The string you specify in this valueParsing attribute can contain wildcards (question marks and asterisks) as well as placeholders.
