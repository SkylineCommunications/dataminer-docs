---
uid: I-DOCSIS_parameters_us_ofdma_ch
keywords: I-DOCSIS parameters
---

# Integrated DOCSIS parameters – US OFDMA CH

These parameters are only available in elements running the CISCO CBR-8 CCAP Platform connector.

This page contains an overview of the US OFDMA CH parameters available in the Integrated DOCSIS branch of the EPM Solution.

## OFDMA Channels

- **Interface Name**: Name of the channel retrieved from the Interface Table using the instance ID.

- **Channel ID**: Direct value. ID of the channels within the particular MAC interface. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.23.1.23

- **Utilization**: Direct value. Utilization of the OFDMA downstream channel. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.23.1.22

- **Rx Power**: Direct value. The power of the expected commanded received signal in the channel. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.23.1.3

## OFDMA IUC Statistics

- **Interface Name**: Name of the channel retrieved from the Interface Table using the instance ID.

- **IUC Code**: Direct value. The Information and Unique Channel code within the OFDMA Channel.

- **MER**: Direct value. The ratio of the power of the ideal modulated signal to the power of the error or distortion in the signal in dB. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.24.1.10

## CM OFDMA Channels

- **Rx Power**: Direct value. The Rx power in a specified OFDMA channel at the RF input port of the CCAP for a given CM. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.4.1.1

- **Mean Rx MER**: Direct value. The mean of the dB values of the RxMER measurements of all active subcarriers. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.4.1.2

- **Standard Deviation Rx MER**: Direct value. The standard deviation of the dB values of the RxMER measurements of all active subcarriers. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.4.1.3

- **Rx MER Threshold**: Direct value. The percentile of all active subcarriers in an OFDMA channel where the ThresholdRxMerValue occurs. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.4.1.4

- **Rx MER Value**: Direct value. The Rx MER value corresponding to the specified percentile value established by the operator. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.4.1.5

- **Rx MER Highest Frequency**: Direct value. The frequency of the highest-frequency subcarrier having RxMER. Polled from the CCAP.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.4.1.6

- **Subcarrier Zero Frequency**: Direct value. The lower edge frequency of the OFDMA upstream channel. Polled from the cable modem.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.13.1.2

- **Tx Power**: Direct value. The operational transmit power for the associated OFDMA upstream channel. Polled from the cable modem.

  - OID: 1.3.6.1.4.1.4491.2.1.28.1.13.1.10

## CM OFDMA IUC

- **OFDMA IUC Corrected Post-FEC**: Calculated. The ratio of all corrected packets over all transferred packets for the given OFDMA IUC. Polled from the CCAP.

  Calculated as follows: Corrected Ratio = (Corrected Difference \* 100) / (Total Codewords Difference).

  - Corrected Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.5.1.2

  - Total Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.5.1.1

- **OFDMA IUC Uncorrected Post-FEC**: Calculated. The ratio of all uncorrected packets over all transferred packets for the given OFDMA IUC. Polled from the CCAP.

  Calculated as follows: Uncorrectable Ratio = (Uncorrected Difference \* 1000,000) / (Total Codewords Difference).

  - Uncorrected Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.5.1.3

  - Total Codewords: OID 1.3.6.1.4.1.4491.2.1.28.1.5.1.1
