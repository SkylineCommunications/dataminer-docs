---
uid: Functions.Function.ExportRules.ExportRule
---

# ExportRule element

Defines an export rule.

## Parent

[ExportRules](xref:Functions.Function.ExportRules)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[attribute](xref:Functions.Function.ExportRules.ExportRule-attribute)|string||Specifies the attribute of the tag specified in the "tag" attribute to which this rule should be applied.|
|[regex](xref:Functions.Function.ExportRules.ExportRule-regex)|string||Allows you to specify a regular expression to find particular tag values.|
|[tag](xref:Functions.Function.ExportRules.ExportRule-tag)|string||Indicates the XML tag the rule should be applied to.|
|[value](xref:Functions.Function.ExportRules.ExportRule-value)|string||Indicates the value that should be set in the XML tag.|
|[whereTag](xref:Functions.Function.ExportRules.ExportRule-whereTag)|string||In the *whereTag*, *whereValue*, and *whereAttribute* attributes, you can specify a condition. That way, the export rule will only be applied if the condition is met.</br>Example: `<ExportRule table="*" ... whereTag="Protocol/Params/Param/Name" whereValue="My param" whereAttribute="id" />`|
|[whereValue](xref:Functions.Function.ExportRules.ExportRule-whereValue)|string||In the *whereTag*, *whereValue*, and *whereAttribute* attributes, you can specify a condition. That way, the export rule will only be applied if the condition is met.</br>Example: `<ExportRule table="*" ... whereTag="Protocol/Params/Param/Name" whereValue="My param" whereAttribute="id" />`|
|[whereAttribute](xref:Functions.Function.ExportRules.ExportRule-whereAttribute)|string||In the *whereTag*, *whereValue*, and *whereAttribute* attributes, you can specify a condition. That way, the export rule will only be applied if the condition is met.</br>Example: `<ExportRule table="*" ... whereTag="Protocol/Params/Param/Name" whereValue="My param" whereAttribute="id" />`|
