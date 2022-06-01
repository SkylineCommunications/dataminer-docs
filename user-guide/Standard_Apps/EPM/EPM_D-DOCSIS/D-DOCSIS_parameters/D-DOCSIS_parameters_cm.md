---
uid: D-DOCSIS_parameters_cm
---

# D-DOCSIS parameters – CM

## KPIs & KQIs

- **MAC State**: Direct value. The state of the cable modem as reported by the media access layer. Retrieved using the call "show cable modem docsis device-class".
- **US Time Offset Status**: Calculated. The CM US time offset status based on the existence of offending upstream channels. This is calculated if any channels in the cable modem have a high resolution timing offset that is out of spec.
- **Primary SID**: Direct value. The primary service identifier (SID) of the cable modem. Retrieved using the call "show cable modem docsis device-class".
- **Reg Priv**: Direct value. Indicates whether Baseline Privacy Interface (BPI) or BPI Plus (BPI+) encryption is enabled for the CM. Retrieved using the call "show cable modem docsis device-class".
- **Device Class**: Direct value. Displays the device class information for the PacketCable device (using the call "show cable modem docsis device-class"). The modem can report its device class type during registration. Some possible values are:

  - CM or eCM: A standalone cable modem or embedded CM.
  - ePS: Embedded portal services.
  - eMTA: Embedded multimedia terminal adapter.
  - eSTB: Embedded set-top box.
  - unavailable: The CM has not reported its device class.

## System parameters

- **Manufacturer**: Calculated. The CM manufacturer. Calculated based on the OUI data from the CM MAC address.
- **Fiber Node System ID**: Calculated. The fiber node system ID. Calculated by linking the MAC domain of the CM to the fiber node.
- **Interface**: Direct value. The cable interface linked to the DS/US controllers serving the CM. Retrieved using the call "show cable modem docsis device-class".
- **OFDM Status**: Calculated. The operational status of the OFDM function according to support and availability:

  - Active: The CM supports OFDM (""Reg Version"" greater or equal to 3.1) and at least 1 profile is assigned to it (""based on OFDM Profile ID List"").
  - Inactive: The CM supports OFDM, but there is no profile assigned to it.
  - Not Supported: The CM does not support OFDM (""Reg Version"" less than 3.1).

- **OFDM CH 1 IF**: Calculated. The name of the OFDM channel 1 interface. Calculated using the CM 3.1 registration DS profile ID list, by converting the first four hex bytes to decimal, and matching them with the index of the interfaces table to get the name.
- **OFDM CH 2 IF**: Calculated. The name of the OFDM channel 2 interface. Calculated using the CM 3.1 registration DS profile ID list, by converting the second four parts (after the first channel profiles) to decimal, and matching them with the index of the interfaces table to get the name.
- **DS Service Group**: Calculated based on the call "v1/smartphycache/rpd/details/active/1".
- **US Service Group**: Calculated based on the call "v1/smartphycache/rpd/details/active/1".
- **OFDM CH 1**: Calculated. The ID of OFDM channel 1. Calculated using the CM 3.1 registration DS profile ID list, by converting the first four parts to decimal, and matching them with the OFDM DS Channels table to find the channel index.
- **OFDM CH 1 Profile Status**: Calculated. The operational status of the CM from the perspective of the chanel profile quality. Profiles below the recommended one represent a degradation of the service. Possible status values:

  - OK: The CM has remained on the same profile between the last and the current polling cycle for the given channel.
  - Downgraded: The CM has changed its profile to a lower one. A lower profile is determined by its numerical decrease from the preferred profile for the given channel.

- **OFDM CH 1 Profiles**: Calculated. The list of channel 1 profiles. Calculated using the CM 3.1 registration DS profile ID list, by converting the fifth hex to decimal (x). The next x hex bytes represent the list of profiles.
- **OFDM CH 1 Current Profile**: Direct value. The current channel 1 profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 1 Downgrade Profile**: Direct value. The current channel 1 downgrade profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 1 Preferred Profile**: Direct value. The current channel 1 preferred profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 2**: Calculated. The ID of OFDM channel 2. Calculated using the CM 3.1 registration DS profile ID list, by converting the second four parts (after the first channel profiles) to decimal, and matching them with the OFDM DS Channels table to find the channel index.
- **OFDM CH 2 Profile Status**: Calculated. The operational status of the CM from the perspective of the chanel profile quality. Profiles below the recommended one represent a degradation of the service. Possible status values:

  - OK: The CM has remained on the same profile between the last and the current polling cycle for the given channel.
  - Downgraded: The CM has changed its profile to a lower one. A lower profile is determined by its numerical decrease from the preferred profile for the given channel.

- **OFDM CH 2 Profiles**: Calculated. The list of channel 2 profiles. Calculated using the CM 3.1 registration DS profile ID list, by converting the fifth hex to decimal (x). The next x hex bytes represent the list of profiles.
- **OFDM CH 2 Current Profile**: Direct value. The current channel 2 profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 2 Downgrade Profile**: Direct value. The current channel 2 downgrade profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 2 Preferred Profile**: Direct value. The current channel 2 preferred profile. Retrieved using the call "show cable modem phy ofdm".
- **MAC**: The media access control address of the CM. If the CM has multiple MAC addresses, this is the MAC address associated with the MAC Domain interface. MIB OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.2.
- **US Power Status**: The CM US power status, based on the existence of at least one associated upstream channel (CM Upstream Channels SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2) that is above the US power threshold. Users can set a threshold, which will be used to determine the US Power Status. *OK* means the US power is at or below the threshold. *OOS* means the US power is above the threshold.
- **US AVG Power**: The averaged power of all US channels associated with the CM as reported on the CM upstream channels (SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2).
- **US Post-FEC Status**: The CM US Post-FEC status based on the existence of at least one associated upstream channel (CM Upstream Channels SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2) that is above the US Post-FEC threshold. Users can set a threshold, which will be used to determine the US Post-FEC Status. *OK* means the US Post-FEC is at or below the threshold. *OOS* means the US Post-FEC is above the threshold.
- **US AVG Post-FEC**: The averaged Post-FEC of all US channels associated with the CM as reported on the CM upstream channels (SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2).
