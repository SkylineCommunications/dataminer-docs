---
uid: D-DOCSIS_parameters_cm
---

# D-DOCSIS parameters – CM

This page contains an overview of the CM parameters available in the D-DOCSIS branch of the EPM Solution.

> [!NOTE]
> These parameters are only available in the CM Association and CM MAC Search dashboards.

## KPIs & KQIs

- **IPv4 Address**: Converted. The cable modem (CM) IPv4 address.

  OID 1.3.6.1.4.1.4491.2.1.20.1.3.1.5.

- **Status**: Direct value. The operational status of the cable modem.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6.

- **Last Reg Time**: Converted. The last time the CM registered with the CCAP core.

  Converted to datetime format from OID 1.3.6.1.4.1.4491.2.1.20.1.3.1.14.

- **MAC State**: Direct value. The state of the cable modem as reported by the media access layer. Retrieved using the call "show cable modem docsis device-class".

- **DS Service Status**: Calculated. The CM DS service status based on the existence of impaired DS channels

  Calculated based on the CM Impaired Channels table to check whether if any DS channels are impaired.

  - CM Impaired Table OID: 1.3.6.1.4.1.9.9.116.1.5.13.
  - DS Channel Index OID: 1.3.6.1.4.1.9.9.116.1.5.13.1.7.

  Possible values:

  - *OK*: There is no impaired channel.
  - *Partial*: There is at least 1 impaired channel affecting the CM.

- **US Service Status**: Calculated. The CM US service status based on the existence of impaired US channels

  Calculated based on the CM Impaired Channels table to check whether if any US channels are impaired.

  - CM Impaired Table OID: 1.3.6.1.4.1.9.9.116.1.5.13.
  - US Channel Index OID: 1.3.6.1.4.1.9.9.116.1.5.13.1.8.

  Possible values:

  - *OK*: There is no impaired channel.
  - *Partial*: There is at least 1 impaired channel affecting the CM.

- **US SNR Status**: Calculated. The CM US SNR status based on operational thresholds.

  Calculated based on the existence of at least one associated upstream channel that is above the US SNR threshold. Users can set a threshold, which will be used to determine the US SNR Status.

  - *OK*: The US SNR is at or below the threshold.
  - *OOS*: The US SNR is above the threshold.

  CM Upstream Channels OID: 1.3.6.1.4.1.4491.2.1.20.1.4.

- **US AVG SNR**: Calculated. The average SNR of all US channels associated with the CM, as reported on the CM upstream channels.

  - CM Upstream Channels OID: 1.3.6.1.4.1.4491.2.1.20.1.4.
  - SNR OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.4.

- **US Time Offset Status**: Calculated. The CM US time offset status based on the existence of offending upstream channels.

  This status is based on the existence of at least one associated upstream channel (CM Upstream Channels (SNMP MIB)) that is above the US time offset threshold. Users can set a threshold, which will be used to determine the US Time Offset Status.

  - *OK*: The US Time Offset is at or below the threshold.
  - *OOS*: The US Time Offset is above the threshold.

  Timing offset CLI call: show cable modem ver | i (MAC Address)|(Timing Offset)

- **Primary SID**: Direct value. The primary service identifier (SID) of the cable modem.

  Retrieved using the call "show cable modem docsis device-class".

- **Reg Priv**: Direct value. Indicates whether Baseline Privacy Interface (BPI) or BPI Plus (BPI+) encryption is enabled for the CM.

  Retrieved using the call "show cable modem docsis device-class".

- **Device Class**: Direct value. Displays the device class information for the PacketCable device.

  The modem can report its device class type during registration. Some possible values are:

  - CM or eCM: A standalone cable modem or embedded CM.
  - ePS: Embedded portal services.
  - eMTA: Embedded multimedia terminal adapter.
  - eSTB: Embedded set-top box.
  - unavailable: The CM has not reported its device class.

  Retrieved using the call "show cable modem docsis device-class".
  
- **US ICFR Worst Case**: Calculated. Highest ICFR value from US channels associated with the CM.

  Acquired from the "cmIcfr" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US Ripples Worst Case**: Calculated. Highest ripples value from US channels associated with the CM.

  Acquired from the "ripples" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US TX Power Minimum**: Calculated. Lowest TX power value from US channels associated with the CM.

  Acquired from the "txPower" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US TX Power Maximum**: Calculated. Highest TX power value from US channels associated with the CM.

  Acquired from the "txPower" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US T3 24 Hour Count**: Calculated. Total number of T3 timeouts in the last 24 hours from US channels associated with the CM.

  Acquired from the "t3" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US T4 24 Hour Count**: Calculated. Total number of T4 timeouts in the last 24 hours from US channels associated with the CM.

  Acquired from the "t4" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **DS RX Minimum**: Calculated. Minimum RX power from DS channels associated with the CM.

  Acquired from the "rxPower" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS RX Maximum**: Calculated. Maximum RX power from DS channels associated with the CM.

  Acquired from the "rxPower" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS SNR Minimum**: Calculated. Minimum SNR power from DS channels associated with the CM.

  Acquired from the "snr" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS SNR Maximum Total**: Calculated. Maximum SNR power from DS channels associated with the CM.

  Acquired from the "snr" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS Post-FEC 24 Hour Worst Case**: Calculated. Largest Post-FEC ratio using uncorrectable 24-hour count from all DS channels associated with the CM.

  Acquired from the "unerroreds", "correcteds", and "uncorrectables" metric names in the "downstreamScQamChannels" metric group from the Kafka topic.

- **OFDM Post-FEC 24 Hour Worst Case**: Calculated. Largest Post-FEC ratio using uncorrectable 24-hour count from all OFDM channels associated with CM.

  Acquired from the "unerroreds", "correcteds", and "uncorrectables" metric names in the "downstreamScQamChannels" metric group from the Kafka topic.

## System parameters

- **Manufacturer**: Calculated. The CM manufacturer.

  Calculated based on the OUI data from the CM MAC address.

- **Fiber Node System ID**: Calculated. The fiber node system ID.

  Calculated by linking the MAC domain of the CM to the fiber node.

- **Interface**: Direct value. The cable interface linked to the DS/US controllers serving the CM.

  Retrieved using the call "show cable modem docsis device-class".

- **OFDM Status**: Calculated. The operational status of the OFDM function according to support and availability:

  - *Ok*: The CM supports OFDM ("Reg Version" greater or equal to 3.1), at least 1 profile is assigned to it (based on OFDM Profile ID List), and it has no impaired OFDM channels.
  - *Partial*: The CM supports OFDM ("Reg Version" greater or equal to 3.1), at least 1 profile is assigned to it (based on OFDM Profile ID List), and it has one or more impaired OFDM channels.
  - *Inactive*: The CM supports OFDM, but there is no profile assigned to it.
  - *Not Supported*: The CM does not support OFDM ("Reg Version" less than 3.1).

- **OFDM CH 1 IF**: Calculated. The name of the OFDM channel 1 interface.

  Calculated using the CM 3.1 registration DS profile ID list, by converting the first four hex bytes to decimal and matching them with the index of the interfaces table to get the name.

  - CM 3.1 Registration OID: 1.3.6.1.4.1.4491.2.1.28.1.3.
  - DS Profile ID List OID: 1.3.6.1.4.1.4491.2.1.28.1.3.1.2.
  - Interface Name OID: 1.3.6.1.2.1.2.2.1.2.

- **OFDM CH 2 IF**: Calculated. The name of the OFDM channel 2 interface.

  Calculated using the CM 3.1 registration DS profile ID list, by converting the second four parts (after the first channel profiles) to decimal and matching them with the index of the interfaces table to get the name.

  - CM 3.1 Registration OID: 1.3.6.1.4.1.4491.2.1.28.1.3.
  - DS Profile ID List OID: 1.3.6.1.4.1.4491.2.1.28.1.3.1.2.
  - Interface Name OID: 1.3.6.1.2.1.2.2.1.2.

- **DS Service Group**: Direct value. Retrieved using the call "v1/smartphycache/rpd/details/active/1".

- **US Service Group**: Direct value. Retrieved using the call "v1/smartphycache/rpd/details/active/1".

- **OFDM CH 1**: Calculated. The ID of OFDM channel 1.

  Calculated using the CM 3.1 registration DS profile ID list, by converting the first four parts to decimal and matching them with the OFDM DS Channels table to find the channel index.

  - CM 3.1 Registration OID: 1.3.6.1.4.1.4491.2.1.28.1.3.
  - DS Profile ID List OID: 1.3.6.1.4.1.4491.2.1.28.1.3.1.2.
  - OFDM DS Channels OID: 1.3.6.1.4.1.4491.2.1.28.1.19.

- **OFDM CH 1 Profile Status**: Calculated. The operational status of the CM from the perspective of the chanel profile quality. Profiles below the recommended one represent a degradation of the service. Possible values:

  - *OK*: The CM has remained on the same profile between the last and the current polling cycle for the given channel.
  - *Downgraded*: The CM has changed its profile to a lower one. A lower profile is determined by its numerical decrease from the preferred profile for the given channel.

- **OFDM CH 1 Profiles**: Calculated. The list of channel 1 profiles.

  Calculated using the CM 3.1 registration DS profile ID list, by converting the fifth hex to decimal (x). The next x hex bytes represent the list of profiles.

  - CM 3.1 Registration OID: 1.3.6.1.4.1.4491.2.1.28.1.3.
  - DS Profile ID List OID: 1.3.6.1.4.1.4491.2.1.28.1.3.1.2.

- **OFDM CH 1 Current Profile**: Direct value. The current channel 1 profile.

  Retrieved using the call "show cable modem phy ofdm".

- **OFDM CH 1 Downgrade Profile**: Direct value. The current channel 1 downgrade profile.

  Retrieved using the call "show cable modem phy ofdm".

- **OFDM CH 1 Preferred Profile**: Direct value. The current channel 1 preferred profile.

  Retrieved using the call "show cable modem phy ofdm", using the recommended profile listed in the CLI response.

- **OFDM CH 2**: Calculated. The ID of OFDM channel 2.

  Calculated using the CM 3.1 registration DS profile ID list, by converting the second four parts (after the first channel profiles) to decimal, and matching them with the OFDM DS Channels table to find the channel index.

  - CM 3.1 Registration OID: 1.3.6.1.4.1.4491.2.1.28.1.3.
  - DS Profile ID List OID: 1.3.6.1.4.1.4491.2.1.28.1.3.1.2.
  - OFDM DS Channels OID: 1.3.6.1.4.1.4491.2.1.28.1.19.

- **OFDM CH 2 Profile Status**: Calculated. The operational status of the CM from the perspective of the chanel profile quality. Profiles below the recommended one represent a degradation of the service. Possible values:

  - *OK*: The CM has remained on the same profile between the last and the current polling cycle for the given channel.
  - *Downgraded*: The CM has changed its profile to a lower one. A lower profile is determined by its numerical decrease from the preferred profile for the given channel.

- **OFDM CH 2 Profiles**: Calculated. The list of channel 2 profiles.

  Calculated using the CM 3.1 registration DS profile ID list, by converting the fifth hex to decimal (x). The next x hex bytes represent the list of profiles.

  - CM 3.1 Registration OID: 1.3.6.1.4.1.4491.2.1.28.1.3.
  - DS Profile ID List OID: 1.3.6.1.4.1.4491.2.1.28.1.3.1.2.

- **OFDM CH 2 Current Profile**: Direct value. The current channel 2 profile.

  Retrieved using the call "show cable modem phy ofdm".

- **OFDM CH 2 Downgrade Profile**: Direct value. The current channel 2 downgrade profile.

  Retrieved using the call "show cable modem phy ofdm".

- **OFDM CH 2 Preferred Profile**: Direct value. The current channel 2 preferred profile.

  Retrieved using the call "show cable modem phy ofdm", using the RecmProf listed in the CLI response.

- **MAC**: The media access control address of the CM. If the CM has multiple MAC addresses, this is the MAC address associated with the MAC Domain interface.

  MIB OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.2.

- **US Power Status**: The CM US power status.

  Calculated based on the existence of at least one associated upstream channel (CM Upstream Channels SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2) that is above the US power threshold. Users can set a threshold, which will be used to determine the US Power Status.

  - *OK*: The US power is at or below the threshold.
  - *OOS*: The US power is above the threshold.

- **US AVG Power**: The averaged power of all US channels associated with the CM as reported on the CM upstream channels (SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2).

- **US Post-FEC Status**: The CM US Post-FEC status.

  Calculated based on the existence of at least one associated upstream channel (CM Upstream Channels SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2) that is above the US Post-FEC threshold. Users can set a threshold, which will be used to determine the US Post-FEC Status.

  - *OK*: The US Post-FEC is at or below the threshold.
  - *OOS* means the US Post-FEC is above the threshold.

- **US AVG Post-FEC**: The averaged Post-FEC of all US channels associated with the CM as reported on the CM upstream channels (SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2).
