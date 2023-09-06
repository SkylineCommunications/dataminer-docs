---
uid: Connector_help_Evertz_570J2K-HW-X19
---

# Evertz 570J2K-HW-X19

The 570J2K-HW-X19 is a multi-channel J2K encoding and decoding platform, with direct conversion of up to 12 signals to direct mezzanine compression via JPEG2000.

This driver uses SNMP to poll data from this device based on the encoder and decoder web interface layout.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                            |
|-----------|-----------------------------------------------------------------------------------|
| 1.0.0.x   | \- Encoder: V1.0.0B20200826-1122-G-U9E-8A- Decoder: V1.0.0B20210325-1310-H-U9D-8A |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

- **General**: Contains all the general system information such as the **System Name** and **Location.**
- **System**: Contains several tables where you can monitor and configure system-related parameters, as well as standalone parameters related to temperature, NMOS control and time management.
- **Product Features**: Contains license control parameters and a table listing the supported features.
- **DIN Output Control**: Contains several tables with output control settings, as well as a parameter that allows you to enable or disable FS Sync Mode.
- **IP Output Control**: Contains two tables where you can configure IP output settings. The **Decoder** page button provides access to additional tables with settings, as well as parameters related to the payload type.
- **IP Input Control:** Contains several tables where you can configure IP input settings. The **Decoder** page button displays an additional table with decoder IP input settings. The **Encoder** page button displays several tables with encoder IP input settings.
- **Encoder Control**: Contains encoder configuration tables, including phase adjustment and audio output control tables.
- **Decoder Control**: Contains decoder configuration tables, including an input program control and audio selection table.
- **PTP and Master PCR Control**: Contains numerous PTP and master PCR configuration parameters, including the selection of Main SFP, Backup and Fail Over Mode. Via the **Decoder** page button, you can configure the global PTP domain number and the GMID of the incoming PTP.
- **DSS Control**: Contains several tables with DSS settings.
- **Program Control Encoder**: Contains the Element Stream Input Table.
- **Program Control Decoder**: Contains program control settings.
- **IP Input Monitor**: Contains tables that allows you to monitor the IP input stream. The **Decoder** page button displays a table with similar information specific to the decoder. The **Encoder** page button displays IP input measurements.
- **Decoder Program Monitor:** Contains several program monitoring tables**.**
- **System Notify**: Allows you to configure the Temperature Threshold and Received Bandwidth Threshold. Also shows if there is any system fault present in the System Notify Table.
- **Input Notify**: Indicates if there are input faults for each of the different inputs.
- **Decoder Notify**: Indicates if decoder faults are present, e.g. TS Input Missing and Audio PID Missing.
