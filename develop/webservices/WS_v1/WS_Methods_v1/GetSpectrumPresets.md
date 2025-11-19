---
uid: GetSpectrumPresets
---

# GetSpectrumPresets

Use this method to retrieve a list of the available shared and private presets for a spectrum analyzer.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| elementID  | Integer | The element ID of the spectrum analyzer element.      |

## Output

| Item | Format | Description |
|--|--|--|
| GetSpectrumPresetsResult | Array of [DMASpectrumPreset](xref:DMASpectrumPreset) | The available presets of the specified spectrum element. |
