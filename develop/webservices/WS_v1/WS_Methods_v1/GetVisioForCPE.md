---
uid: GetVisioForCPE
---

# GetVisioForCPE

Use this method to retrieve a specific page of the Visio file linked to a particular CPE element as an image of a specified size. The page is returned as an interactive image containing clickable regions linked to a certain action, and scrollable child regions.

All images are in PNG format, and are base64 encoded.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| chain | String | The currently selected chain, which can be retrieved using the [GetTopologyChainsForCPE](xref:GetTopologyChainsForCPE) method. |
| fieldName | String | The name of the currently selected field, which can be retrieved using the [GetTopologyFieldsForCPEChain](xref:GetTopologyFieldsForCPEChain) method. |
| width | Integer | The width of the image to be returned. |
| height | Integer | The height of the image to be returned. |
| page | Integer | The page of the Visio file to be returned. |

## Output

| Item | Format | Description |
|--|--|--|
| GetVisioForCPEResult | [DMAVisio](xref:DMAVisio) | The Visio file linked to the specified CPE element, returned as an interactive image. |
