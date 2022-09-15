---
uid: GetSpectrumBuffersByMonitorId
---

# GetSpectrumBuffersByMonitorId

Use this method to retrieve the spectrum buffers for a particular spectrum monitor.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID of the spectrum analyzer element.                                 |
| monitorID  | Integer | The ID of the spectrum monitor.                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetSpectrumBuffersByMonitorIdResult | Array of [DMASpectrumBuffer](xref:DMASpectrumBuffer) | The spectrum buffer information. |
