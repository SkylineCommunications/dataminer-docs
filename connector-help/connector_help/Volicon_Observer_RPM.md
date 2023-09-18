---
uid: Connector_help_Volicon_Observer_RPM
---

# Volicon Observer RPM

This connector is a **DVE manager** for the **Volicon Observer RPM**, which consists of probes called **Observers** that proactively monitor video services, helping operators to identify outages before customers complain, improving the quality of service and reducing help desk load. Based on the Alert Management module, these Observer RPM probes can also send fault notifications via SNMP, using traps.

## About

This connector does not poll any parameters from the device. Instead it receives traps and displays them in one table. Every column in this table represents a possible error that can be set with the correct severity. Every instance in this table represents a **video channel**. It is also possible to load channels from a **CSV file** into the **trap table**.

This connector exports other connectors, each of them representing an Observer RPM probe. The list of exported connectors can be found in the "Exported Connectors" section below.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.0                         |

### Exported connectors

| **Exported Connector**                                                                                        | **Description** |
|--------------------------------------------------------------------------------------------------------------|-----------------|
| [Volicon Observer RPM - Observer Probe](xref:Connector_help_Volicon_Observer_RPM_-_Observer_Probe) | Observer Probe  |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. 10.17.3.4

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains the **Observers Table**. This table displays the name of the Observer probes. It is also allows you to remove Observers with the **Remove Observer** button.

### Configuration

This page is used to **import video channels from a CSV file.** To do so, select a file in the drop-down menu and click the **Load Channels** button. All channels from the CSV file are loaded into the table. Channels from the CSV file cannot be deleted via the drop-down menu on the Traps page.

### Traps

This page displays the **Trap Overview** table. When a **trap is received**, when necessary, an entry is added in this table for the corresponding **video channel**. For each entry, a possible alarm can be set either by a user or by a trap.

At the bottom of the page, you can choose one of the channels and **clear the alarms** of this channel. Alarms can also be **cleared manually** in the table (e.g. in case a 'clear alarm' trap was missed).

Finally, you can also **delete channels** from the table by selecting them in the drop-down menu at the bottom of the page. This drop-down menu displays all channels except those that have been imported via a CSV file.

### Events

This page displays the **Events table**. All traps that are not cleared automatically will be stored in this table.
