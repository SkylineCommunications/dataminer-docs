---
uid: LoadSpectrumPreset
---

# LoadSpectrumPreset

Use this method to load a spectrum preset for a particular spectrum analyzer. Available from DataMiner 9.5.5 onwards.

This method is obsolete from DataMiner 10.3.5/10.4.0 onwards. <!-- RN 36364 -->

## Input

| Item       | Format           | Description                                                                                            |
|------------|------------------|--------------------------------------------------------------------------------------------------------|
| connection | String           | The connection ID. See [ConnectApp](xref:ConnectApp).                       |
| dmaID      | Integer          | The DataMiner Agent ID.                                                                                |
| elementID  | Integer          | The element ID.                                                                                        |
| sessionID  | Unsigned integer | The client subscription ID from the WebSocket subscription with which the spectrum session was started |
| preset     | String           | The name of the preset.                                                                                |

## Output

| Item | Format | Description |
|--|--|--|
| LoadSpectrumPresetResult | [DMASpectrumPreset](xref:DMASpectrumPreset) | Array containing the name of the preset, a boolean indicating whether the preset is shared, and the settings of the preset. |
