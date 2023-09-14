---
uid: Connector_help_APT_AoIP
---

# APT AoIP

The APT AoIP is a compact and efficient solution for the transport of multiple channels of audio or MPX content over IP links.

## About

This connector uses an **SNMP** connection to poll information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: *public*
- **Set community string**: *private*

## Usage

### General

This page contains general information on the unit, such as the **Serial Number**, **System Type**, **Hardware Revision**, **Software Revision**, **Unit Name**, **CPU Load**, **Unit Temperature** and **Trap Counter**.

There is also a button available that allows you to reboot the unit.

The **Connection** page button opens a subpage with connection information. It displays three tables for **IP**, **Distant Redirection** and **Firewall** data, respectively.

### Configuration

This page displays the **Active Profile Name**, the **Active Profile Number**, the **Audio Alarm Configuration** table and the **Stream** table.

Via the **Relay** page button, you can view the following parameters:

- **Serial Data Baud Rate**
- **Serial Data Baud Rate 2**
- **Input Source 1** to **4**
- **Invert Switch Input**
- **Relay Control Mode 1** to **4**
- **Invert Relay Output 1** to **4**

Via the **Audio** button, you can configure the following parameters:

- **Audio Input Mode**
- **Audio I/O Impedance**
- **Audio Output Digital Sample Frequency**
- **Audio Loopback Enabled**
- **Enable Loss of Digital Input Alarm**
- **Enable Loss of Digital Reference Alarm**
- **Enable Advanced Routing**
- **Advanced Routing A** to **D**

### GPIO

This page consists of two sections.

- In the Switch Status section, you can find the parameters **Opto 1 Input State**, **Opto 2 Input State**, **Opto 3 Input State**, **Opto 4 Input State** and **Opto Active High**.
- In the Relay Status section, you can find the **Relay 1 Output State**, **Relay 2 Output State**, **Relay 3 Output State** and **Relay 1 Output State**.

### Performance

This page displays the **Audio Level Channel A, B, C** and **D** and the **Stream Performance** table.

### Alarms

This page consists of the sections **Audio Alarms**, **Transport Alarms**, **Power Supply Alarms**, **Network Time Protocol Alarms**, **Loss of Signal Connection** and **Dynamic DNS Alarms**.

In the Audio Alarms section, you can find the parameters **Silence Detect Channel A** to **D**, **Sync Failure, Loss of Digital Input - AB, Loss of Digital Reference, I/O Board Removed** and **Loss Digital Input CD**.

The Transport Alarms section displays the **IP TX Error**, **IP RX Error**, **Audio Mismatch** and **Loss of IP Connection** parameters.

**PSU 1 Failure** and **PSU 2 Failure** can be found in the Power Supply Alarms section and the **NTP Synchronization** is displayed in the NTP (Network Time Protocol) Alarms section.

Finally, the sections **Loss of Signal Connection** and **Dynamic DNS Alarms** both display a table with status information.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
