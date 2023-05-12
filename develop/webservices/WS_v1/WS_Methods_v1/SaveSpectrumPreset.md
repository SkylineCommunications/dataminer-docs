---
uid: SaveSpectrumPreset
---

# SaveSpectrumPreset

Use this method to save a particular preset for a spectrum analyzer. Available from DataMiner 9.5.5 onwards.

This method is obsolete from DataMiner 10.3.5/10.4.0 onwards. <!-- RN 36364 -->

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| sessionID | Unsigned integer | The client subscription ID from the WebSocket subscription with which the spectrum session was started |
| preset | [DMASpectrumPreset](xref:DMASpectrumPreset) array | An array containing the preset name and the necessary data to save the settings. |

## Output

None.
