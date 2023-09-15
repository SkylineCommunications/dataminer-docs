---
uid: Connector_help_Aurora_Network_CH3000
---

# Aurora Network CH3000

The Aurora Network CH3000 is a connector of the type Management Element. It gathers information from the Aurora Networks CH3000 chassis and the connected cards, allowing the user to check the position of a card, the type of card and specific card information, including the status and alarms.

## About

The Aurora Network CH3000 is a chassis capable of storing 32 modules. It supports both passive and active modules.

The communication method used is **SNMPv1**.

Note: This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors" below.

### Version Info

| **Range**     | **Description**                                                                                                                                           | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version.                                                                                                                                          | No                  | Yes                     |
| 1.0.1.x              | Some parameters descriptions have been modified, which can cause the loss of alarms and trend data for these parameters.                                  | No                  | Yes                     |
| 1.0.2.x              | Added support for HT35xxH & HT330xH.                                                                                                                      | No                  | Yes                     |
| 1.0.3.x              | Fixed DVE creation for HT35xxH & HT330xH. Added AT Status Unsupported Cards table. Renamed HT330xH to HT33xxH. **Impact**: The element must be recreated. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |
| 1.0.2.x          | Unknown                     |
| 1.0.3.x          | Unknown                     |

### Exported connectors

| **Exported Connector**                                                                                                                            | **Description**     |
|--------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|
| [Aurora Network CH3000 - CC300x](xref:Connector_help_Aurora_Network_CH3000_-_CC300x)                                                     | AT controller       |
| [Aurora Network CH3000 - OS32MxM](xref:Connector_help_Aurora_Network_CH3000_-_OS32MxM)                                                   | Optical switch      |
| [Aurora Network CH3000 - PS30xx](xref:Connector_help_Aurora_Network_CH3000_-_PS30xx)                                                     | Power supply        |
| [Aurora Network CH3000 - CX300x](xref:Connector_help_Aurora_Network_CH3000_-_CX300x)                                                     | Controller          |
| [Aurora Network CH3000 - AT33xx](xref:Connector_help_Aurora_Network_CH3000_-_AT33xx)                                                     | Transmitter         |
| [Aurora Network CH3000 - AT351x](xref:Connector_help_Aurora_Network_CH3000_-_AT351X)                                                     | Transmitter         |
| [Aurora Network CH3000 - AR3002](xref:Connector_help_Aurora_Network_CH3000_-_AR3002)                                                     | Transmitter         |
| [Aurora Network CH3000 - AB3S21](xref:Connector_help_Aurora_Network_CH3000_-_AB3S21)                                                     | AB switch           |
| [Aurora Network CH3000 - FA35xx](xref:Connector_help_Aurora_Network_CH3000_-_FA35xx)                                                     | Optical amplifier   |
| [Aurora Network CH3000 - AT355x](xref:Connector_help_Aurora_Network_CH3000_-_AT355x)                                                     | Transmitter         |
| [Aurora Network CH3000 - HT330x](xref:Connector_help_Aurora_Network_CH3000_-_HT330x) (Obsolete since 1.0.2.x)                            | Transmitter         |
| [Aurora Network CH3000 - OS32S1](xref:Connector_help_Aurora_Network_CH3000_-_OS32S1)                                                     | AB switch           |
| [Aurora Network CH3000 - DR3402](xref:Connector_help_Aurora_Network_CH3000_-_DR3402)                                                     | Receiver            |
| [Aurora Network CH3000 - AR3001](xref:Connector_help_Aurora_Network_CH3000_-_AR3001)                                                     | Receiver            |
| [Aurora Network CH3000 - AR3044](xref:Connector_help_Aurora_Network_CH3000_-_AR3044)                                                     | Receiver            |
| [Aurora Network CH3000 - DX3515](xref:Connector_help_Aurora_Network_CH3000_-_DX3515)                                                     | Digital transponder |
| [Aurora Network CH3000 - DX3032S](xref:Connector_help_Aurora_Network_CH3000_-_DT3032S)                                                   | Digital transceiver |
| [Aurora Network CH3000 - DR3450N](xref:Connector_help_Aurora_Network_CH3000_-_DR3450)                                                    | Receiver            |
| Aurora Network CH3000 - HT33xxH (see [Aurora Network CH3000 - HT330x](xref:Connector_help_Aurora_Network_CH3000_-_HT330x))               | Transmitter         |
| Aurora Network CH3000 - HT35xxH (see [Aurora Network CH3000 - HT330x](xref:Connector_help_Aurora_Network_CH3000_-_HT330x))               | Transmitter         |
| Aurora Network CH3000 - AT Status Unsupported (see [Aurora Network CH3000 - HT330x](xref:Connector_help_Aurora_Network_CH3000_-_HT330x)) | Transmitter         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains SNMP device information such as the name and the physical location of the device.

### Slots

This page lists the available slots with the corresponding information.

**DVE Naming format** enables users with security level 3 or greater to change the DVE naming syntax and to enable or disable the use of slot descriptions in DVE naming. Be careful when you use this functionality: **changing DVE names can cause the loss of alarm and trend history**.

Please note that the DVE Name and Description columns in the **Slots** table are also locked for users who do not have at least security level 3.

### Shelf

This page contains information regarding the statuses of all slots in the shelf.

### Communication Modules

This page contains information on all the modules related to the Aurora CX3001 and CX3002.

### AT Controller

This page contains information about the analog transmitter controller modules connected to the chassis. It displays tables with information about the controller status and alarms.

### Analog Transmitter

This page contains information about the analog transmitter modules connected to the chassis. It displays tables with information about status, alarms and configuration.

### Analog Receiver

This page contains information about the analog receiver modules connected to the chassis. It displays tables with information about status, alarms and configuration.

### Quad Standard Gain Analog Return Receiver

This page contains information about the Quad Standard Gain Analog Return Receiver modules connected to the chassis. It displays tables with information about status, alarms and configuration.

### AB Switch

This page contains information about the AB Switch modules connected to the chassis. It displays tables with information about status, alarms and configuration.

### Dual Return Receiver

This page contains information about the Dual Return Receiver modules connected to the chassis. It displays tables with information about status, alarms and configuration.

### Optical Amplifier

This page contains information about the Optical Amplifier modules connected to the chassis. It displays tables with information about status, alarms and configuration of the amplifier and the laser.

### Multi Channel Receiver

This page contains information about the Multi Channel Receiver modules connected to the chassis. It displays tables with information about status, alarms and configuration for each of the receivers.

### Power Supplies

This page contains crucial information regarding the power supplies, such as the voltage and current.

### Digital Transponder

This page contains crucial information regarding the DX3515 module.

### Digital Transceiver

This page contains information about the DT3032S module connected to the chassis. It displays tables with information about status, alarms and configuration.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
