---
uid: GetVisioPagesForCPE
---

# GetVisioPagesForCPE

Use this method to retrieve a list of the pages of the Visio file linked to a particular CPE element.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| chain | String | The currently selected chain, which can be retrieved using the *GetTopologyChainsForCPE* method. See [GetTopologyChainsForCPE](xref:GetTopologyChainsForCPE). |
| fieldName | String | The name of the currently selected field, which can be retrieved using the *GetTopologyFieldsForCPEChain* method. See [GetTopologyFieldsForCPEChain](xref:GetTopologyFieldsForCPEChain). |

## Output

| Item | Format | Description |
|--|--|--|
| GetVisioPagesForCPEResult | Array of [DMAVisioPage](xref:DMAVisioPage) | A list of the pages of the Visio file linked to the CPE element. |
