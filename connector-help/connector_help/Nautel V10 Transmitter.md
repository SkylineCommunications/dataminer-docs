---
uid: Connector_help_Nautel_V10_Transmitter
---

# Nautel V10 Transmitter

The **Nautel V10 Transmitter** is a solid-state, VHF (very high frequency), frequency-modulated broadcast transmitter.

The transmitter contains:

- 8 RF power modules
- 1 or 2 IPA modules
- 1 or 2 low-voltage power supplies (LVPS)
- 1 or 2 fan supplies
- a switching power supply for each IPA and RF power module

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | NA                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: This is not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, default value: *public*.
- **Set community string**: The community string used when setting values on the device, default value: *private*.

## How to use

This driver contains the following pages:

- **General**: Displays general parameters such as the **Device Type, Device Description** and **Firmware Version**. Also contains page buttons for **Cutback Level**, **Active Preset** and **Shutback**.
- **Status**: Displays status parameters.
- **Fan**: Displays **Fan Speed** and **Fan Fail** parameters.
- **IPAQ**: Displays **IPAQ 3** and **IPAQ 4** parameters.
- **Transmitter**: Displays parameters related to the transmitter.
- **Temperature**: Contains temperature information.
- **Fail**: Displays the **Module (A, B, ... , H) Fail** and **PS (A, B, ... , H) Fail** parameters, as well as **EEPROM Fail** and **IPA Module Fail** parameters.
- **Module** **A - H**: These pages display parameters specific to modules A to H.
- **Web interface**: Provides access to the web interface of the Nautel V10 Transmitter. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
