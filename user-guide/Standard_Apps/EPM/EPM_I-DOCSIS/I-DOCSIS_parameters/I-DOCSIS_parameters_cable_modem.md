---
uid: I-DOCSIS_parameters_cable_modem
---

# I-DOCSIS parameters – Cable Modem

This page contains an overview of the Cable Modem parameters available in the I-DOCSIS branch of the EPM Solution.

These parameters are displayed for the Cable Modem level in the I-DOCSIS dashboards.

## CM Info

- **MAC \[IDX]**: Direct value. The MAC address of the cable modem.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.2

- **Interface**: Direct value. The interface of the cable modem.

  OID: 1.3.6.1.2.1.2.2.1.2

- **Vendor**: Direct value. The vendor of the cable modem.

  Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).

- **Model Number**: Direct value. The model number of the cable modem.

  Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).

- **System Name**: Direct value. The administratively assigned name of the cable modem.

  OID: 1.3.6.1.2.1.1.5.0.

- **DOCSIS Version**: Direct value. The DOCSIS capability of the device. Possible Values: *Unknown*, *DOCSIS 1.0*, *DOCSIS 1.1*, *DOCSIS 2.0*, *DOCSIS 3.0*, and *DOCSIS 3.1*.

  OID: 1.3.6.1.2.1.10.127.1.1.5.

  The *Unknown* value indicates that the DOCSIS version could not be retrieved from the device (e.g. the device is not reachable).

- **Hardware Version**: Direct value. The hardware version of the cable modem.

  Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).

- **Software Version**: Direct value. The software version of the cable modem.

  Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).

- **Boot ROM Version**: Direct value. The boot ROM version of the cable modem.

  Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).

- **Memory Size**: Calculated. The memory size of the cable modem.

  Calculated as follows: Total Memory Size = (MemorySize * MemoryUnits) / 1648576.

  - Memory Size: OID 1.3.6.1.2.1.25.2.3.1.5
  - MemoryUnits: OID 1.3.6.1.2.1.25.2.3.1.4

- **Software Operational Status**: Direct value. The software operational status of the cable modem. Possible Values: *In Progress*, *Complete From Provisioning*, *Complete From Management*, *Failed*, *Other*, and *Not Available*.

  OID: 1.3.6.1.2.1.69.1.3.4.0.

- **Processor Utilization**: Direct value. The processor utilization of the cable modem.

  OID: 1.3.6.1.2.1.25.3.3.1.2

- **Memory Utilization**: Calculated. The memory utilization of the cable modem.

  Calculated by dividing the memory used (OID: 1.3.6.1.2.1.25.2.3.1.6) by the memory size (OID: 1.3.6.1.2.1.25.2.3.1.5).

- **Uptime**: Direct value. The uptime of the cable modem.

  OID: 1.3.6.1.2.1.1.3.0.

## CM Status

- **Last Successful CMTS Poll**: Calculated. The date and time of the last successful polling cycle based on Status, Last Registration Time, and System ID returning valid data.

- **Status**: Direct value. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6. Operational.

- **Last Registration Time**: Direct value. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.14.

## Subscriber

- **IPv4 Address**: Direct value. The IPV4 address of the cable modem.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.5.

- **Latitude**: Direct value. The subscriber position latitude.

- **Longitude**: Direct value.

## Parent Entities

- **CCAP Core Name**: Direct value. The CMTS core device associated with the cable modem.

  The EPM engine makes this association via import operation.

- **Node Segment Name**: Direct value. The node segment is the unique combination of a DS (downstream) port and US (upstream) port. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service.

  The EPM engine makes this association via import operation.

- **Service Group \[Fiber Node] Name**: Direct value.

  The EPM engine makes this association via import operation.

- **Optical Node Name**: Direct value. The optical node associated with the subscriber.

  The EPM engine makes this association via import operation.

## US QAM

- **US QAM Rx Power Status**: Calculated. The CM US Rx Power Status based on operational thresholds.

  This is based on the existence of at least one associated upstream QAM channel reporting valid US Rx Power values, which are put through the Upstream Channel Minimum/Maximum Rx Power Level thresholds logic. Users will be able to set the thresholds that will be used to determine the US Rx Power Status.

  Possible values: *OK* if all US channels report US Rx Power within thresholds, and *OOS* if at least one US channel reports US Rx Power outside thresholds.

- **US QAM Tx Power Status**: Calculated. The CM US Tx Power Status based on operational thresholds.

  This is based on the existence of at least one associated upstream QAM channel reporting valid US Tx Power values, which are put through the Upstream Channel Minimum/Maximum Tx Power Level thresholds logic. Users will be able to set the thresholds that will be used to determine the US Tx Power Status.

  Possible values: *OK* if all US channels report US Tx Power within thresholds, and *OOS* if at least one US channel reports US Tx Power outside thresholds.

- **US QAM SNR Status**: Calculated. The CM US SNR Status based on operational thresholds.

  This is based on the existence of at least one associated upstream QAM channel reporting valid SNR values, which are put through the Upstream Channel Minimum SNR threshold logic. Users will be able to set the threshold that will be used to determine the SNR Status.

  Possible values: *OK* if all US channels report US SNR at or above the threshold, and *OOS* if at least one US channel reports US SNR below the threshold.

- **US QAM Post-FEC Status**: Calculated. The US Post-FEC Status based on operational thresholds.

  This is based on the existence of at least one associated upstream QAM channel reporting valid Uncorrectable Ratio values, which are put through the Upstream Channel Post-FEC Maximum Uncorrectable Error Ratio threshold logic. Users will be able to set the threshold that will be used to determine the US Post-FEC Status.

  Possible values: *OK* if all US channels report an Uncorrectable Ratio below or at the threshold, and *OOS* if at least one US channel reports an Uncorrectable Ratio above the threshold.

- **US Time Offset Status**: Calculated. The CM US Time Offset Status based on operational thresholds.

  This is based on the existence of at least one associated upstream QAM channel reporting valid US Time Offset values, which are put through the Upstream Maximum Timing Offset threshold logic. Users will be able to set the threshold that will be used to determine the US Time Offset Status.

  Possible values: *OK* if all US channels report a US Time Offset at or below the threshold, and *OOS* if at least one US channel reports a US Time Offset above the threshold.

## DS QAM

- **DS QAM Rx Power Status**: Calculated. The CM DS Rx Power Status based on operational thresholds.

  This is based on the existence of at least one associated downstream QAM channel reporting valid DS Rx Power values, which are put through the Downstream Channel Minimum/Maximum Rx Power Level thresholds logic. Users will be able to set the thresholds that will be used to determine the DS Rx Power Status.

  Possible values: *OK* if all DS channels report DS Rx Power within thresholds, and *OOS* if at least one DS channel reports DS Rx Power outside thresholds.

- **DS QAM SNR Status**: Calculated. The CM DS SNR Status based on operational thresholds.

  This is based on the existence of at least one associated downstream QAM channel reporting valid SNR values, which are put through the Downstream Channel Minimum SNR threshold logic. Users will be able to set the threshold that will be used to determine the SNR Status.

  Possible values: *OK* if all DS channels report DS SNR at or above the threshold, and *OOS* if at least one DS channel reports DS SNR below the threshold.

- **DS QAM Post-FEC Status**: Calculated. The DS Post-FEC Status based on operational thresholds.

  This is based on the existence of at least one associated downstream QAM channel reporting valid Uncorrectable Ratio values, which are put through the Downstream Channel Post-FEC Maximum Uncorrectable Error Ratio threshold logic. Users will be able to set the threshold that will be used to determine the DS Post-FEC Status.

  Possible values: *OK* if all DS channels report an Uncorrectable Ratio below or at the threshold, and *OOS* if at least one DS channel reports an Uncorrectable Ratio above the threshold.

## D3.0 PNM

- **Group Delay Status**: Calculated. The group delay status of the cable modem according to the PreMTTER values reported by the associated US channels.

  Possible values: *OK* if all associated US channels are operating within acceptable PreMTTER thresholds, and *OOS* (Out of Spec) if at least one US channel is operating outside acceptable PreMTTER thresholds.

- **Reflection Status**: Calculated. The reflection status of the cable modem according to the PostMTTER values reported by the associated US channels.

  Possible values: *OK* if all associated US channels are operating within acceptable PostMTTER thresholds, and *OOS* (Out of Spec) if at least one US channel is operating outside acceptable PostMTTER thresholds.

- **Average Reflection Distance**: Calculated. The average reflection distance of the associated US channels.

- **Group Delay or Reflection Status**: Calculated. The presence of group delay or reflection, based on the reported NMTER values of US channels associated with the cable modem.

  Possible values: *OK* if all associated US channels are operating within acceptable NMTER thresholds, and *OOS* (Out of Spec) if at least one US channel is operating outside acceptable NMTER thresholds.

## Ping Stats

- **RTT**: Direct value. The average round trip time of the ping messages between DataMiner and the cable modem.

- **Jitter**: Direct value. The average fluctuation or variation of ping messages latency.

- **Latency**: Direct value. The average time it takes for the ping messages to travel from the DataMiner Agent to the cable modem.

- **Packet Loss Rate**: Direct value. The percentage of packets reported as lost from ping messages between the DataMiner Agent and the cable modem.
