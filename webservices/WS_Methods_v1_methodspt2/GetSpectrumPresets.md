---
uid: GetSpectrumPresets
---

# GetSpectrumPresets

Use this method to retrieve a list of the available shared and private presets for a spectrum analyzer (available from DataMiner 9.5.5 onwards).

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID of the spectrum analyzer element.                                 |

## Output

| Item                      | Format                              | Description                                                                                                                          |
|---------------------------|-------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------|
| GetSpectrumPresets­Result | Array of DMASpectrum­Preset objects | An array of DMASpectrumPreset objects, each containing the name of the preset and a boolean indicating whether the preset is shared. |

