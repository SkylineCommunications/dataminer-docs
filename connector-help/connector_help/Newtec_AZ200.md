---
uid: Connector_help_Newtec_AZ200
---

# Newtec AZ200

The AZ200 Universal Switching System is a powerful and modular product designed to provide a cost-effective N+1 protection scheme for a wide variety of equipment such as modulators, demodulators, modems, converters, encoders and decoders. The AZ200 meets simple and complex demanding protection requirements by operating and controlling up to 36 internal switching modules.

## About

A **serial** connection is used in order to retrieve information from the device and to change settings of the device.

### Version Info

| **Range** | **Description**                                                                                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.1.x          | Initial version for software version 1.                                                            | No                  | Yes                     |
| 1.2.11.x         | Based on Newtec 2185 connector<br>Software version: 2.11<br>Software ID: 6234 <br>Config ID: U1184 Rx config    | No                  | Yes                     |
| 2.2.11.x         | Based on Newtec 2185 connector<br>Software version: 2.11<br>Software ID: 6234 <br>Config ID: U9901 Tx config    | No                  | Yes                     |
| 3.2.11.3         | Based on Newtec 2185 connector<br>Software version: 2.11<br>Software ID: 6234 <br>Config ID: M9111 DVB-T config | No                  | Yes                     |
| 4.2.11.x         | Based on Newtec 2185 connector<br>Software version: 2.11<br>Software ID: 6234 <br>Config ID: U1148              | No                  | Yes                     |
| 5.2.15.x         | Based on Newtec 2185 connector<br>Software version: 2.13<br>Software ID: 6234 <br>Config ID: M1164              | No                  | Yes                     |
| 6.2.6.1x         | Based on Newtec 2185 connector<br>Software version: 2.06<br>Software ID: 6234 <br>Config ID: M1165              | No                  | Yes                     |
| 7.2.13.x         | Based on Newtec 2185 connector<br>Software version: 2.13<br>Software ID: 6234 <br>Config ID: D7116              | No                  | Yes                     |
| 8.2.14.x         | Configuration ID: U6199                                                                            | No                  | Yes                     |
| 9.2.13.x         | Software version: 2.13<br>software ID: 6234 <br>Config ID: N0331                                          | No                  | Yes                     |
| 10.2.13.x        | Software version: 2.13<br>Software ID: 6234 <br>Config ID: U9987                                          | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 10.2.13.x        | 2.13                        |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default value: *5933*.
  - **Bus address**: The bus address of the device. Default value: *100*.

## Usage \[versions prior to 5.2.15.x\]

### General

This page displays parameters such as the **RMCP Version** and **Operating Mode**. It also provides access to the following information:

- Device info, including **Device Serial Number** and **Device Product ID**.
- Display, including **Display Contrast** and **Screensaver Settings**.
- Power supply, including **+12V**, **+3.3V**, **+5V** and **Power Supply 1 & 2**.
- Security, including **Expert Password** and **License Key**.
- Ethernet, including **Device IP Address** and **Device MAC Address**.
- Serial, including **Serial Interface Type** and **Device Address**.
- HTTP, including **HTTP Port**.

### Config

On this page, you can modify the **Switch Mode** and **Switch Status** for up to 6 switches.

### Alarms

This page displays all alarms deployed on the device, including the **Device** **Temperature**, **Incompatibility** and **Power Supply Voltage**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage \[from version 5.2.15.x onwards\]

### General

This page displays general information on the device, such as the **Device Hardware ID**, **Control Mode**, **Operating Mode**, **RMCP Version**, **NMS** and **Internal Temperature**.

The following commands can also be executed with the **Device Reset** parameter: **Soft**, **Factory**, **Hard**, **Data-Path** and **Upgrade**.

The page also contains the following subpages:

- **Power Supply**: On this subpage, power supply voltages can be monitored.
- **Display**: On this subpage, screensaver and display contrast can be configured.
- **Device Info**: This subpage contains information about the device, as well as the option to **Increase Capability**.
- **Serial**: On this subpage, **Serial Interface Type**, **Device Address** and **Baudrate** can be configured.
- **Ethernet**: This subpage displays the Ethernet information and also allows you to change the **Ethernet Interface**.
- **Security**: This page allows you to insert the **License Key**.

### Config

On this page, multiple settings can be configured related to the **Modulation Redundancy**.

### Alarms

This page displays all alarms deployed on the device, including the **Device** **Temperature**, **Incompatibility** and **Power Supply Voltage**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
