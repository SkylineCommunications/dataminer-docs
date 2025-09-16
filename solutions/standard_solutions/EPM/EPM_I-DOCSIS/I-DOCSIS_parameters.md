---
uid: I-DOCSIS_parameters
keywords: I-DOCSIS parameters
---


# Available parameters in Integrated DOCSIS

## Aggregated parameters in Integrated DOCSIS

This section lists the aggregated parameters for each topology level in the Integrated DOCSIS branch of the EPM Solution.

| KPIs | Network | Market | Hub | CCAP Core | DS Linecard | US Linecard | DS Port | US Port | Node Segment | Service Group [Fiber Node] | DS Service Group | US Service Group |
| :---: | :-----: | :----: | :---: | :-----: | :---------: | :---------: | :-----: | :-----: | :----------: | :------------------------: | :--------------: | :--------------: |
| Number Market|X||||||||||||
| Number Hub|X|X|||||||||||
| Number CCAP Core|X|X|X||||||||||
| Number Service Group|X|X|X|X|||||||||
| Number CM|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM Offline|X|X|X|X|X|X|X|X|X|X|X|X|
| Percentage CM Offline|X|X|X|X|X|X|X|X|X|X|X|X|
| Number DOCSIS 2.0|X|X|X|X|X|X|X|X|X|X|X|X|
| Number DOCSIS 3.0|X|X|X|X|X|X|X|X|X|X|X|X|
| Number DOCSIS 3.1|X|X|X|X|X|X|X|X|X|X|X|X|
| Number DOCSIS 1.x|X|X|X|X|X|X|X|X|X|X|X|X|
| Number DOCSIS Unknown|X|X|X|X|X|X|X|X|X|X|X|X|
| Number CM Ping Unreachable|X|X|X|X|X|X|X|X|X|X|X|X|
| Percentage CM Ping Unreachable|X|X|X|X|X|X|X|X|X|X|X|X|
| Average Latency|X|X|X|X|X|X|X|X|X|X|X|X|
| Average Jitter|X|X|X|X|X|X|X|X|X|X|X|X|
| Average Packet Loss Rate|X|X|X|X|X|X|X|X|X|X|X|X|
| Number QAM DS Channels|||||||||X|X|X||
| Number QAM US Channels|||||||||X|X||X|
| Percentage DS Utilization|||||||X||X|X|X||
| Percentage US Utilization||||||||X|X|X||X|

## Unique parameters in Integrated DOCSIS

Below, you can find the pages listing unique aggregated and calculated parameters for each topology level in the Integrated DOCSIS branch of the EPM Solution.

- [Node Segment](xref:I-DOCSIS_parameters_node_segment)

- [CM DS QAM CH](xref:I-DOCSIS_parameters_cm_ds_qam_ch)

- [DS QAM CH](xref:I-DOCSIS_parameters_ds_qam_ch)

- [CM US QAM CH](xref:I-DOCSIS_parameters_cm_us_qam_ch)

- [US QAM CH](xref:I-DOCSIS_parameters_us_qam_ch)

- [DS OFDM CH](xref:I-DOCSIS_parameters_ds_ofdm_ch)

- [US OFDMA CH](xref:I-DOCSIS_parameters_us_ofdma_ch)

- [Cable Modem](xref:I-DOCSIS_parameters_cable_modem)

- [Thresholds](xref:I-DOCSIS_parameters_thresholds)

- [PTP](xref:I-DOCSIS_parameters_ptp)

## Aggregated parameter descriptions

- **Number Market**: Calculated. The total number of associated markets.

- **Number Hub**: Calculated. The total number of associated hubs.

- **Number CCAP Core**: Calculated. The total number of associated CCAP cores.

- **Number Service Group**: Calculated. The total number of associated service groups.

  Service groups are retrieved from the *docsIf3MdNodeStatusTable* (OID 1.3.6.1.4.1.4491.2.1.20.1.12) polled from the CCAP.

- **Number CM**: Calculated. The total number of associated CMs.

  Cable modems are retrieved from the *docsIf3CmtsCmRegStatusTable* (OID 1.3.6.1.4.1.4491.2.1.20.1.3) polled from the CCAP.

- **Number CM Offline**: Calculated. The total number of associated CMs that do not have an operational status.

  Calculated by aggregating the number of CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (8 Operational = Online, any other value = Offline).

- **Percentage CM Offline**: Calculated. The percentage of associated offline CMs, from the CCAP perspective.

  Calculated based on the CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (8 Operational = Online, any other value = Offline).

- **Number DOCSIS 2.0**: Calculated. The total number of associated cable modems that report their DOCSIS version as a version within the 2.0 range.

  Polled directly from the cable modem using the *docsIfDocsisBaseCapability* (OID 1.3.6.1.2.1.10.127.1.1.5.0) property.

- **Number DOCSIS 3.0**: Calculated. The total number of associated cable modems that report their DOCSIS version as a version within the 3.0 range.

  Polled directly from the cable modem using the *docsIfDocsisBaseCapability* (OID 1.3.6.1.2.1.10.127.1.1.5.0) property.

- **Number DOCSIS 3.1**: Calculated. The total number of associated cable modems that report their DOCSIS version as a version within the 3.1 range.

  Polled directly from the cable modem using the *docsIfDocsisBaseCapability* (OID 1.3.6.1.2.1.10.127.1.1.5.0) property.

- **Number DOCSIS 1.x**: Calculated. The total number of associated cable modems that report their DOCSIS version as a version within the 1.x range.

  Polled directly from the cable modem using the *docsIfDocsisBaseCapability* (OID 1.3.6.1.2.1.10.127.1.1.5.0) property.

- **Number DOCSIS Unknown**: Calculated. The total number of associated cable modems that are unable to report their DOCSIS version or for which the DOCSIS version is outside of the known range.

  Polled directly from the cable modem using the *docsIfDocsisBaseCapability* (OID 1.3.6.1.2.1.10.127.1.1.5.0) property.

- **Number CM Ping Unreachable**: Calculated. The number of associated CMs that report the ping status "Unreachable".<!-- RN 36751 -->

- **Percentage CM Ping Unreachable**: Calculated. The percentage of associated CMs that report the ping status "Unreachable".

- **Average Latency**: Calculated. The average latency for all associated CMs. Only CMs that can be reached via ping count towards this KPI.

- **Average Jitter**: Calculated. The average jitter for all associated CMs. Only CMs that can be reached via ping count towards this KPI.

- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all associated CMs. Only CMs that can be reached via ping count towards this KPI.

- **Number QAM DS Channels**: Calculated. The total number of associated downstream channels.

  Mapping of channels to fiber nodes is done using the *clabTopoChFnCfgTable* (OID 1.3.6.1.4.1.4491.4.2.1.2) polled from the CCAP.

- **Number QAM US Channels**: Calculated. The total number of associated upstream channels.

  Mapping of channels to fiber nodes is done using the *clabTopoChFnCfgTable* (OID 1.3.6.1.4.1.4491.4.2.1.2) polled from the CCAP.

- **Percentage DS Utilization**: Calculated. The average channel utilization of associated downstream channels.

  Individual channel utilization values are retrieved from the *docsIfCmtsChannelUtilizationTable* (OID 1.3.6.1.2.1.10.127.1.3.9) polled from the CCAP.

- **Percentage US Utilization**: Calculated. The average channel utilization of associated upstream channels.

  Individual channel utilization values are retrieved from the *docsIfCmtsChannelUtilizationTable* (OID 1.3.6.1.2.1.10.127.1.3.9) polled from the CCAP.
