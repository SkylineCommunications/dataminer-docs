---
uid: Connector_help_Standard_DataMiner_PTP_Device
---

# Standard DataMiner PTP Device

The Standard DataMiner PTP Device is a **mediation** protocol used by the **PTP application** to easily get data from PTP devices.

The following connectors are currently mediated with the latest version:

- Arista Manager
- Bridge Technologies VB Probe Series
- CISCO Nexus
- directOut montone.42
- Evertz 5700MSC
- Evertz 5700MSC - PTP Interface
- Generic Edge Chassis
- Generic Edge Chassis - PTP Card
- Generic Switch
- Hirschmann - a Belden Brand MAR 1040
- Imagine Communications Selenio Network Processor
- Lawo HD Core Ravenna
- Lawo Power Core
- Meinberg LANTIME IMS-HPS - PTPv2 Instance
- Meinberg LANTIME IMS-HPS API V10 - PTPv2 Instance
- Meinberg Lantime M3000 - PTPv2 Module
- Mellanox Technologies MLNX-OS Manager
- Pebble Beach Dolphin
- Riedel Communications MediorNet MuoN (FusioN and VirtU)
- Ross Video Iggy-AES16.16
- Ross Video Newt-IPR-3G-4S
- Seiko Time Server Pro. TS-2950
- Tektronix Prism
- Tektronix SPG8000 - PTP Interface

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                      | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- Arista Manager - Lawo HD Core Ravenna - Lawo Power Core - Meinberg Lantime M3000 - PTPv2 Module - Skyline PTP (application and scripts) | \-                      |

## Configuration

### Initialization

This is a **mediation** protocol, which means no element needs to be created. The only thing needed to activate this mediation protocol is to set it as **Production**.

As soon as this is done, this mediation protocol will be active for all mediated protocols.

## Notes

This connector should not be accessed directly by the user.

It is a mediation protocol that is used by the **PTP application** to easily get the values of the different PTP parameters from each supported device.

The PTP-related parameters of the mediated protocols that cannot be linked to a mediation parameter are grouped in a custom tag \<RelatedProtocols\>. This tag is used by the Skyline PTP app.
