---
uid: Protocol.TreeControls.TreeControl.Hierarchy.Table
---

# Table element

Specifies the table links.

## Parent

[Hierarchy](xref:Protocol.TreeControls.TreeControl.Hierarchy)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[condition](xref:Protocol.TreeControls.TreeControl.Hierarchy.Table-condition)|string||Specifies a condition.|
|[id](xref:Protocol.TreeControls.TreeControl.Hierarchy.Table-id)|unsignedInt|Yes|Specifies the parameter ID of the table that is needed in the tree.|
|[parent](xref:Protocol.TreeControls.TreeControl.Hierarchy.Table-parent)|unsignedInt||Specifies the parameter ID of the table that is the parent of the table specified in the id attribute.|

## Remarks

When using a more advanced hierarchy, the table links can be defined using Table tags. In the hierarchy, the path attribute must be omitted or empty.
