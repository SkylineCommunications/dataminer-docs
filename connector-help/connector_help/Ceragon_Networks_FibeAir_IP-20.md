---
uid: Connector_help_Ceragon_Networks_FibeAir_IP-20
---

# Ceragon Networks FibeAir IP-20

This connector retrieves information from a Ceragon Networks FibeAir IP-20 via SNMP.

Ceragon FiberAir IP-20G is a hybrid, split-mount hauling solution for edge and ring node. Supporting all common features of the IP-20 platform. FibeAir IP-20G boosts performance in today's networks while providing a cost-effective path to the furure network requirements. It offers full support for TDM services, as well as rich set of advanced carrier ethernet services providing a wide range of new capabilities that address the diverse and evolving needs of mobile backhaul, ISPs, utilities, government and private networks.

## About

The **FiberAir IP-20G** connector displays the general information, available interfaces, radio and ethernet configuration of the device. All information is retrieved using SNMP.

### Version Info

| **Range** | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           | Yes                 | Yes                     |
| 1.0.1.x          | Based On: 1.0.0.4 Range Impact: Changed column displayed layout for the Interfaces table due to adding new rate parameters. Range Actions to Take: Verify external applications e.g. Reporter Templates that take the order of columns into account. Range Impact: Changed displaykey for the Interfaces table because previous format was not unique. Format consists now of "\[Description\].\[Index\] - \[Alias\]" Range Actions to Take: Verify any configured alarm filter in the DMS to match the new format. NF: Added Bitrate on Ethernet Statistics table. NF: Added rate parameters for Discarded , Broadcast, Unicast (in/out) packets. NF: Added rate parameters for all Counters available in Interface Physical Port RMON Statistics table. | Yes                 | Yes                     |

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

This page displays general information about the device, including the **System and Unit Information,** and all the information regarding the available interfaces we have **enabled/disabled** in the system.

This page also has three subpages, which you can access through page buttons:

- The **Unit Inventory** subpage contains basic information about the unit corrently installed, as the device and part number, the serial or the card name defined by Vendor.
- The **NTP Configuration** subpage contains information regarding the **NTP Status** and **NTP Configuration** where it is possible to check the poll interval, the lock state and the IP of the sync server. On the other hand the configuration table allows to change the Admin state, NTP version or even the server IP.

### Interfaces

This page displays information on the interfaces that are being used on a Ceragon device such as ethernet, radio and management ports. It is also possible to get information on the services that are running in the system, more specifically, TDM, LAG or cascading options. All of them are configurable and the user can activate or shut down ports.

### TDM/NGPW

In this page, the user is allowed to activate/de-activate a set of 16 TDM(E1) ports.

This page also has three subpages, which you can access through page buttons:

- The **NGPW Services** subpage contains basic information of any NGPW. PSN Type, DS0 bundle configuration, slot and pseudowire ID are some of the available features that can be seen/changed both for the Services and PSN tunnels. Administrative status is also settable.
- The **TDM PMs** subpage contains information regarding the errors on the transmission path. The counters can be divided in four different intervals: minutes, hours, current minute or current hour.
- The **NGPW PMs** subpage contains an extended set of information regarding pseudowire error counters.

### Radio

This page shows both the status and configuration tables regarding the radio frequency unit.

This page also has four subpages, which you can access through page buttons:

- The **Remote Radio** subpage contains basic information of the remote radio connected to Ceragon FibeAir devices. Any remote radio parameter can be read or set in this subpage, such as the operational status, IP Address, RX and TX levels. As a workaround reseting the radio is also possible to do here.
- The **Radio Threshold** subpage contains information regarding the possible threshold levels that allows the equipment to be working correctly.
- The **Radio PMs** subpage contains an extended set of information regarding the throughput, average throughput, peak capacity or average capacity of the radio on a certain interval. Once again, the interval is between 15min, 15min current, 24 hour, 24hour current.
- The **MRMC PMs** subpage contains an extended set of counter information regarding the profile and bitrate of a radio for a specific interval. The interval goes from 15min, 15min current, 24 hour, 24hour current.

### Ethernet

This page shows both the status and configuration tables regarding the Physical Ethernet connections.

This page contains settings related to the Media Type used, the Operational status, the Negociation of a connection, the Speed and the Quality of the connection agreement (Half/Full duplex).

In addition, it contains a sub-page for the **Ethernet Services** provided, which can accessed through page buttons:

- The **Ethernet Services** page contains information regarding the Ethernet service type, Administrative status, default CoS, EVC ID and Description**,** and several other details regarding the trails, protection, encapsulatuib and V-LAN.

### Cascading

This page contains settings related to the **Cascading configuration.** In this section, an ethernet port (out of six ports) can be set as a cascading port. As the user change this setting, it can be also seen in the Interfaces table inside Interfaces tab.

### Virtual Tables

This page shows four tables in total. Two are mainly used for management purposes and the other two tables for booking resources allocation.

**Radio Table:**

- Maximum bandwidth is the maximum bandwidth capable by the radio equipment. The available bandwidth is the total sum of Current Active and Current booked bandwidth subtracted to the maximum bandwidth.

**Ethernet Ports Table:**

This table presents all ethernet port status available. The possible status are: Available, Used, Booked and Used, Booked and Booked and available. There's one more column showing the booked bandwidth allocated on each port.

**E1 Virtual Interfaces Table:**

This table presents all the 16 E1 "ports" that can be booked via automation script. In this table, each entry has the following information:

- Port status, Reference, End Date, Booked bandwidth, Contact, Metadata and a Valid for where the user can see how much time still remains until the booking expires.

**Ethernet Virtual Interfaces Table:**

This table presents all 6 Ethernet ports that can be booked via automation script. Likewise we have for the E1 Virtual Interfaces table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
