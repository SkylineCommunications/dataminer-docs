---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl.ExtraTabs.Tab
description: "Consult the DataMiner connector protocol schema reference for the Tab element, which defines an additional tree control tab and its content type."
---

# Tab element

Defines an additional tab.

## Parent

[ExtraTabs](xref:Protocol.TreeControls.TreeControl.ExtraTabs)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[parameter](xref:Protocol.TreeControls.TreeControl.ExtraTabs.Tab-parameter)|string||Foreign key (parameter ID). Mandatory if the type attribute is set to “relation”.|
|[tableId](xref:Protocol.TreeControls.TreeControl.ExtraTabs.Tab-tableId)|[TypeParamId](xref:Protocol-TypeParamId)||Specifies the ID of the table this additional tab configuration relates to.|
|[title](xref:Protocol.TreeControls.TreeControl.ExtraTabs.Tab-title)|string||Specifies the title description of the tab.|
|[type](xref:Protocol.TreeControls.TreeControl.ExtraTabs.Tab-type)|string||Specifies the tab type.|
