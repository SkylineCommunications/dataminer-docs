---
uid: GetSpectrumParameters
---

# GetSpectrumParameters

Use this method to retrieve all available parameters for a particular spectrum element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID of the spectrum analyzer element.                                 |

## Output

| Item | Format | Description |
|--|--|--|
| GetSpectrumParametersResult | Array of [DMAParameterEdit](xref:DMAParameterEdit) | The properties of the parameters for the specified spectrum element. |
