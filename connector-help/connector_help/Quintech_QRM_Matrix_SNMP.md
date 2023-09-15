---
uid: Connector_help_Quintech_QRM_Matrix_SNMP
---

# Quintech QRM Matrix SNMP

This connector communicates with the Quintech QRM Matrix via SNMP. It allows the user to view the current state of the device and to configure the device functionality. The Quintech QRM wideband RF routing matrix makes it possible to work with different matrix sizes and matrix expansion. It provides linearity, insolation and gain flatness. It includes the Q-route technology to quickly and automatically restore signal connections in case of a failure of an amplifier or component along the signal path. It has a full fan-out (distributive) non-blocking matrix operation allowing connection of an input signal to any or all outputs.

## About

This is an **SNMP** connector with only 22 OIDs. Two of them provide the functionality to obtain the information from the device using a request/response protocol. The requests are implemented sequentially to retrieve the information from the device. It is also possible to send configuration commands and update the device status accordingly. The device provides several information queues. Currently, the connector sequentially reads the message queue where alarms can be found. In case this queue overflows, a trap will be sent with the contents of the queue.

The communication method is SNMP, but the connector uses a request/response protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Supported firmware version

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Fv 4.55                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page includes general information about the device, such as the **Model**, **Model Number**, **Firmware Version**, **Full Firmware Version**, **Extended Firmware Version**, **Protocol Version**, **CPU Temperature**, **LCD** and **Keypad Lock**.

The page also includes page buttons to the following subpages:

- **Power Supply**: Displays the current state of the power supplies, including warning, failure and LED status.
- **QRM Status**: Displays the current state of the QRM operation. **Retrieving Information** shows the status of the operation. **Time Frame to Reset Polling Status** allows you to set the time the connector will wait before resetting the polling status. **Delay Between Request Response Pair** allows you to adjust the delay in communication with the QRM interface.
- **IP Config**: Contains parameters related to the IP configuration of the device, such as **Manager IP**, **IP Address**, **IP Subnet**, **IP Gateway**, **DHCP** and **Ethernet Port**.

### Inputs

This page contains the **Inputs Overview** table, which shows the inputs that are currently present in the matrix. For each input, the connector displays the **Index**, **Description**, **Custom Description**, **Warning Threshold Level** and **RF Level**. The **Description** and **Warning Threshold Level** allow you to issue configuration commands to the device.

### Outputs

This page contains the **Outputs Overview** table, which shows the outputs that are currently present in the matrix. For each output, the protocol displays the **Index**, **Description**, **Custom Description**, **Connected Input**, **Connected Input Description**, **Custom Description**, **RF Level**, **Gain Control Mode**, **Manual Gain Control Level** and **Automatic Gain Control Level**.

### Matrix

This page contains the **Matrix**, which allows you to connect an input signal to any or all of the outputs.

### Current Message Queue

This page contains the **Current Message Queue** table, showing the current messages in the device message queue.

## Revision History

26/03/2018 1.0.0.1 JRI, Skyline Initial version.

01/06/2018 1.0.0.2 JRI, Skyline Fixed issues resulting in RTEs. Returned to the version 1.0.0.9 of the Helper class.

08/06/2018 1.0.0.3 JRI, Skyline Implement QA fixes.

21/06/2018 1.0.0.4 JRI, Skyline Fixed QA 2nd remarks. Adapted Output table to be able to select the connected input from drop-down list.

13/08/2018 1.0.0.5 JRI, Skyline Added delay between pairs to improve performance when two devices are accessing the QRM interface.

## Notes

In case multiple elements run on the same DMA with SNMPv3 enabled, the elements will go into timeout state because they all use the same Engine ID. Reverting to SNMPv2 solves this issue.
