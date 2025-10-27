---
uid: Log.File
---

# File element

Specifies the log level configuration for the specified file.

## Type

[FileElementType](xref:LogSettings-FileElementType)

## Parents

[Log](xref:LogSettingsLog)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [name](xref:LogSettings-FileElementType-name) | string |  | Specifies the name of the log file (without the extension) to which the settings belong. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [Levels](xref:LogSettings-FileElementType.Levels) |  |  Specifies the log levels for the different log types. |
