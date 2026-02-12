---
uid: DMASpectrumMeasptModel
---

# DMASpectrumMeasptModel

| Item                    | Format  | Description |
|-------------------------|---------|-------------|
| ID                      | Integer | The ID of the measurement point. |
| DataMinerIDs            | String  | The DMA ID(s) for the parameter set(s) used to set up the measurement point, if any. Multiple IDs are separated by semicolons. |
| ElementIDs              | String  | The element ID(s) for the parameter set(s) used to set up the measurement point, if any. Multiple IDs are separated by semicolons. |
| ParamIDs                | String  | The DMA ID(s) for the parameter set(s) used to set up the measurement point, if any. Multiple IDs are separated by semicolons. |
| Name                    | String  | The name of the measurement point. |
| IsStrings               | String  | Indicates whether the parameter(s) used for the parameter set(s), if any, are of type string. Consists of “true” or “false” values, separated by semicolons. |
| Values                  | String  | The values for the parameter set(s) used to set up the measurement point, if any. Multiple values are separated by semicolons. |
| Delay                   | String  | The delay for parameter set verification (in ms). |
| ServiceIDs              | String  | The service ID(s) for the parameter set(s) used to set up the measurement point, if any. Multiple IDs are separated by semicolons. |
| ReadParamIDs            | String  | The DMA ID(s) for the parameter set(s) used to set up the measurement point, if any. Multiple IDs are separated by semicolons. While the ParamIDs field is used for the write parameters, this field is used for the corresponding read parameters. |
| ParamIndices            | String  | The index of the parameter for the parameter set(s) used to set up the measurement point, if any. Multiple indices are separated by semicolons. |
| FreqOffset              | String  | The frequency offset, used to shift the trace in frequency (optional). Specify the offset in Hz, without adding the unit of measure. |
| InvertFreq              | String  | Set to “true” or “false”, depending on whether the trace should be flipped around the center frequency. |
| AutomationScript        | String  | The automation script used to set up the measurement point, if any. |
| AmplitudeCorrectionInfo | String  | Amplitude correction information (optional), using the semicolon as separator within a single correction, and the separator “\|” between corrections. For example, for an amplitude offset of +1 dB for frequencies higher than 1 kHz and +2dB for frequencies higher than 2 kHz, specify *1000;1\|2000;2*. Frequencies should be specified in Hz. |
