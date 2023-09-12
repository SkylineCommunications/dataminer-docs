---
uid: Connector_help_Evertz_3080UEP
---

# Evertz 3080UEP

This driver is used to monitor the Evertz 3080UEP Universal Encoding Platform.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3080UEP-H264P60-IPA    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the storage system\]

SNMP Settings:

- **Port number**: \[The IP port of the storage system. e.g. *161\]*
- **Get community string**: \[The community string used when reading values from the device
  (default value if not overridden in the connector: *public*).
- **Set community string**: \[The community string used when setting values on the device
  (default value if not overridden in the connector: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

All data available is retrieved using the **SNMP** interface of the Evertz 3080UEP.

The **General** page contains all data related to **System.
**

The **Product Features** page enables features by adding or updating licenses.

The **Input Video Proc Control** and **Input Audio Proc Control** pages contains controls related to video and audio.

The **Scrambler Control** page contains controls related to configure the BISS1/BISS-E encryption.

The **Encoders Monitor** page contains monitoring information of video, audio and VANC.

The **Contribution Encoders** page contains encoders related controls.

The **Dolby Metadata Program 1** and **Dolby Metadata Program** **2** pages contains Dolby Metadata controls.

The **SCTE 35 GPI** page contains controls related to SCTE 35.

The **Time Reference** page contains time reference, input and output controls.

The **Preset** page contains controls related to User Preset.

The **Fault** and **Video Notify** pages contains tables related to faults and traps.

The **Decoder** page contains controls related to audio and video decoding.

The **ANC Data Control** page contains controls related to ANC.

The **IntelliGain** page containts tables related to profile audio.
