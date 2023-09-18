---
uid: Connector_help_Crystal_Vision_AVDelay_3G
---

# Crystal Vision AVDelay 3G

The **AVDELAY 3G** is an audio/video delay that has been designed for correcting large lip-sync errors on incoming 3 Gb/s, HD or SD signals containing up to four groups of embedded audio. It has the ability to change the relative audio/video timing by several seconds in either direction. It is suited for any environment using High Definition with embedded audio. AVDELAY 3G fits in the standard frames (available in 4U, 2U, 1U and desk top box) and is used with the RM62 rear module to access all the inputs and outputs. With the addition of the FIP optical input or FOP optical output, cable length is not an issue when sending and receiving signals from beyond the local signal bay. The RM62 is configured for fiber connectivity.

This connector communicates with the AVDELAY 3G using an SNMP connection. SNMP traps can be retrieved when this is enabled on the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**      |
|-----------|-----------------------------|
| 1.0.0.x   | MIB revision: 201206120843Z |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The slot ID of the device (range: *1* - *32*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element contains the following pages with status and configuration information: **General**, **Video Control**, **Delay Group** for each audio, **Audio Delay**, **Preset & Reset**, **Alarm** and **Alarm Groups**.

The settings on the **Alarm** and **Alarm Groups** page can be used to configure the device in such a way that the GPO-6 LED will show an alarm depending on the configured settings.

## Notes

The slot ID of the device is implemented as a 1-based integer in accordance with the web interface, but the communication functionality of the device requires a 0-based implementation. The received traps are filtered by comparing the trap's slot binding with the configured slot number.
