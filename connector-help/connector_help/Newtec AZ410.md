---
uid: Connector_help_Newtec_AZ410
---

# Newtec AZ410

This driver allows you to monitor and operate the Newtec AZ410 satellite modem via SNMP.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |
| 1.0.1.x   | Driver review    | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 7.0                    |
| 1.0.1.x   | 7.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page displays information regarding the device itself, such as Device Mode, RMCP Version, System Time, System Uptime, Device Reset and Device Temperature.

Note that the **Device Mode** parameter influences a number of commands that can be sent to the device, as some of these are only accessible in **Expert Mode**.

The **Device Reset** parameter allows you to send a reset command to the device (both in Normal and Expert Mode).

In the Settings section of the page, four page buttons provide access to subpages where you can monitor and control general system settings such as **SNMP**, **Ethernet**, **serial** settings and system **alarms**.

### Serial

This page allows you to monitor and control the serial settings associated with the system.

### Ethernet

This page allows you to monitor and control the Ethernet settings associated with the system.

Via page buttons, you can access page buttons that allow more detailed configuration:

- **Interfaces**: Contains interface-related settings such as Auto Negotiation, Speed Advertisement, etc.
- **Redundancy**: Allows you to monitor and configure redundancy parameters such as Ethernet Interface Redundancy, Unit Redundancy State,etc.
- **QoS**: Allows you to monitor and configure QoS parameters such as Ethernet RX QoS, QoS on CPU load, and Rx Qos Rules.
- **Modem**: Allows you to monitor and configure network parameters such as Own IP Address A& B, Default Gateway, Multicast Interface, etc.
- **IP Encapsulation**: Allows you to monitor and configure encapsulation parameters such as Default Output MAC, Ethernet Output, Encapsulation Protocol, Promiscuous Mode, etc.
- **Signaling**: Allows you to monitor and configure the Signaling IP and Modulator to Demodulator Signaling parameters.

### SNMP

This page allows you to monitor and configure important SNMP setting such as Read Only Community, Read Write Community, Trap IP Address and Trap Community.

### Alarms

This page displays the alarm parameters for the entire modem system.

### Control

This page allows you to configure multiple settings such as Device Sleep Mode, Functional Mode, Reference Clock Selection, multiple types of Device Reset, External Converter Polarity and more.

### Monitor

This page allows you to monitor the power supplies of the device and the internal temperature.

### Modulator

This page allows you to monitor the modulator. Via the **Configuration** page button, you can configure multiple settings of the modulator.

In version 1.0.0.2, a configurable parameter is added to the Modulator TX board, based on the SOL interface (Serial-Over-Lan).

### Demodulator

This page allows you to monitor the demodulator. Via the **Configuration** page button, you can configure multiple settings of the demodulator.
