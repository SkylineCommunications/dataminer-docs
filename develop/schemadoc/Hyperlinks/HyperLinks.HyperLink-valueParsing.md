---
uid: HyperLinks.HyperLink-valueParsing
---

# valueParsing attribute

Configures the command to appear only in the shortcut menu of alarms and information events with a specific value.

## Content Type

string

## Parents

[HyperLink](xref:HyperLinks.HyperLink)

## Remarks

If you specify a string in this attribute, the command will only appear in the shortcut menu of alarms and information events of which the value matches the string you specified.

If you leave this attribute empty, the command will appear in the shortcut menu of every alarm and information event.

The string you specify in this *valueParsing* attribute can contain wildcards (question marks and asterisks) as well as placeholders. See [Placeholders](xref:Hyperlinks_xml#placeholders).

> [!NOTE]
> Alternatively, you can use the attribute *descriptionParsing* to have the command appear only for alarms and information events with a particular description.
