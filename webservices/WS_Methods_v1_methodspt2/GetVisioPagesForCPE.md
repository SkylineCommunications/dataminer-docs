---
uid: GetVisioPagesForCPE
---

# GetVisioPagesForCPE

Use this method to retrieve a list of the pages of the Visio file linked to a particular CPE element.

## Input

| Item       | Format  | Description                                                                                                                                                                                                           |
|------------|---------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                                                      |
| DmaID      | Integer | The DataMiner Agent ID.                                                                                                                                                                                               |
| ElementID  | Integer | The element ID.                                                                                                                                                                                                       |
| Chain      | String  | The currently selected chain, which can be retrieved using the *GetTopologyChainsForCPE* method. See [GetTopologyChainsForCPE](xref:GetTopologyChainsForCPE).                            |
| FieldName  | String  | The name of the currently selected field, which can be retrieved using the *GetTopologyFieldsForCPEChain* method. See [GetTopologyFieldsForCPEChain](xref:GetTopologyFieldsForCPEChain). |

## Output

| Item                       | Format                                                                               | Description                                                      |
|----------------------------|--------------------------------------------------------------------------------------|------------------------------------------------------------------|
| GetVisioPagesForCPE­Result | Array of DMAVisioPage (see [DMAVisioPage](xref:DMAVisioPage)) | A list of the pages of the Visio file linked to the CPE element. |

