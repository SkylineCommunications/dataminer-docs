---
uid: Protocol.Params.Param.HyperLinks.HyperLink-valueParsing
description: "Learn how the deprecated valueParsing attribute in a DataMiner protocol shows custom shortcut commands for specific alarms and information events."
---

# valueParsing attribute

Deprecated. Makes the command defined in a `Hyperlink` element appear on the shortcut menu of specific alarms and information events.

This is not supported in DataMiner Cube. Instead, a separate [Hyperlinks.xml](xref:Hyperlinks_xml) file is used.

## Content Type

string

## Parent

[HyperLink](xref:Protocol.Params.Param.HyperLinks.HyperLink)

## Remarks

If you specify a string in this attribute, the command will only appear on the shortcut menu of alarms and information events of which the value matches the string you specified.

If you leave this attribute empty, the command will appear on the shortcut menu of every alarm and information event.

The string you specify in this `valueParsing` attribute can contain wildcards (question marks and asterisks) as well as placeholders.
