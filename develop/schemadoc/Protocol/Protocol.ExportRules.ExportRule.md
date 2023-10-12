---
uid: Protocol.ExportRules.ExportRule
---

# ExportRule element

Defines a rule that is used for changing the displayed items in a Dynamic Virtual Element (DVE), for example changing the location of a parameter.

## Parent

[ExportRules](xref:Protocol.ExportRules)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[attribute](xref:Protocol.ExportRules.ExportRule-attribute)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||Specifies the attribute of the XML element specified in the "tag" attribute on which to apply this rule.|
|[name](xref:Protocol.ExportRules.ExportRule-name)|string||Specifies the name of the export rule.|
|[regex](xref:Protocol.ExportRules.ExportRule-regex)|string||Specifies a regular expression to match particular values.|
|[table](xref:Protocol.ExportRules.ExportRule-table)|[TypeWildcardOrNumber](xref:Protocol-TypeWildcardOrNumber)|Yes|Specifies the ID of table parameter that will generate the DVEs.|
|[tag](xref:Protocol.ExportRules.ExportRule-tag)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the XML element on which to apply this rule.|
|[value](xref:Protocol.ExportRules.ExportRule-value)|string|Yes|Specifies the value that needs to be set.|
|[whereAttribute](xref:Protocol.ExportRules.ExportRule-whereAttribute)|string||Allows the validation of the value of an attribute when an export rule is applied.|
|[whereTag](xref:Protocol.ExportRules.ExportRule-whereTag)|string||Specifies, together with the *whereValue* attribute, a condition so the export rule will only be applied if the condition is met.|
|[whereValue](xref:Protocol.ExportRules.ExportRule-whereValue)|string||Specifies, together with the *whereTag* attribute, a condition so the export rule will only be applied if the condition is met.|

## Remarks

An export rule overwrites a declaration in a parent DVE element.

> [!NOTE]
> Export rules are evaluated top-down. Therefore, the order of the export rules is extremely important.
