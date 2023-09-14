---
uid: Connector_help_SA_Phoenix
---

# SA Phoenix

This protocol can monitor and control the **SA Phoenix** device, an HMS gateway that controls other HFC devices.

## About

This protocol monitors and controls an **SA Phoenix** device through SNMP calls. The information from the device is polled as follows:

- Every 12 hours for almost permanent information
- Every 30 minutes for medium to long-term information
- Every 15 minutes for short to medium-term information
- Every 10 minutes for short-term information

SNMP traps can be retrieved if this is enabled on the device.

### Version Info

| **Range** | **Description**                                                        | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                        | No                  | No                      |
| 1.1.0.x          | Device Settings Table edited, trap receiver added, display time in UTC | No                  | No                      |
| 1.1.1.x          | Auto Discovery Function and Data Distribution Duplex added.            | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**                |
|------------------|--------------------------------------------|
| 1.0.0.x          | Compatible with software version 01.05.00. |
| 1.1.0.x          | Compatible with software version 01.05.00. |
| 1.1.1.x          | Compatible with software version 01.05.00. |

## Installation and Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Address of the device (optional field).

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General Settings

This page displays general information about the device, such as:

- **Logical ID** (user-defined)
- **Vendor**
- **Model Number**
- **Serial Number**
- **Vendor Info**
- **Main Software Version**
- **Boot Software Version**
- **IP Address**
- **Internal Temperature**

In addition, you can also reboot the device and perform a factory reset with the **Reboot** and **Factory Reset** buttons respectively, or consult the return path level via the **Return Path Level...** page button.

### System Information

This page displays the following information:

- **Description**
- **Object Identification**
- **Name** (user-defined)
- **Contact** (user-defined)
- **Location** (user-defined)
- **Up Time**
- **Services**

### Operation Settings

On this page, you can configure the following settings:

- **MAC Commands Time-Out**
- **SNMP Commands Time-Out**
- **Message Time-Out**
- **Response State Change Deadband**
- **Operation Mode**
- **Contention Broadcast Interval**

In addition, there are several page buttons that provide access to more settings:

- **Trap Destinations...**
- **Registration Settings...**
- **Extended Tracing...**
- **Time Settings...**

### Hardware Settings

On this page, the following general settings are displayed:

- **Temperature Alarm**
- **Transmitter Locking**
- **Receiver Locking**
- **Main Board Calibration Data**
- **RF Receiver \[1-8\] Calibration Data**
- **Default Initialization**
- **Hardware Initialization**
- **Receiver Frequency** (also user-defined)

You can also find the following **RS485 Transmitter** **Settings**:

- **RS485 Administration State**
- **RS485 Operation State**

The following **RF Transmitter Settings** can also be configured here:

- **RF Administration State**
- **RF Operation State** (read-only)
- **RF Frequency**
- **RF Power Level**

Finally, the **Receiver Settings...** page button provides access to the receiver settings.

### Device Settings

On this page, you can view and perform operations on the devices monitored by the AS Phoenix equipment. Below you can find a description of each page button related to the *AS Phoenix* general settings:

- **Edit Device Settings:** Opens a page with information on the deletion of network addresses.
- **Network Addresses:** Opens a page with information on search criteria of devices.
- **Bad Devices:** Opens a page with information on blacklisted devices.

Below these page buttons, you can find the following buttons:

- **Reset all Devices**: Clears the **Device Settings** table.
- **Load**: Loads every whitelisted device into the same table.

Finally, the **Create...** page button can be used to create DataMiner elements based on the **Device Settings** table.

### Statistics

On this page, you can view any measurable information from the following four protocols: **IP**, **ICMP**, **TCP** and **UDP**.

For the IP protocol, the following page buttons display additional information:

- **Statistics**: Displays additional statistical information.
- **Addressing**: Displays address information.
- **Net to Media**: Displays net to media information.

For the ICMP protocol, you can find additional statistical information under the **Statistics...** page button.

For the TCP protocol, you can also consult the connections with the **Connection Table...** page button and TCP segments with the **TCP segments...** page button.

For the UDP protocol, you can consult additional information with the **Listener Info...** page button.

Finally, in the bottom right corner, you can view SNMP information with the **SNMP Settings ...** page button, general information from both interfaces 1 and 2 with the **Interfaces \[1-2\]...** page buttons and the current address translation with the **Address Translation...** page button.
