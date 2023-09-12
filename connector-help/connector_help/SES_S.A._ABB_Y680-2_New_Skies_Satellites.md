---
uid: Connector_help_SES_S.A._ABB_Y680-2_New_Skies_Satellites
---

# SES S.A. ABB Y680-2 New Skies Satellites

This is a custom connector that maps the ABB Microelectronics Y680-2 New Skies Satellites standby power system. The connector connects the ABB Power Manager to a third-party device and uses custom mappings that depend on the setup of the user.

Communication happens via the **Modbus-PLC** protocol.

## About

| **Range**        | **Key Features** | **Based on** | **System Impact** |
|------------------|------------------|--------------|-------------------|
| 1.0.0.x \[MAIN\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. This is a required number.
- **Bus address**: The bus address of the device. This is required.

### Initialization

No additional initialization is necessary.

## How to Use

The connector polls the parameters regularly to retrieve information. It only allows you to monitor the parameters, not to set any parameters. Communication happens via the Modbus-PLC TCP/IP protocol.

The most important parameters can be found on the **General**, **Utility**, **Generator A**, and **Generator B** pages.

## Notes

Custom mapping is used, which could change over time.
