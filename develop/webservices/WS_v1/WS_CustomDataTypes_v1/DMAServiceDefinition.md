---
uid: DMAServiceDefinition
---

# DMAServiceDefinition

| Item | Format | Description |
|--|--|--|
| Description | String | The description of the service definition. |
| CreatedAt | Long integer | The time when the booking was created. |
| CreatedBy | String | The user who created the booking. |
| LastModifiedAt | Long integer | The time when the booking was last modified. |
| LastModifiedBy | String | The user who last modified the booking. |
| Type  | String | "Default" or "ProcessAutomation" or "CustomProcessAutomation" |
| Nodes | Array of [DMAServiceDefinitionNode](xref:DMAServiceDefinitionNode) | The nodes of the service definition. |
| Edges | Array of [DMAServiceDefinitionEdgeLite](xref:DMAServiceDefinitionEdgeLite) | The edges of the service definition. |
