---
uid: Connector_help_Nera_Evo_XPAND_IP+
---

# Nera Evo XPAND IP+

**Evo XPAND IP+** is an advanced version of radio with higher capacity and Ethernet features. Combining advanced Ethernet and TDM networking functionality with best-in-class microwave radio performance, Evo XPAND IP+ facilitates cost-effective, risk-free migration to IP/Ethernet and can be integrated in any pure IP/Ethernet, Native2 (hybrid) or TDM network.

## About

Evo XPAND IP+ features a powerful, integrated Ethernet switch for advanced networking functionality and an optional TDM cross-connect for nodal site applications. With advanced service management and Operation Administration & Maintenance (OA&M) tools, the solution simplifies network design, reduces CAPEX and OPEX and improves overall network availability and reliability to support services with stringent SLAs.

This connector communicates with the device using an **SNMP** connection, allowing the user to monitor and control features of the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 7.2.0.0.08-1                |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

On this page, you can find information such as the **ID Version**, **Measurement** **System**, **Real Time on Device** and **Last Configuration Change**.

The following page buttons are available:

- Connections
- Interfaces
- IDU (Indoor Unit)
- NTP
- Daylight Time

### Faults

This page contains all status parameters related to **Faults**, such as **Error Description**, **Event log Last Change**, **Alarm Last Change** and **Most Severe Alarm**.

The **Event log**, **Current Alarm**, **Traps** and **General Alarm** page buttons provide access to additional information.

### Licenses

This page contains information on the licenses: **Type License,** **License Code** and **Switch Application License**.

### Security

This page contains all status parameters related to security, such as **Shelf Installation**, **Administrator Protection** and **ASP Revertive**.

### Management

This page contains all management parameters, such as **Information Progress**, **File Restore Status**, **Upload Configuration Status** and **Certificate Status**.

The page also contains one page button, **SW Configuration**.

### Ethernet Switch

This page contains the **Ethernet Switch** parameters, such as **XSTP ID**, **XSTP Bridge Role** and **ETM Statistics**.

The following page buttons are available:

- ETM Configuration
- Switch Configuration

### RFU

This page contains all **RFU** parameters, such as **RFU Mode**, **RFU Serial Number** and **Upload Counter**.

The following page buttons are available:

- Configuration
- Status

### PM

On this page, you can find information such as the **Traffic RFU Signal Level** and **Radio Aggregate PM**.

The following page buttons are available:

- Ethernet Utilization
- Traffic 24 Hours
- Traffic 15 Minutes
- Signal Level 24 Hours
- Signal Level 15 Minutes
- XPI
- Threshold
- MSE
- Ethernet Radio
- TDM
- MRMC

### Radio

This page contains all radio parameters, such as **Bit Error Rate**, **Defected Blocks** and **Mean Square Error.**

The following page buttons are available:

- Configuration
- Remote
- MRMC
- MRMC Script

### Synchronization

This page contains all synchronization parameters, such as **System Reference Quality**, **PRC Regenerator** and **Radio Clock Source.**

### Network

This page contains the network parameters, such as **Remote IP**, **MATE IP** and **Agent IP.**

The following page buttons are available:

- Diversity
- IP Configuration
- Configurations

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
