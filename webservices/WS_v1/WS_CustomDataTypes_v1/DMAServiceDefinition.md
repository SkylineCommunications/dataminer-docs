---
uid: DMAServiceDefinition
---

# DMAServiceDefinition

| Item           | Format                                 | Description                                                                                                |
|----------------|----------------------------------------|------------------------------------------------------------------------------------------------------------|
| Description    | String                                 | The description of the service definition.                                                                 |
| CreatedAt      | Long integer                           | The time when the booking was created.                                                                     |
| CreatedBy      | String                                 | The user who created the booking.                                                                          |
| LastModifiedAt | Long integer                           | The time when the booking was last modified.                                                               |
| LastModifiedBy | String                                 | The user who last modified the booking.                                                                    |
| Nodes          | Array of DMAServiceDef­initionNode     | The nodes of the service definition (see [DMAServiceDefinitionNode](xref:DMAServiceDefinitionNode)).         |
| Edges          | Array of DMAServiceDef­initionEdgeLite | The edges of the service definition (see [DMAServiceDefinitionEdgeLite](xref:DMAServiceDefinitionEdgeLite)). |
