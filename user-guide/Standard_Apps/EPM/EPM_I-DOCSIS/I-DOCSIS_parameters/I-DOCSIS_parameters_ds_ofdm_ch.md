---
uid: I-DOCSIS_parameters_ds_ofdm_ch
---

# I-DOCSIS parameters – DS OFDM CH

These parameters are only available in elements running the CISCO CBR-8 CCAP Platform driver.

This page contains an overview of the DS OFDM CH parameters available in the I-DOCSIS branch of the EPM Solution.

## OFDM Channels

- **Interface Name**: Name of the channel retrieved from the Interface Table using the instance ID.

- **Channel ID**: Direct value. ID of the channels within the particular MAC interface. Polled from the CCAP.
  - OID: 1.3.6.1.4.1.4491.2.1.28.1.19.1.1

- **OFDM Lower Freq.**: Direct value. Represents either the lower boundary frequency of the lower guardband or, if no guardband is defined, the lower boundary frequency of the lowest active subcarrier of the OFDM downstream channel. Polled from the CCAP.

  OID: 1.3.6.1.4.1.4491.2.1.28.1.19.1.2

- **OFDM Upper Freq.**: Direct value. Represents either the upper boundary frequency of the upper guardband or, if no guardband is defined, the upper boundary frequency of the highest active subcarrier of the OFDM downstream channel. Polled from the CCAP.

  OID: 1.3.6.1.4.1.4491.2.1.28.1.19.1.3

- **OFDM Utilization**: Direct value. Utilization of the OFDM downstream channel. Polled from the CCAP.
  - OID: 1.3.6.1.4.1.4491.2.1.28.1.19.1.20

- **OFDM PLC Unreliable Post-FEC**: Calculated. ***TODO***. Polled from the Cable Modem.
  - PLC Total Codewords OID: 1.3.6.1.4.1.4491.2.1.28.1.9.1.13
  - PLC Unreliable Codewords OID: 1.3.6.1.4.1.4491.2.1.28.1.9.1.14

- **OFDM NCP Field CRC Post-FEC**: Calculated. ***TODO***. Polled from the Cable Modem.
  - NCP Total Fields OID: 1.3.6.1.4.1.4491.2.1.28.1.9.1.15
  - NCP CRC Failures OID: 1.3.6.1.4.1.4491.2.1.28.1.9.1.16

## OFDM Profiles

- **OFDM Profile ID**: Direct Value. Extracted from the *docsIf31CmDsOfdmProfileStatsTable* instance. Polled from the Cable Modem.

- **OFDM Profile Corrected Post-FEC**: Calculated. The ratio of all corrected packets over all transferred packets for the given OFDM Profile.

  Calculated as follows: Corrected Ratio = (Corrected Difference \* 100) / (Total Codewords Difference).

  - Corrected Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.10.1.4

  - Total Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.10.1.3

- **OFDM Profile Uncorrected Post-FEC**: Calculated. The ratio of all uncorrected packets over all transferred packets for the given OFDM Profile.

  Calculated as follows: Uncorrectable Ratio = (Uncorrected Difference \* 1000,000) / (Total Codewords Difference).

  - Uncorrected Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.10.1.5

  - Total Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.10.1.3

## OFDM Channel Bands

- **OFDM Channel Band ID**: Direct Value. Extracted from the *docsIf31CmDsOfdmChannelPowerTable* instance. Polled from the Cable Modem.

- **OFDM Channel Average Rx Power**: Calculated. Average Rx Power polled from the Cable Modem using OID: 1.3.6.1.4.1.4491.2.1.28.1.11.1.3. The power of 10 is used to calculate the average and then converted back to the dB value.

## CM OFDM Channels

- **Channel ID**: Direct value. Extracted from the *docsIf31CmDsOfdmChanTable* instance. Polled from the Cable Modem.

- **OFDM PLC Unreliable Post-FEC**: Calculated. ***TODO***. Polled from the Cable Modem.
  - PLC Total Codewords OID: 1.3.6.1.4.1.4491.2.1.28.1.9.1.13
  - PLC Unreliable Codewords OID: 1.3.6.1.4.1.4491.2.1.28.1.9.1.14

- **OFDM NCP Field CRC Post-FEC**: Calculated. ***TODO***. Polled from the Cable Modem.
  - NCP Total Fields OID: 1.3.6.1.4.1.4491.2.1.28.1.9.1.15
  - NCP CRC Failures OID: 1.3.6.1.4.1.4491.2.1.28.1.9.1.16

  ## CM OFDM Profile Stats

- **OFDM Profile ID**: Direct Value. Extracted from the *docsIf31CmDsOfdmProfileStatsTable* instance. Polled from the Cable Modem.

- **OFDM Counter Discontinuity Time**: Direct Value. Polled from the Cable Modem.
  - OID: 1.3.6.1.4.1.4491.2.1.28.1.10.1.13

- **OFDM Profile Corrected Post-FEC**: Calculated. The ratio of all corrected packets over all transferred packets for the given OFDM Profile. Polled from the Cable Modem.

  Calculated as follows: Corrected Ratio = (Corrected Difference \* 100) / (Total Codewords Difference).

  - Corrected Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.10.1.4

  - Total Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.10.1.3

- **OFDM Profile Uncorrected Post-FEC**: Calculated. The ratio of all uncorrected packets over all transferred packets for the given OFDM Profile. Polled from the Cable Modem.

  Calculated as follows: Uncorrectable Ratio = (Uncorrected Difference \* 1000,000) / (Total Codewords Difference).

  - Uncorrected Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.10.1.5

  - Total Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.10.1.3

## CM OFDM Channel Power

- **OFDM Channel Band ID**: Direct Value. Extracted from the *docsIf31CmDsOfdmChannelPowerTable* instance. Polled from the Cable Modem.

- **OFDM Channel Rx Power**: Direct value. Rx Power as reported by the Cable Modem for the OFDM Channel Band. 
  - OID: 1.3.6.1.4.1.4491.2.1.28.1.11.1.3.

- **OFDM Channel Center Frequency**: Direct value. The center frequency of the 6 MHz band the Cable Modem measured during the average channel power.
  - OID: 1.3.6.1.4.1.4491.2.1.28.1.11.1.2.

## PNM CM OFDM Rx MER

- **OFDM Channel ID**: Direct Value. Extracted from the *docsPnmCmDsOfdmRxMerTable* instance. Polled from the Cable Modem.

- **OFDM Channel Mean Rx MER**: Direct value. The mean of the dB values of the RxMER measurements of all active subcarriers.
  - OID: 1.3.6.1.4.1.4491.2.1.27.1.2.5.1.3.

- **OFDM Channel Standard Deviation Rx MER**: Direct value. The standard deviation found when calculating the average of all active subcarriers.
  - OID: 1.3.6.1.4.1.4491.2.1.27.1.2.5.1.4.

- **OFDM Channel Rx MER Threshold**: Direct value. The Rx MER value corresponding to the specified Percentile value established by the operator.
  - OID: 1.3.6.1.4.1.4491.2.1.27.1.2.5.1.5.

- **OFDM Channel Rx MER Highest Frequency**: Direct value. The frequency of the highest-frequency subcarrer having RxMER.
  - OID: 1.3.6.1.4.1.4491.2.1.27.1.2.5.1.6.