---
uid: SaveSpectrumPreset
---

# SaveSpectrumPreset

Use this method to save a particular preset for a spectrum analyzer. Available from DataMiner 9.5.5 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| SessionID | Unsigned integer | The client subscription ID from the WebSocket subscription with which the spectrum session was started |
| Preset | DMASpectrumPreset array | An array containing the preset name and the necessary data to save the settings. See [DMASpectrumPreset](xref:DMASpectrumPreset) |

## Output

None.
