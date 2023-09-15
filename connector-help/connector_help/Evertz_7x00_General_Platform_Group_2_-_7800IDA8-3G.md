---
uid: Connector_help_Evertz_7x00_General_Platform_Group_2_-_7800IDA8-3G
---

# Evertz 7x00 General Platform Group 2 - 7800IDA8-3G

This is a DVE exported by the Evertz General Platform Group 2 connector.

The 7800IDA8-3G reclocking distribution amplifier provides high-quality distribution of facility 3G/HD/SDSDI signals. This module features an autosensing equalized input that generates eight reclocked outputs and is especially useful in projects where long cable runs are encountered.

**Note**: This connector is considered **obsolete**. Refer to the notes below for more information.

### Product Info

| **Range** | **Supported Firmware**                      |
|-----------|---------------------------------------------|
| 1.0.4.x   | 2.7 build 40 - Card Name 7800IDA8-3G+IG+DMX |

## Configuration

This DVE is automatically created by the parent element using the [Evertz 7x00 General Platform Group 2](xref:Connector_help_Evertz_7x00_General_Platform_Group_2) connector. It does not require additional configuration.

## How to use

This DVE is used for the supervision and control of the card 7800IDA8-3G. The communication uses the frame to access the card.

It is also capable of listening for unsolicited messages in the form of traps. Based on these traps, the corresponding tables will be updated, and the relevant information will be polled again.

The element consists of the following pages, similar to the web interface:

- General
- Audio Control
- Video Control
- Misc Control
- DMX Control
- UMX Control
- Thumbnail
- Audio Mixer
- IntelliSync Configuration
- IntelliGain Configuration
- IntelliGain Threshold
- IntelliGain Program
- IntelliTrak VANC Config
- Fault Control
- IntelliGain Fault Traps
- Video Fault Traps
- Audio Fault Traps
- Traps

## Notes

This card integration was originally developed as a DVE of the [Evertz 7x00 General Platform Group 2](xref:Connector_help_Evertz_7x00_General_Platform_Group_2). To improve performance, it has now been implemented as a standalone connector. To integrate this card, the connector [Evertz 7800IDA8-3G](xref:Connector_help_Evertz_7800IDA8-3G) should be used.
