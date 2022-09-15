---
uid: GetSpectrumMonitors
---

# GetSpectrumMonitors

Use this method to retrieve all available monitors for a particular spectrum element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID of the spectrum analyzer element.                                 |

## Output

| Item | Format | Description |
|--|--|--|
| GetSpectrumMonitorsResult | Array of DMASpectrumMonitor objects | An array of DMASpectrumMonitor objects, each containing the ID and the name of the monitor. |
