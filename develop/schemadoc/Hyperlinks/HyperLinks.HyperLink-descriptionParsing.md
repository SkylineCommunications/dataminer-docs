---
uid: HyperLinks.HyperLink-descriptionParsing
---

# descriptionParsing attribute

Specifies that the command should appear only in the shortcut menu of alarms and information events with a specific description.

## Content Type

string

## Parents

[HyperLink](xref:HyperLinks.HyperLink)

## Remarks

If you specify a string in this attribute, the command will only appear in the shortcut menu of alarms and information events of which the description matches the string you specified.

If you leave this attribute empty, the command will appear in the shortcut menu of every alarm and information event.

The string you specify in this *descriptionParsing* attribute can contain wildcards (question marks and asterisks) as well as placeholders. See [Placeholders](xref:Hyperlinks_xml#placeholders).

> [!NOTE]
> Alternatively, you can use the attribute *valueParsing* to have the command appear only for alarms and information events with a particular value.