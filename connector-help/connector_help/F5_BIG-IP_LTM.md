---
uid: Connector_help_F5_BIG-IP_LTM
---

# F5 BIG-IP LTM

The **F5 BIG-IP Local Traffic Manager** (LTM) is designed to deliver applications to users, in a reliable, secure, and optimized way. It provides the extensibility and flexibility of application services with the programmability needed to manage a physical, virtual, and cloud infrastructure.

## About

The **F5 BIG-IP LTM** connector uses **SNMP** to retrieve status, configuration and statistics data from the F5 BIG-IP Local Traffic Manager. It is not possible to configure the device via SNMP.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**   |
|------------------|-------------------------------|
| 1.0.0.x          | Version 12.1.2 Build 0.93.249 |

## Installation and configuration

### Creation

SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page contains the general information about the **hardware** and **software** of the device.

There are 2 page buttons available:

- **Global Attributes**: Displays general device settings.
- **Global Statistics**: Displays general statistics about the CPU usage and incoming and outgoing data.

### Interfaces

This page contains 2 tables:

- **Interfaces**: Contains interface information and settings.
- **Interface Statistics**: Contains the statistics of every interface.

There are also several page buttons available:

- **Extra Statistics**: Displays the **Interface X Statistics** table, with extended interface statistics.
- **VLAN Statistics**: Displays the VLAN Statistics table, with statistics grouped per VLAN.
- **SFP Media**: Displays the Interface SFP Media table with the SFP type of each interface.

### Hardware

The information on this page is similar to that on the **General** page, but here it is specifically related to the hardware of the device.

There are also several page buttons available:

- **Fan**: Displays the **Chassis Fans** table, showing the speed for each fan in the chassis.
- **Power Supply**: Displays the **Chassis Power Supplies** table, showing the state of each power supply in the chassis.
- **Temperature**: Displays the **Chassis Temperatures** table, showing the temperature of the chassis.
- **Physical Disk**: Displays the **Hosts Disks** table and the **Physical Disks** table, containing information about the physical and virtual disks in the system.

### Redundancy

This page contains status information about the failover configuration of the system.

### Cluster

This page contains 3 tables:

- **Clusters**: Contains an entry per cluster, with configuration details.
- **Cluster Members**: Contains all members of each cluster, with additional information about the state of those members.
- **Chassis Slots**: Contains information about the state of each chassis slot.

### vCMP

This page contains 3 tables:

- **vCMP Assigned Slots**: Lists the slots assigned to a virtual clustered multiprocessing (vCMP) guest.
- **vCMP Allowed Slots**: Lists the slots that can be assigned to a vCMP guest.
- **vCMP Statistics**: Displays statistics and state information for each vCMP guest.

You can disable the polling of these tables by means of the **vCMP Polling** toggle button.

### LTM

This page contains state and configuration parameters related to the **Local Traffic Manager**.

There are also 2 page buttons available:

- **Nodes**: Displays the Nodes table, with status information about the node addresses.
- **Pools**: Displays the **LTM Pool Statistics** table, the **LTM Pool Member States** table, the **LTM Virtual Server States** table and the **LTM Pool States** table.

You can disable the polling of these tables by means of the **LTM Polling** toggle button.
