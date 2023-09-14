---
uid: Connector_help_Satcom_Technologies_SCR14000BU_Ku-Band_Up_Converter
---

# Satcom Technologies SCR14000BU Ku-Band Up Converter

The SCR14000BU is a KU-Band upconverter. This connector allows you to monitor and configure such devices. The device is comprised of several modules, which include a Reference Module, Radio Frequency Module, Synthesizer Module and Converter Module.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.21                   |

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

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page of the element, you will find status information and settings in the following main sections:

- **System Information**: Contains basic information, such as **firmware versions**, **operational time**, etc.
- **Unit Information**: Contains status information and configured values for the device, including the status of the modules.
- **Hardware Status**: Contains status information related to the **amperage**, **voltage** and **temperature** of the device.
- **Faults**: Displays the fault list of the unit, with a great number of different points being checked for status (displayed as *Ok* or *Not Ok*). These include Ethernet Controller, Power Supply, Front Panel, Synthesizer, Fans, etc.

On the **Configuration** page, you can configure the **Radio Frequency Gain**, **Radio Frequency Output** and **Mute Control**. You can also **reset** the unit or its faults there.
