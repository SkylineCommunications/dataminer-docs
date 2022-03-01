---
uid: GetSpectrumMonitors
---

# GetSpectrumMonitors

Use this method to retrieve all available monitors for a particular spectrum element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID of the spectrum analyzer element.                                 |

## Output

| Item                       | Format                               | Description                                                                                 |
|----------------------------|--------------------------------------|---------------------------------------------------------------------------------------------|
| GetSpectrumMoni­torsResult | Array of DMASpectrum­Monitor objects | An array of DMASpectrumMonitor objects, each containing the ID and the name of the monitor. |

