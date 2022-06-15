---
uid: Protocol.Chains.Chain.Field.Display.Selection.Visibility
---

# Visibility element

Configures chain field visibility settings.

## Parent

[Selection](xref:Protocol.Chains.Chain.Field.Display.Selection)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[default](xref:Protocol.Chains.Chain.Field.Display.Selection.Visibility-default)|||Specifies the default visibility when none of the conditions are met (Default: true).|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Standalone](xref:Protocol.Chains.Chain.Field.Display.Selection.Visibility.Standalone)|[1, *]|Specifies the values the specified parameter must have to toggle the visibility to the opposite setting of the one defined in the default attribute.|
