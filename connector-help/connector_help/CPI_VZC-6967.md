---
uid: Connector_help_CPI_VZC-6967
---

# CPI VZC-6967

The CPI VZC-6967 connector is a **serial** connector used to monitor and configure the CPI VZC-6967 device.

## About

The CPI VZC-6967 is an **amplifier**. The connector uses serial communication to monitor and configure the device. This means that it sends commands to the device and receives a response for every command.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Not available               |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device. (Between *48* and *111*.)

## Usage

### General

This page displays general information about the device, e.g. the **CMPA** **Model** and **Computer** **Information** **Version**. With the page buttons, you can also display extra information about the **Time** and **ALC**. The **Transmit** and **Reset to Defaults** buttons can be used to respectively transmit and reset the device.

### Amplifier

This page displays information about the amplifier. The **RF** **limits** are displayed and can also be enabled or disabled.

### Switch Infos

This page displays switch information. It shows whether the different switch settings are inhibited or not.

### Linearizer

This page displays the linearizer settings. It displays the state of the linearizer and several measurements. You can also configure certain linearizer settings on this page via the **Set Linearizer** page button.

Switch Controller

This page displays the switch controller status through **Mode, System, CIF Control and AMP Fault** and positions 1 to 4.

### Alarms

This page displays the alarms in the system. Via the **Alarm Config** page button, alarm thresholds can be configured.

### Web Interface

This page displays the web interface of the amplifier. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the protocol CPI VZC-6967 supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Physical fixed interfaces:

- **Input1**: Is not linked with any parameters and is of type in.
- **Output1**: Is not linked with any parameters and is of type out.

### Connections

#### Internal Connections

There is a **fixed** connection between interfaces **Input1** and **Output1**.

## Revision History

DATE VERSION AUTHOR COMMENTS

30.05.2011 1.0.0.1 SV2, Skyline Initial version

17.09.2012 1.0.0.2 SV2, Skyline NF: Integral Linearizer Option

03.12.2013 1.0.0.3 JVT, Skyline Added DCF support

03.04.2018 1.0.0.4 JDI, Skyline Changed the measurement of parameters "Heater Elapsed Time" and "Beam on Elapsed Time" to interpret received value as hours instead of seconds.

10.01.2019 1.0.0.5 RBL, Skyline Added Switch Controller support
