---
uid: DMAVisioRegionAction
---

# DMAVisioRegionAction

| Item          | Format                                                                         | Description                                                                                                                                                                        |
|---------------|--------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ActionID      | String                                                                         | The ID of the action.                                                                                                                                                              |
| PageID        | Integer                                                                        | The index number of the Visio page.                                                                                                                                                |
| ShapeUniqueID | Integer                                                                        | The ID of the Visio shape.                                                                                                                                                         |
| Text          | String                                                                         | The text shown in the shape (i.e. the text of the hyperlink).<br> Only used by DataMiner Cube.                                                                                     |
| Description   | String                                                                         | The text that will be shown in a tooltip when hovering over the shape.<br> Only used by DataMiner Cube. Not used by the mobile apps.                                               |
| Type          | String                                                                         | The type of the region. At present, the following types are supported: “Card”, “Script”, “Navigate”, “WebLink”, “Set”, “ResetLatch”, “RedundancyGroupSwitch”, “SetVar” and “Popup” |
| NeedsSendBack | Boolean                                                                        | This flag is used to check if a call to the server has to be made.<br> Only used by DataMiner Cube. In case of mobile apps, this flag is always true.                              |
| ExtraData     | Array of DMAGeneric­Property (see [DMAGenericProperty](xref:DMAGenericProperty)) | Additional data.                                                                                                                                                                   |
