---
uid: GetSpectrumPresets
---

# GetSpectrumPresets

Use this method to retrieve a list of the available shared and private presets for a spectrum analyzer (available from DataMiner 9.5.5 onwards).

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID of the spectrum analyzer element.                                 |

## Output

| Item | Format | Description |
|--|--|--|
| GetSpectrumPresetsResult | Array of DMASpectrumPreset objects | An array of DMASpectrumPreset objects, each containing the name of the preset and a boolean indicating whether the preset is shared. |
