---
uid: I-DOCSIS_parameters_cm_us_qam_ch
---

# I-DOCSIS parameters – CM US QAM CH

This page contains an overview of the CM US QAM CH parameters available in the I-DOCSIS branch of the EPM Solution.

These parameters are displayed for the Cable Modem level in the I-DOCSIS dashboards.

- **Name \[IDX]**: Direct value. The display name of the CM-channel relation.

  Concatenation of the CM MAC, CMTS Name, and US Ch Name, using "/" as a separator.

- **US Service Group Name**: Direct value. The display name of the upstream service group associated with the upstream channel.

  Concatenation of the CMTS Name, Upstream Port, and Service Group \[Fiber Node] System Name, using "/" as a separator.

- **US Ch Name**: Direct value. The display name of the upstream channel.

  Concatenation of the Service Group \[Fiber Node] System Name and US Channel System Name, using "/" as a separator.

- **Service Group \[Fiber Node] Name**: Direct value. The display name of the service group \[fiber node] associated with the upstream channel.

  Concatenation of the CMTS Name, Service Group \[Fiber Node] System Name, Cable Interface, and alias of the first channel associated with the cable interface, using "/" as a separator.

- **Node Segment Name**: Direct value. The display name of the node segment.

  Concatenation of the CMTS Name and the unique combination of a DS (downstream) port and US (upstream) port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service. There will be a node segment every time the connector detects a unique combination of US/DS port serving at least one cable modem.

- **US QAM Ch Frequency**: Direct value.

- **US QAM Ch Width**: Direct value.

- **US QAM Ch Modulation**: Direct value.

- **US QAM Ch Rx Power**: Direct value. The US Rx (receive) power for the given CM-channel combination as reported by the CMTS.

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.3.

  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.6.

- **US QAM Ch Power Fluctuation**: Calculated. The difference between the expected Rx Power and the Rx Power. Only available for DOCSIS 3.x.

- **US QAM Ch Tx Power**: Direct value. The US Tx (transmit) power for the given CM-channel combination as reported by the cable modem.

  - OID D3.0: 1.3.6.1.2.1.10.127.1.2.2.1.3.2.

  - OID D2.0: 1.3.6.1.4.1.4491.2.1.20.1.2.1.1.

- **US QAM Ch SNR**: Direct value. The upstream SNR for the given CM-channel combination as reported by the CMTS.

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.4.

  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.13.

- **US QAM Ch MER**: Direct value. Only available for DOCSIS 3.x.

- **US QAM Ch Time Offset**: Calculated. The Upstream Time Offset for the given CM-channel combination as calculated by DataMiner.

  Calculated as follows for DOCSIS v3: Time Offset = Upstream ticks * (6.25/(64*256)) * (97.6 / 1000).

  Calculated as follows for other DOCSIS versions: Time Offset = Upstream ticks * (6.25/64) * (97.6 / 1000).

  DOCSIS v3:

  - OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.10.

  Other DOCSIS versions:

  - OID: 1.3.6.1.2.1.10.127.1.1.2.1.6.

- **US QAM Ch Corrected Packet Ratio**: Calculated. The Upstream Corrected Ratio for the given CM-channel combination as calculated by DataMiner.

  Calculated as follows: Corrected Packet Ratio = (Corrected Difference * 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference).

  Corrected:

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.8
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.16

  Unerrored:
  
  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.7
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.15

  Uncorrected:

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.9
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.17

- **US QAM Ch Uncorrectable Packet Ratio**: Calculated. The Upstream Uncorrectable Ratio for the given CM-channel combination as calculated by DataMiner.

  Calculated as follows: Uncorrectable Packet Ratio = (Uncorrected Difference * 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference)

  Corrected:

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.8
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.16

  Unerrored:

  - OID: D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.7
  - OID: D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.15

  Uncorrected

  - OID: D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.9
  - OID: D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.17

- **US QAM Ch Utilization**

- **US QAM Ch NMTER**: Calculated. The NMTER value of the channel. Only available for DOCSIS 3.x.

  Calculated based on the values of the Post-Main tap, Pre-Main tap and Main tap. All three of these values are contained in pre-equalization data.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6.

- **US QAM Ch PreMTTER**: Calculated. The PreMTTER value of the channel. Only available for DOCSIS 3.x.

  Calculated based on the values of the Pre-Main tap and the sum of the Main tap, Pre-Main tap, and Post-Main tap. These last three values are contained in pre-equalization data.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6.

- **US QAM Ch PostMTTER**: Calculated. The PostMTTER value of the channel. Only available for DOCSIS 3.x.

  Calculated based on the values of the Post-Main tap and the sum of the Main tap, Pre-Main tap, and Post-Main tap. These last three values are contained in pre-equalization data.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6.

- **US QAM Ch Reflection Distance**: Calculated. Only available for DOCSIS 3.x. The reflection distance of the associated US channel.

- **US QAM Ch NMTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The NMTER alarm status. Possible values: *OOS* and *OK*.

  This alarm is based on the NMTER value being above or below the NMTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.

- **US QAM Ch PreMTTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The PreMTTER alarm status. Possible values: *OOS* and *OK*.

  This alarm is based on the PreMTTER value being above or below the PreMTTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.

- **US QAM Ch PostMTTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The PostMTTER alarm status. Possible values: *OOS* and *OK*.

  This alarm is based on the PostMTTER value being above or below the PostMTTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.

- **Reflection Power Ratio**: Direct value.

- **US QAM Ch MTC**: Calculated. Only available for DOCSIS 3.x. The MTC value of a channel.

  Calculated as follows: MTC = (Main Tap + Pre-Main Tap + Post-Main Tap) / Main Tap. All values in this formula are contained in pre-equalization data (OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6).

- **US QAM Ch D3.0 PNM Problem Type**: Calculated. Only available for DOCSIS 3.x. The PNM problem type. Possible values: *No Problem*, *Group Delay*, *Micro-Reflection*, *Group Delay and Micro-Reflection*.

  This problem type is obtained depending on several conditions:

  - If the NMTER value is lower than the NMTER threshold, the problem type is *No Problem*.
  - If (PreMTTER - PostMTTER) > 0, the problem type is *Group Delay*.
  - If the PostMTTER value is higher than or equal to the PostMTTER threshold, the problem type is *Micro-Reflection*.
  - If both of the conditions above apply, the problem type is *Group Delay and Micro-Reflection*.
