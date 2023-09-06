---
uid: Connector_help_International_Datacasting_Star3
---

# International Datacasting Star3

The International Datacasting Star3 is an integrated receiver/decoder device (IRD). This driver allows complete monitoring of such devices.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

## How to use

The element consists of the following data pages:

- **General**: Contains clock-related parameters as well as firmware information and general hardware details. Also provides access to the **Set Input**, **Service Info**, **Device Info** and **Polling Config** pages, and allows you to manually **Refresh** data and **Reboot** the device.
- **DVBTS**: Contains basic parameters related to DVBTS, namely PIDs, MPE PIDs, Flexkey IP and Port, TS-Input and Audio Mode.
- **Decoder**: Contains information about all audio and data channels.
- **Alarm**: Allows you to monitor the device with a complete set of alarm and notification parameters.
- **Control and Output**: Contains information regarding the control input and output configuration, including ASI and IP details.
- **Measurements**: Contains generic information regarding Control Mode, NCCF and Audio Status. Also provides access to **Measurements Input** and **Measurement Decoder** pages.
