---
uid: I-DOCSIS_parameters_cm_us_qam_ch
---

# I-DOCSIS parameters – CM US QAM CH

- **US QAM Ch Tx Power**: Direct value. The US Tx (transmit) power for the given CM-channel combination as reported by the cable modem. OID D3.0: 1.3.6.1.2.1.10.127.1.2.2.1.3.2. OID D2.0: 1.3.6.1.4.1.4491.2.1.20.1.2.1.1.
- **US QAM Ch NMTER**: Calculated. The NMTER value of the channel. Only available for DOCSIS 3.x. Calculated based on the values of the Post-Main tap, Pre-Main tap and Main tap. All three of these values are contained in pre-equalization data. OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6.
- **US QAM Ch PreMTTER**: Calculated. The PreMTTER value of the channel. Only available for DOCSIS 3.x. Calculated based on the values of the Pre-Main tap and the sum of the Main tap, Pre-Main tap, and Post-Main tap. These last three values are contained in pre-equalization data. OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6.
- **US QAM Ch PostMTTER**: Calculated. The PostMTTER value of the channel. Only available for DOCSIS 3.x. Calculated based on the values of the Post-Main tap and the sum of the Main tap, Pre-Main tap, and Post-Main tap. These last three values are contained in pre-equalization data. OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6.
- **US QAM Ch Reflection Distance**: Calculated. Only available for DOCSIS 3.x. The reflection distance of the associated US channel.
- **US QAM Ch NMTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The NMTER alarm status. Possible values: *OOS* and *OK*. This alarm is based on the NMTER value being above or below the NMTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.
- **US QAM Ch PreMTTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The PreMTTER alarm status. Possible values: *OOS* and *OK*. This alarm is based on the PreMTTER value being above or below the PreMTTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.
- **US QAM Ch PostMTTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The PostMTTER alarm status. Possible values: *OOS* and *OK*. This alarm is based on the PostMTTER value being above or below the PostMTTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.
- **US QAM Ch MTC**: Calculated. Only available for DOCSIS 3.x. The MTC value of a channel. Calculated as follows: MTC = (Main Tap + Pre-Main Tap + Post-Main Tap) / Main Tap. All values in this formula are contained in pre-equalization data. OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6.
- **US QAM Ch D3.0 PNM Problem Type**: Calculated. Only available for DOCSIS 3.x. The PNM problem type. Possible values: *No Problem*, *Group Delay*, *Micro-Reflection*, *Group Delay and Micro-Reflection*. This problem type is obtained depending on several conditions:

  - If the NMTER value is lower than the NMTER threshold, the problem type is *No Problem*.
  - If (PreMTTER - PostMTTER) > 0, the problem type is *Group Delay*.
  - If the PostMTTER value is higher than or equal to the PostMTTER threshold, the problem type is *Micro-Reflection*.
  - If both of the conditions above apply, the problem type is *Group Delay and Micro-Reflection*.
