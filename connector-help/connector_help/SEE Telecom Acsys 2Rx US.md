---
uid: Connector_help_SEE_Telecom_Acsys_2Rx_US
---

# SEE Telecom Acsys 2Rx Us

This protocol uses SNMP to monitor the SEE Telecom Acsys 2Rx Us receiver.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                  | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Development version.                                                                                                              | \-           | \-                |
| 1.1.0.x \[SLC Main\] | Main version, with two timers: fast timer (every 30 s) for important parameters and slow timer (every hour) for other parameters. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.1.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Contains general information and allows you to switch the PS switch on and off.
- **Optical**: Contains the measurements for different optical power parameters. Also allows you to change parameters on the device. You can also normalize the optical parameters via two buttons.
- **RF**: Allows you to monitor and configure attenuation parameters.
- **Switch**: Allows you to change the switch options.
