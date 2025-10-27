---
uid: LogSettings-FileElementType
---

# FileElementType complex type

Specifies the log settings for the log file as mentioned in the name attribute.

> [!NOTE]
> If the name attribute is empty, this represents the default log settings.

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [Levels](xref:LogSettings-FileElementType.Levels) |  |  |

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [name](xref:LogSettings-FileElementType-name) | string |  | Specifies the name of the log file (without the extension) to which the settings belong. |
