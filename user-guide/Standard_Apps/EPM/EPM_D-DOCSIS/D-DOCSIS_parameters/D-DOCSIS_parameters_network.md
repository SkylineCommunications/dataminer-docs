---
uid: D-DOCSIS_parameters_network
---

# D-DOCSIS parameters – Network

This page contains an overview of the Network parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **MAC Address**: Direct value. The media access control address of the cable modem (CM). If the CM has multiple MAC addresses, this is the MAC address associated with the MAC domain interface.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.2.

- **IPv4 Address**: Converted. The cable modem internet protocol version 4 address.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.5.

- **Status**: Converted. The operational status of the cable modem.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6. Discrete values found in MIB.

- **Manufacturer**: Converted. The cable modem manufacturer.

  Based on the OUI data from the CM MAC address.

- **Operational Mode**: Direct value. The operational registration version.

  Retrieved using the call "show cable modem docsis device-class".

- **Last Reg Time**: Converted. The last time the CM registered with the CCAP Core.

  Based on OID 1.3.6.1.4.1.4491.2.1.20.1.3.1.14, converted to datetime format.

- **Last Successful Poll**: Calculated. The last time the CM data flow was completed.

- **Managing RPD**: Direct value. The RPD name.

  OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.5.

- **RPD MAC Address**: Converted. The media access control address.

  Based on the index of the RPD table, converted to a hexadecimal value.

  - Index from the RPD table: 1.3.6.1.4.1.4491.2.1.30.1.1.2.
  - RPD Index OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.1.

- **RPD Status**: Direct value. The RPD Status.

  Retrieved from the Smart PHY API using the call "v1/smartphycache/rpd/details/active/1".

- **RPD Vendor**: Direct value. The RPD vendor.

  OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.1.

- **Fiber Node**: Calculated. The fiber node name.

  Calculated by linking the service group ID from the CM to the fiber node.

  - CM registration table OID: 1.3.6.1.4.1.4491.2.1.20.1.3.
  - Service group ID OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.8.
  - Fiber node name (see [D-DOCSIS parameters – Fiber Node](xref:D-DOCSIS_parameters_fiber_node)) converted from index of Node Status Table. Node Status table OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

- **Service Group**: Calculated. The service group name.

  Calculated using the fiber node name to get the service group.

  Service group returned from smart PHY API. Call: v1/smartphycache/rpd/details/active/1

- **US QAM**: Calculated. The average percentage of US QAM utilization of CMs linked to the RPD.

- **DS QAM**: Calculated. The average percentage of DS QAM utilization of CMs linked to the RPD.

- **US OFDM**: Calculated. The average percentage of US OFDM utilization of CMs linked to the RPD.

- **DS OFDM**: Calculated. The average percentage of DS OFDM utilization of CMs linked to the RPD.

- **Market**: Calculated. The market containing the CM. This is the market where the parent CCAP is found.

- **Hub**: Calculated. The hub containing the CM. This is the hub where the parent CCAP is found.

- **CCAP**: Calculated. The CCAP managing the CM. This is the name of the parent CCAP element - the first part of the sysName (OID 1.3.6.1.2.1.1.5.0).

- **CCAP Interface**: Direct value. The interface on the CCAP connected to the RPD, as reported by Smart PHY.

  Smart PHY call: v1/smartphycache/rpd/details/active/1

- **Core IP**: Calculated. The connected core IP.

  Retrieved by calculating the principal DOCSIS core IP connected to the RPD and then correlating it to the CM.

- **DPIC Aggregator**: Calculated. The connected DPA.

  Calculated using LLDP remote tables from the CCAP.

  LLDP remote table OID: SNMP OID: 1.0.8802.1.1.2.1.4.1.

- **RPD Aggregator**: Calculated. The connected RPA.

  Calculated using LLDP remote tables from the CCAP.

  LLDP remote table OID: SNMP OID: 1.0.8802.1.1.2.1.4.1.
