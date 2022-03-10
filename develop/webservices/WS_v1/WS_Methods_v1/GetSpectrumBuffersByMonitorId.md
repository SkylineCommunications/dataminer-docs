---
uid: GetSpectrumBuffersByMonitorId
---

# GetSpectrumBuffersByMonitorId

Use this method to retrieve the spectrum buffers for a particular spectrum monitor.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID of the spectrum analyzer element.                                 |
| MonitorID  | Integer | The ID of the spectrum monitor.                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetSpectrumBuffers­ByMonitorIdResult | Array of [DMASpectrumBuffer](xref:DMASpectrumBuffer) | The spectrum buffer information. |
