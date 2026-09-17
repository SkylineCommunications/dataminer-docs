---
metadata_version: 1
uid: Protocol.TreeControls.TreeControl.ExtraTabs.Tab
description: "Reference the DataMiner connector protocol schema entry for Tab element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
