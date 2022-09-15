---
uid: GetParametersForCPEChain
---

# GetParametersForCPEChain

Use this method to retrieve the parameters for a specified chain of a CPE element.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| chain | String | The name of the chain. |
| filters | Array of string | The filters that are applied to the CPE chain (optional). If no filters are specified, only KPI parameters that do not need a filter will be retrieved. |

## Output

| Item                            | Format                   | Description                            |
|---------------------------------|--------------------------|----------------------------------------|
| GetParametersForCPEChainResult | Array of DMAParameterCPE | The parameters of the specified chain. |

> [!NOTE]
> The DMAParameterCPE array that is returned by this method has the same properties as the DMAParameterTableRow array, with some additional filter information:
>
> - NoSelectionFilter indicates whether a selection filter is applied to the table.
> - FixedFilter indicates whether a fixed filter is used to retrieve the data.
>
> See [DMAParameterTableRow](xref:DMAParameterTableRow).
