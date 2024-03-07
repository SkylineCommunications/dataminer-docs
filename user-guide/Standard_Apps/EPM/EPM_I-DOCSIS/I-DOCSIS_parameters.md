---
uid: I-DOCSIS_parameters
---


# Available parameters in I-DOCSIS

## Aggregated parameters in I-DOCSIS

This section lists the aggregated parameters for each topology level in the I-DOCSIS branch of the EPM Solution.

| KPIs | Network | Market | Hub | CCAP Core | DS Linecard | US Linecard | DS Port | US Port | Node Segment | Service Group [Fiber Node] | DS Service Group | US Service Group |
| :---: | :-----: | :----: | :---: | :-----: | :---------: | :---------: | :-----: | :-----: | :----------: | :------------------------: | :--------------: | :--------------: |
| Number Market|X||||||||||||
| Number Hub|X|X|||||||||||
| Number CCAP Core|X|X|X||||||||||
| Number Service Group|X|X|X|X|||||||||
| Number CM|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM Offline|X|X|X|X|X|X|X|X|X|X|X|X|
| Percentage CM Offline|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM DOCSIS 2.0|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM DOCSIS 3.0|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM DOCSIS 3.1|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM DOCSIS 1.x|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM DOCSIS Other|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM Ping Unreachable|X|X|X|X|X|X|X|X|X|X|X|X|
| Percentage CM Ping Unreachable|X|X|X|X|X|X|X|X|X|X|X|X|
| Average Latency|X|X|X|X|X|X|X|X|X|X|X|X|
| Average Jitter|X|X|X|X|X|X|X|X|X|X|X|X|
| Average Packet Loss Rate|X|X|X|X|X|X|X|X|X|X|X|X|
| Number QAM DS Channels|||||||||X|X|X||
| Number QAM US Channels|||||||||X|X||X|
| Percentage DS Utilization|||||||X||X|X|X||
| Percentage US Utilization||||||||X|X|X||X|

## Unique parameters in I-DOCSIS

Below, you can find the pages listing unique aggregated and calculated parameters for each topology level in the I-DOCSIS branch of the EPM Solution.

- [Node Segment](xref:I-DOCSIS_parameters_node_segment)

- [CM DS QAM CH](xref:I-DOCSIS_parameters_cm_ds_qam_ch)

- [DS QAM CH](xref:I-DOCSIS_parameters_ds_qam_ch)

- [CM US QAM CH](xref:I-DOCSIS_parameters_cm_us_qam_ch)

- [US QAM CH](xref:I-DOCSIS_parameters_us_qam_ch)

<!-- - [DS OFDM CH](xref:I-DOCSIS_parameters_ds_ofdm_ch)

- [US OFDMA CH](xref:I-DOCSIS_parameters_us_ofdma_ch)
 -->
- [Cable Modem](xref:I-DOCSIS_parameters_cable_modem)

- [Thresholds](xref:I-DOCSIS_parameters_thresholds)

## Aggregated parameter descriptions

- **Number Market**: Calculated. The total number of associated markets. Calculated via aggregation.

- **Number Hub**: Calculated. The total number of associated hubs. Calculated via aggregation.

- **Number CCAP Core**: Calculated. The total number of associated CCAP cores. Calculated via aggregation.

- **Number Service Group**: Calculated. The total number of associated service groups. Calculated via aggregation.

- **Number CM**: Calculated. The total number of associated CMs. Calculated via aggregation.

- **Number CM Offline**: Calculated. The total number of associated CMs that do not have an operational status.

  Calculated by aggregating the number of CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (1 Other = Offline, 8 Operational = Online, any other value = Initializing).

- **Percentage CM Offline**: Calculated. The percentage of associated offline CMs, from the CCAP perspective.

  Calculated based on the CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (1 Other = Offline, 8 Operational = Online, any other value = Initializing).

- **Number CM DOCSIS 2.0**: Calculated. The total number of associated cable modems that report their DOCSIS version as a version within the 2.0 range.

- **Number CM DOCSIS 3.0**: Calculated. The total number of associated cable modems that report their DOCSIS version as a version within the 3.0 range.

- **Number CM DOCSIS 3.1**: Calculated. The total number of associated cable modems that report their DOCSIS version as a version within the 3.1 range.

- **Number CM DOCSIS 1.x**: Calculated. The total number of associated cable modems that report their DOCSIS version as a version within the 1.x range.

- **Number CM DOCSIS Other**: Calculated. The total number of associated cable modems that are unable to report their DOCSIS version or for which the DOCSIS version is outside of the known range.

- **Number CM Ping Unreachable**: Calculated. The number of associated CMs that report the ping status "Unreachable".

- **Percentage CM Ping Unreachable**: Calculated. The percentage of associated CMs that report the ping status "Unreachable".

- **Percentage Utilization**: Calculated. The average utilization of all associated DS channels.

- **Average Latency**: Calculated. The average latency for all associated CMs. Only CMs that can be reached via ping count towards this KPI.

- **Average Jitter**: Calculated. The average jitter for all associated CMs. Only CMs that can be reached via ping count towards this KPI.

- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all associated CMs. Only CMs that can be reached via ping count towards this KPI.

- **Number QAM DS Channels**: Calculated. The total number of associated downstream channels. Calculated via aggregation.

- **Number QAM US Channels**: Calculated. The total number of associated upstream channels. Calculated via aggregation.

- **Percentage DS Utilization**: Calculated. The average channel utilization of associated downstream channels. Calculated via aggregation.

- **Percentage US Utilization**: Calculated. The average channel utilization of associated upstream channels. Calculated via aggregation.
