---
uid: GetSpectrumMonitors
---

# GetSpectrumMonitors

Use this method to retrieve all available monitors for a particular spectrum element.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| elementID  | Integer | The element ID of the spectrum analyzer element.      |

## Output

| Item | Format | Description |
|--|--|--|
| GetSpectrumMonitorsResult | Array of [DMASpectrumMonitor](xref:DMASpectrumMonitor) | The available monitors for the specified spectrum element. |
