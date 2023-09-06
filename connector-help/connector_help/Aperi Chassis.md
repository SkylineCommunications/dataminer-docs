---
uid: Connector_help_Aperi_Chassis
---

# Aperi Chassis

This is an **HTTP** and **serial** connector that is used to monitor and configure the **Aperi Chassis** equipment.

## About

The information on tables and parameters is retrieved via **HTTP** and **serial** communication.

### Version Info

| **Range**            | **Description**                                                                                                                                                                                              | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                                             | Yes                 | Yes                     |
| 1.0.1.x              | Replaced Telnet connection with SSH connection.                                                                                                                                                              | Yes                 | Yes                     |
| 1.0.2.x              | Implemented SNMP traps.                                                                                                                                                                                      | Yes                 | Yes                     |
| 1.0.3.x              | Added Disk Usage Table based on Linux SSH connection.                                                                                                                                                        | Yes                 | Yes                     |
| 1.0.4.x              | Added control plane connection and functionality.                                                                                                                                                            | Yes                 | Yes                     |
| 1.0.5.x \[SLC Main\] | Removed Tx columns from the Network Interface Rx table (49000) and Rx columns from the network Interface Tx table (59000).Added FK column to the 9000 table in the following tables: 11000, 49000 and 59000. | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | vStack 1.7.x           |
| 1.0.1.x   | vStack 1.7.x           |
| 1.0.2.x   | vStack 1.7.x           |
| 1.0.3.x   | vStack 1.7.x           |
| 1.0.4.x   | vStack 1.7.x           |
| 1.0.5.x   | vStack 1.7.x           |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.

#### IP Dataplane SSH Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.

- **Port:**

- The Telnet port of the device (**1.0.0.x**).
  - The SSH port of the device (**1.0.1.x**), by default **222**.

#### SNMP Connection

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Port**: Default is **161.**
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### IP Linux SSH Connection

This connector uses an SSH connection and requires the following input during element creation:

SSH CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Port**: The SSH port of the device (**1.0.3.x**), by default **22**.

#### IP Controlplane SSH Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Port:** The SSH port of the device (**1.0.4.x**), by default **223**.

### Initialization

To make sure the full functionality of the element becomes available, you must enter a valid username and password to connect to the device. To do so, on the **Security** page, fill in the correct **username** and **password**.

From version 1.0.2.x onwards, you also need to fill in the **Device IP** on the **General** page to support SNMP traps.

From version 1.0.3.x onwards, on the **Polling Manager** subpage of the **General** page, you can enable or disable the polling of specific groups and control the polling interval for the groups.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page displays the **System Information** and **HPM Information**, including the **System Name**, **Serial Number**, **Part Number**, and other general parameters. The **Save Configuration** button will execute the command "write memory confirm".

### Metrics

This page displays **System Voltage Information** and **Temperature Information**.

### Units

This page displays the **Power Supplies** and **Cooling Units** tables.

### Slots

This page displays the **Slots** table. A refresh mechanism will refresh the status of the child elements.

### Interfaces

This page displays the **Interfaces** table.

### Applications

This page displays the **Applications** and **Application Instances** tables.

### Events

This page displays the **Events** table.

### Disks

This page displays the **Disk Usage** table.

### Security

On this page, you can define the **Username** and **Password** to connect to the device.

### Explorer

On this page, you can send a single command and check the output of that command.

### Dataplane Interfaces and Controlplane Interfaces

This page displays the **Network Interfaces** and **Network Interfaces Counters** tables. It also allows you to clear all counters of the device.

### Dataplane Interfaces Transceiver

This page displays the **Interfaces Transceiver** table.

### Dataplane VLAN and Controlplane VLAN

This page displays the **VLAN** and **VLAN Interfaces** tables. It is also possible to add a new VLAN to the device here.

### Dataplane Spanning Tree

This page displays the **Spanning Tree Information**.

### Dataplane IGMP

This page displays the **IGMP Snooping** and **IGMP Snooping Querier** information.

### Slots Overview

This page displays a tree control view with slots information.

### VLAN Overview

This page displays a tree control view with VLAN information.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Commands linked to polling manager

| **Polling parameter name**                             | **Command sent**                              | **Default polling frequency (seconds)** |
|--------------------------------------------------------|-----------------------------------------------|-----------------------------------------|
| Dataplane Get VLAN                                     | show vlan                                     | 60                                      |
| Dataplane Get Port All                                 | show port all                                 | 60                                      |
| Dataplane Get Interface Counters                       | show interface counters                       | 60                                      |
| Dataplane Get Spanning-Tree Summary                    | show spanning-tree summary                    | 60                                      |
| Dataplane Get IGMP Snooping                            | show igmpsnooping                             | 60                                      |
| Dataplane Get IGMP Snooping Querier                    | show igmpsnooping querier                     | 60                                      |
| Dataplane Get Ethernet Interface                       | show interface ethernet all                   | 60                                      |
| Dataplane Get VLAN Interface                           | show vlan port all                            | 60                                      |
| Dataplane Show Interfaces Switchport General           | show interfaces switchport general            | 60                                      |
| Dataplane Get Interfaces Status All                    | show interfaces status all                    | 60                                      |
| Dataplane Get Fiber-Ports Optical-Transceiver All      | show fiber-ports optical-transceiver all      | 60                                      |
| Dataplane Get Fiber-Ports Optical-Transceiver-Info All | show fiber-ports optical-transceiver-info all | 60                                      |
| Dataplane Get SysInfo                                  | show sysinfo                                  | 60                                      |
| Dataplane Get CPU and Memory Utilization               | show process cpu                              | 60                                      |
| Dataplane Get Class Map                                | show class-map                                | 60                                      |
| Dataplane Get Policy Map                               | show policy-map                               | 60                                      |
| Dataplane Get Class Map Details                        | show class-map + class map name               | 60                                      |
| Dataplane Get Policy Map In                            | show service-policy in                        | 60                                      |
| Get Chassis                                            | (http) /chassis                               | 30                                      |
| Get Metrics                                            | (http) /metrics                               | 30                                      |
| Get Slots                                              | (http) /slots                                 | 30                                      |
| Get Applications                                       | (http) /applications                          | 30                                      |
| Get Events                                             | (http) /ipmi_events                           | 30                                      |
| Get Interfaces                                         | (http) /interfaces                            | 30                                      |
| Get Applications instance                              | (http) /application_instances                 | 30                                      |
| Port Descriptions                                      | Show Port Description                         | 3600                                    |

**Note:** Port descriptions polling cannot be disabled. The result of this poll cycle is used to map incoming SNMP traps to the relevant interface.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the Aperi Chassis connector supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and DataMiner third-party protocols (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **Interface** is the physical dynamic interface created and the interface type is **inout**.
