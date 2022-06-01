---
uid: I-DOCSIS_parameters_cm_ds_qam_ch
---

# I-DOCSIS parameters – CM DS QAM CH

- **DS QAM Ch Rx Power**: Direct value. The downstream Rx (Receive) power for the given CM-channel combination as reported by the CM. OID: 1.3.6.1.2.1.10.127.1.1.1.1.6.
- **DS QAM Ch SNR**: Direct value. The downstream SNR for the given CM-channel combination as reported by the CM. OID: 1.3.6.1.2.1.10.127.1.1.4.1.5.
- **DS QAM Ch MER**: Direct value. The downstream channel MER. OID: 1.3.6.1.4.1.4491.2.1.20.1.24.1.1.
- **DS QAM Ch Corrected Packet Ratio**: Calculated. The Downstream Corrected Ratio for the given CM-channel combination as calculated by DataMiner. Calculated as follows: Corrected Ratio = (Corrected Difference * 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.9; Unerrored – OID: 1.3.6.1.2.1.10.127.1.1.4.1.8; Uncorrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.10.
- **DS QAM Ch Uncorrectable Packet Ratio**: Calculated. The Downstream Uncorrectable Ratio for the given CM-channel combination as calculated by DataMiner. Calculated as follows: Uncorrectable Ratio = (Uncorrected Difference * 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.9; Unerrored – OID: 1.3.6.1.2.1.10.127.1.1.4.1.8; Uncorrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.10.
