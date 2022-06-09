---
uid: I-DOCSIS_parameters_thresholds
---

# I-DOCSIS parameters – Thresholds

This page contains an overview of the Thresholds parameters available in the I-DOCSIS branch of the EPM Solution.

## Upstream QAM Channel Thresholds

- **Upstream Maximum Timing Offset**: Calculated. The upper boundary for acceptable upstream (US) timing offset from the CMTS perspective.

  Targets the CM US Time Offset Status parameter using the US QAM Ch Time Offset for the underlying business logic.

  US QAM Ch Time Offset values above this threshold will set the CM US Time Offset Status to Out of Spec (OOS).

- **Upstream Channel Minimum Rx Power Level**: Calculated. The lower boundary for acceptable upstream (US) receive (Rx) power from the CMTS perspective.

  Targets the CM US QAM Rx Power Status parameter using the US QAM Ch Rx Power for the underlying business logic.

  US QAM Ch Rx Power values below this threshold will set the CM US QAM Rx Power Status to Out of Spec (OOS).

- **Upstream Channel Maximum Rx Power Level**: Calculated. The upper boundary for acceptable upstream (US) receive (Rx) power from the CMTS perspective.

  Targets the CM US QAM Rx Power Status parameter using the US QAM Ch Rx Power for the underlying business logic.

  US QAM Ch Rx Power values above this threshold will set the CM US QAM Rx Power Status to Out of Spec (OOS).

- **Upstream Channel Minimum Tx Power Level**: Calculated. The lower boundary for acceptable upstream (US) transmit (Tx) power from the cable modem (CM) perspective.

  Targets the CM US QAM Tx Power Status parameter using the US QAM Ch Tx Power for the underlying business logic.

  US QAM Ch Tx Power values below this threshold will set the CM US Tx Power Status to Out of Spec (OOS).

- **Upstream Channel Maximum Tx Power Level**: Calculated. The upper boundary for acceptable upstream (US) transmit (Tx) power from the cable modem (CM) perspective.

  Targets the CM US QAM Tx Power Status parameter using the US QAM Ch Tx Power for the underlying business logic.

  US QAM Ch Tx Power values above this threshold will set the CM US Tx Power Status to Out of Spec (OOS).

- **Upstream Channel Minimum SNR**: Calculated. The lower boundary for acceptable upstream (US) SNR from the CMTS perspective.

  Targets the CM US QAM SNR Status parameter using the US QAM Ch SNR for the underlying business logic.

  US QAM Ch SNR values below this threshold will set the CM US QAM SNR Status to Out of Spec (OOS).

- **Upstream Channel Post-FEC Maximum Uncorrectable Error Ratio**: Calculated. The upper boundary for acceptable upstream (US) Uncorrectable Ratio from the CMTS perspective.

  Targets the CM US QAM Post-FEC Status parameter using the US QAM Ch Uncorrectable Packet Ratio for the underlying business logic.

  US QAM Ch Uncorrectable Packet Ratio values above this threshold will set the CM US QAM Post-FEC Status to Out of Spec (OOS).

## Downstream QAM Channel Thresholds

- **Downstream Channel Minimum Rx Power Level**: Calculated. The lower boundary for acceptable downstream (DS) receive (Rx) power from the cable modem (CM) perspective.

  Targets the CM DS QAM Rx Power Status parameter using the DS QAM Ch Rx Power for the underlying business logic.

  DS QAM Ch Rx Power values below this threshold will set the CM DS QAM Rx Power Status to Out of Spec (OOS).

- **Downstream Channel Maximum Rx Power Level**: Calculated. The upper boundary for acceptable downstream (DS) receive (Rx) power from the cable modem (CM) perspective.

  Targets the CM DS QAM Rx Power Status parameter using the DS QAM Ch Rx Power for the underlying business logic.

  DS QAM Ch Rx Power values above this threshold will set the CM DS QAM Rx Power Status to Out of Spec (OOS).

- **Downstream Channel Minimum SNR**: Calculated. The lower boundary for acceptable downstream (DS) SNR from the cable modem (CM) perspective.

  Targets the CM DS QAM SNR Status parameter using the DS QAM Ch SNR for the underlying business logic.

  DS QAM Ch SNR values below this threshold will set the CM DS QAM SNR Status to Out of Spec (OOS).

- **Downstream Channel Post-FEC Maximum Uncorrectable Error Ratio**: Calculated. The upper boundary for acceptable downstream (DS) Uncorrectable Packet Ratio from the cable modem (CM) perspective.

  Targets the CM DS QAM Post-FEC Status parameter using the DS QAM Ch Uncorrectable Packet Ratio for the underlying business logic.

  DS QAM Ch Uncorrectable Packet Ratio values above this threshold will set the CM DS QAM Post-FEC Status to Out of Spec (OOS).

## D3.0 PNM Thresholds

- **Non-Main-Tap Energy Ratio (NMTER) Threshold**: Calculated. The upper boundary for acceptable NMTER from the cable modem perspective in relation to its upstream (US) channels.

  Targets the CM Group Delay or Reflection Status parameter using the US QAM Ch NMTER Alarm Status for the underlying business logic.

  US QAM Ch NMTER values above this threshold will set the US QAM Ch NMTER Alarm Status to Out of Spec (OOS).

  If at least one associated US channel reports its US QAM Ch NMTER Alarm Status as OOS, the CM Group Delay or Reflection Status will be set to OOS.

- **Pre-Main-Tap to Total Energy Ratio (Pre-MTTER) Threshold**: Calculated. The upper boundary for acceptable PreMTTER from the cable modem perspective in relation to its upstream (US) channels.

  Targets the CM Group Delay Status parameter using the US QAM Ch PreMTTER Alarm Status for the underlying business logic.

  US QAM Ch PreMTTER values above this threshold will set the US QAM Ch PreMTTER Alarm Status to Out of Spec (OOS).

  If at least one associated US Channel reports its US QAM Ch PreMTTER Alarm Status as OOS, the CM Group Delay Status will be set to OOS.

- **Post-Main-Tap to Total Energy Ratio (Post-MTTER) Threshold**: Calculated. The upper boundary for acceptable PostMTTER from the cable modem perspective in relation to its upstream (US) channels.

  Targets the CM Reflection Status parameter using the US QAM Ch PostMTTER Alarm Status for the underlying business logic.

  US QAM Ch PostMTTER values above this threshold will set the US QAM Ch PostMTTER Alarm Status to Out of Spec (OOS).

  If at least one associated US Channel reports its US QAM Ch PostMTTER Alarm Status as OOS, the CM Reflection Status will be set to OOS.
