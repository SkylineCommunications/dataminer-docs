---
uid: Connector_help_NEC_iPASOLINK_VR_x
---

# NEC iPASOLINK VR x

The iPASOLINK VRx is used as microwave and optical transporter equipment. This connector allows you to monitor this equipment via SNMP.

## About

### Version Info

| **Range**            | **Description**          | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.         | No                  | Yes                     |
| 1.0.1.x \[Obsolete\] | Metering stats overhaul. | No                  | Yes                     |
| 1.0.2.x \[SLC Main\] | Upgraded to SNMPv2.      | No                  | Yes                     |

### Product Info

| **Range**         | **Supported Firmware** |
|-------------------|------------------------|
| 1.0.0.x - 1.0.2.x | 04.01.14               |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page displays basic system information such as the **PM Type**, **Primary Address**, and **Equipment Type/Configuration**, as well as tables with information on maintenance, events, and traps.

### Cards

On this page, a tree control displays all installed cards along with their status.

### IDU and ODU

Two tree controls are used to display inventory information of the ODU and the MDU.

### Provisioning

This page contains information related to the **PTP Clock**.

### Alarm/AIS Setting

This page shows all alarms and status information of the ODU and the MDU monitor and control item.

### Metering

This page displays measurement information of the ODU and the MDU, such as **TX Power** and **RX Power**.

### PMON/RMON Report

This page contains performance monitoring information of the network equipment, such as the MAX hold and MIN RX level, as well as remote network monitoring information.

In addition, the following summary statuses of the equipment are displayed: Link Performance Monitor (**PMON**), Remote Network Monitor (**RMON**), ODU, Ctrl Card, etc.

### Configuration

This page displays the basic system configuration of the equipment.

### Network Management Setting

This page contains the interface information to connect the network (manager) for the agent (NE), such as the neighbor NE connection, the iPASONLINK VR x NE ports, and the network protocol configuration, such as SNMP.

### Maintenance Control

This page displays the OAM capabilities of the interface (loopback control) and RSTP/MSTP control.

### Web Interface

This page displays the web interface of the device. The client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
