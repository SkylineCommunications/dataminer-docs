---
uid: Connector_help_Emcore_Medallion_6000
---

# Emcore Medallion 6000

This connector retrieves information from the Emcore Medallion 6000 via SNMP. The Medallion 6000 series is a family of state-of-the-art high-performance 1550 nm externally-modulated CATV fiber-optic transmitters. Advanced features such as built-in field-adjustable SBS control and electronic dispersion compensation allow these transmitters to be quickly optimized in the field for any link or application without the need to procure specifically tuned transmitters.

## About

The **Emcore Medallion 6000** connector displays the general information, alarm configuration status, network configuration, power supply and fan unit information of the device. All information is retrieved using SNMP.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

## Usage

### General

This page displays general information about the device, including the **Device Type**, **Serial Number**, **Year of Manufacture**, **Software Version** of the **TX** and **SNMP**, **temperature** of the module and **network information**.

This page also has three subpages, which you can access through page buttons:

- The **Front Panel LED Status** subpage contains information about the laser status (*green*/*red*), including the **Laser ON Rear Panel**, and shows whether any minor or major alarm are active.
- The **Fan Units** subpage contains a table with all fan units available in the system. The table also shows the **Current** and the **Alarm** state for each fan unit.
- The **Power Supplies** subpage contains information such as the **Supply Type**, the **Cooling Fan** status, and all the **measurements** for each **output**.

### Network Configuration

This page contains settings related to the **System and Network Configuration**, as well as the **Front Panel** and **SNMP** **Configuration**.

In addition, it contains some **reset options** provided by the device.

The page also has several subpages, which you can access through page buttons:

- The **Transmitter Data** page contains information regarding the **Transmitter RF Input** and the **Transmitter Lasers**.
- The **CATV/SAT Data** page contains information related to the **CATV**, **SAT**, **SBS** and **fiber optics**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
