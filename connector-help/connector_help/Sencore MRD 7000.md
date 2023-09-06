---
uid: Connector_help_Sencore_MRD_7000
---

# Sencore MRD 7000

The **Sencore MRD 7000** is a receiver decoder that supports up to 8 services (16 channels) of audio processing for **MPEG1/2**, **AAC** and **Dolby AC3/AC3+/Dolby E/ATMOS**.

Multichannel decoding allows the MRD 7000 to process up to 4x HD services or 1x UHD service in a 1RU chassis.

Output options include 4x3G-SDI (two sample interleave & four quadrant), 12G-SDI, HDMI 2.0B and SMPTE 2110 via 10 GB or 25 GB fiber.

## About

### Version Info

| **Range**            | **Key Features**                                                                              | **Based On** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                               | \-           | \-                |
| 1.0.1.x              | Redundant pollingTraps TableSMPTE-2110 Modules Table                                          | 1.0.0.1      |                   |
| 1.0.2.x              | Input table relationsDriver fixes                                                             | 1.0.1.1      | \-                |
| 1.0.3.x              | SMPTE Audio Display Key ChangesSMPTE Output table                                             | 1.0.2.3      | \-                |
| 1.0.4.x \[SLC Main\] | Multiple display keys changed to retrievedDecoder alias column added/appended to display keys | 1.0.3.1      |                   |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.7                    |
| 1.0.1.x   | 1.8                    |
| 1.0.2.x   | 1.9                    |
| 1.0.3.x   | 1.10                   |
| 1.0.4.x   | 1.10                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.4.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the conencted device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.
