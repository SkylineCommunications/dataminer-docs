---
uid: Connector_help_LG_Display
---

# LG Display

**LG Display** Digital signage provides digital audiovisual communication solutions through standard monitors or interactive monitors, located in different places in order to provide the best visual experience in front of a product, service, event or situation.

## About

This connector can be used to manage the LG Display settings, such as the picture or sound settings of the digital signage, using SNMP parameters.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The IP port of the device.
- **Get community string**: Custom value: "*lgecommer*".
- **Set community string**: Custom value: "*lgecommer*".

## Usage

### General

This page consists of the following sections:

- **General**: Displays the system information of the device, such as the **System Name,** **System Description,** **System Up Time** and **System Contact**
- **Picture Settings**: Allows you to set the screen information, with the parameters **Input Select, Aspect Ratio, Contrast, Brightness, Color, Tint, Sharpness** and **Color Temperature**
- **Sound Settings**: Allows you to set the sound information, with the parameters **Balance, Screen Mute, Volume Mute** and **Volume Control**
- **Management**: Allows you to set the **Power, Energy Saving, OSD Select, Remote Control Lock Mode, ISM Method** and **Auto Configuration.**
