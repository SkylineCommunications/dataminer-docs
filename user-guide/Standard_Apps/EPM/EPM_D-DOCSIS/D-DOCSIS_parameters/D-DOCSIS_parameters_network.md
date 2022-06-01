---
uid: D-DOCSIS_parameters_network
---

# D-DOCSIS parameters – Network

## KPIs & KQIs

- **MAC Address**: Direct value. The media access control address of the cable modem (CM). If the CM has multiple MAC addresses, this is the MAC address associated with the MAC domain interface. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.2.
- **IPv4 Address**: Converted. The cable modem internet protocol version 4 address. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.5.
- **Status**: Converted. The operational status of the cable modem. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6.
- **Manufacturer**: Converted. The cable modem manufacturer. Based on the OUI data from the CM MAC address.
- **Operational Mode**: Direct value. The operational registration version. Retrieved using a call to show the cable modem DOCSIS device class.
- **Last Reg Time**: Converted. The last time the CM registered with the CCAP Core. Based on OID 1.3.6.1.4.1.4491.2.1.20.1.3.1.14, converted to datetime format.
- **Last Successful Poll**: Calculated. The last time the CM data flow was completed.
- **Managing RPD**: Direct value. The RPD name. OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.5.
- **RPD MAC Address**: Converted. The media access control address. Based on the index of the RPD table, converted to a hexadecimal value.
- **RPD Status**: Direct value. The RPD Status. Retrieved from the Smart PHY API using the call "v1/smartphycache/rpd/details/active/1".
- **RPD Vendor**: Direct value. The RPD vendor. OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.1.
- **Fiber Node**: Calculated. The fiber node name. Calculated by linking the service group ID from the CM to the fiber node.
- **Service Group**: Calculated. The service group name. Calculated using the fiber node name to get the service group.
- **US QAM**: Calculated. The average percentage of US QAM utilization of CMs linked to the RPD.
- **DS QAM**: Calculated. The average percentage of DS QAM utilization of CMs linked to the RPD.
- **US OFDM**: Calculated. The average percentage of US OFDM utilization of CMs linked to the RPD.
- **DS OFDM**: Calculated. The average percentage of DS OFDM utilization of CMs linked to the RPD.
- **Market**: Calculated. The market containing the CM. This is the market where the parent CCAP is found.
- **Hub**: Calculated. The hub containing the CM. This is the hub where the parent CCAP is found.
- **CCAP**: Calculated. The CCAP managing the CM. This is the name of the parent CCAP element - the first part of the sysName (OID 1.3.6.1.2.1.1.5.0).
- **CCAP Interface**: Direct value. The interface on the CCAP connected to the RPD, as reported by Smart PHY.
- **Core IP**: Calculated. The connected core IP. Retrieved by calculating the principal DOCSIS core IP connected to the RPD and then correlating it to the CM.
- **DPIC Aggregator**: Calculated. The connected DPA.
- **RPD Aggregator**: Calculated. The connected RPA.
