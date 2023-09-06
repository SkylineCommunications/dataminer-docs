---
uid: Connector_help_Specialty_Microwave_Corp_8489-501
---

# Specialty Microwave Corp 8489-501

The 8489-501 is a 1:2 protection switch. It allows operators to control waveguide switches to desired positions. The system mechanism provides switching and combining operations for radio frequency (RF) outputs of high-power amplifiers (HPAs).

This connector allows for quick monitoring of front panel information and configuration of switch position.

## About

### Version Info

| **Range** | **Key Features**                                                                             | **Based on** | **System Impact** |
|-----------|----------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.1   | Initial version:- Monitoring of front panel information.- Configuration of switch positions. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SERIAL Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device. Default: *49*. range: *33* - *126.*

### Initialization

To make sure commands from DataMiner will work, set the **Control Status** setting on the device to *Remote*.

## How to use

The **General** page displays all the front panel information. The following settings can be configured there as well:

- **Unit Mode**: Can be set to *Auto* or *Manual*. If you want to be able to manually change positions of switches, this mode must be set to *Manual*.

- **Switch Positions:** These can be configured so that the switches are using their main HPA or the standby HPA.

- **Unit State**: Sets both switches to specific state at the same time instead of setting them individually.

- *Normal*: Both switches are set to their main HPA.
  - *Backup 1*: Switch 1 is set to HPA Standby and Switch 2 is set to its main HPA.
  - *Backup 2*: Switch 2 is set to HPA Standby and Switch 1 is set to its main HPA.
