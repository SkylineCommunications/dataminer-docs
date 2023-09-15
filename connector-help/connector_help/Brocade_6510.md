---
uid: Connector_help_Brocade_6510
---

# Brocade 6510

The Brocade 6510 is a 48-port, high-performance, enterprise-class switch that meets the demands of highly virtualized and private cloud storage environments by delivering market-leading Gen 5 Fibre Channel technology. The Brocade 6510 Switch provides maximum flexibility, simplicity, and reliability in an efficiently designed 1U package.

## About

TheBrocade 6510 connector enables Skyline Communication DataMiner to communicate with a Brocade 6510 Switch allowing a user to remotely monitor and operate in the such device via SNMP.

### Version Info

| **Range**     | **Description**                                               | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------------|---------------------|-------------------------|
| 1.0.1.x \[SLC Main\] | Full connector review in order to comply with Skyline standards. | No                  | True                    |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 7.4.1d                      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get Community String**: Provides read access to the device. default: public
- **Set Community String:** Provides write access to the device. default: private

## Usage

### General

The **general** page provides generic information regarding the device system such as:

- **System Description**
- **System Object ID**
- **System Up Time**
- **System Contact**
- **System Name**
- **System Contact**
- **System Location**
- **System Services**
- **System URL**
- **Firmware Version**
- **System CPU and Memory Usage**

### Detailed Interface Info

In this page the user may find information regarding every **interface** this device contains.

### Fabric Element

In the **Fabric element** page multiple features are available. The user can check the device **Capabilities**, **Accounting** performances, **Error** Statistics and configured **Modules**.

### Physical Entities

This page provides a table that provides specific information regarding the device's present components.

### Switch Configuration

The **switch configuration** page provides a set of pages that allow the user to check and configure multiple switch related components such as:

- **Neighbors**
- **Connected Unit Statistics**
- **Agent Community**
- **Trunk**
- **CPU and Memory**
- **Name Server**
- **Flash**
- **Sensors**
- **Ports**

### FICON

The Ficon page provides tables related with the **IBM's Fibre Connection** proprietary standard.

### IP Address

This page provides information regarding the Internet Protocol. The user may find the configured **IP Address**'s in this device, **IP Route** table, **ARP** Table and **statistics** pages regarding other IP related protocols such as **TCP, UDP, ICMP** and **IP**.

### SNMP

The SNMP page allows the user to analyze and configure SNMP data present on the equipment.

This page contains 5 **page buttons:**

- **SNMP USM**
- **SNMP Statistics**
- **SNMP Targets**
- **SNMP Community**

### Field Replaceable Units

This page allows a user to analyze the installed inventory and the specific installation/uninstallation events.

### Events

In this page the user may find a log on which all device events are registered. The table is limited by the amount of entries configured in the device. This page also provides access to Trap related information.
