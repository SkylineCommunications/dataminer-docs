---
uid: DMAVisioRegionAction
---

# DMAVisioRegionAction

| Item | Format | Description |
|--|--|--|
| ActionID | String | The ID of the action. |
| PageID | Integer | The index number of the Visio page. |
| ShapeUniqueID | Integer | The ID of the Visio shape. |
| Text | String | The text shown in the shape (i.e., the text of the hyperlink). Only used by DataMiner Cube. |
| Description | String | The text that will be shown in a tooltip when hovering over the shape. Only used by DataMiner Cube. Not used by the DataMiner web apps. |
| Type | String | The type of the region. At present, the following types are supported: “Card”, “Script”, “Navigate”, “WebLink”, “Set”, “ResetLatch”, “RedundancyGroupSwitch”, “SetVar” and “Popup” |
| NeedsSendBack | Boolean | This flag is used to check if a call to the server has to be made. Only used by DataMiner Cube. For the DataMiner web apps, this flag is always true. |
| ExtraData | Array of [DMAGenericProperty](xref:DMAGenericProperty) | Additional data. |
