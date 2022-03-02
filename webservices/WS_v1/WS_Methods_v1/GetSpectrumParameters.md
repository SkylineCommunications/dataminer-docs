---
uid: GetSpectrumParameters
---

# GetSpectrumParameters

Use this method to retrieve all available parameters for a particular spectrum element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID of the spectrum analyzer element.                                 |

## Output

| Item | Format | Description |
|--|--|--|
| GetSpectrumPara­metersResult | Array of [DMAParameterEdit](xref:DMAParameterEdit) | The properties of the parameters for the specified spectrum element. |
