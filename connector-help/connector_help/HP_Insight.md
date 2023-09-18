---
uid: Connector_help_HP_Insight
---

# HP Insight

The **HP Insight** allows you to manage hardware across a wide variety of HP servers, including the latest HP ProLiant Gen8 Servers, as well as storage and networking products.

## About

This connector can be used to manage contracts and warranties, and to automate remote support via **HP Insight** Remote Support. It allows you to monitor the health of HP ProLiant Servers and HP Integrity Servers, and also provides you with basic support for non-HP servers. When you integrate HP SIM with HP Insight Control and the HP Matrix Operating Environment, you can proactively manage your physical and virtual server health, deploy servers quickly, decrease power consumption, and improve your infrastructure with capacity planning.

### Version Info

| **Range** | **Description**                         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                         | No                  | Yes                     |
| 1.0.1.x          | Major change; key of table 3000 changed | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x \[Main\] | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

- **IP Address/Host**: The device IP address.
- **Port Number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page displays general information about the **HP Insight** controller.

The page contains a page button that opens a page with all the options to **enable/disable polling** of tables and parameters.

### Performance

This page provides an overview of **all processes** that are currently running and the **Total Processor Load**. It also displays the **Available Memory and Load**.

### Task Manager

On this page, you can enable the polling of the Task Manager. If polling is enabled, an overview of all processes is displayed in the **Task Manager** table.

There is also a page button available that opens a subpage with the **Normalized Values** of the Task Manager.

### Temperature and Fan

This page provides an overview of all **Temperature** and **Fan** information.

### Network

This page displays an overview of the **Network Information** of all **Interfaces**, a **Logical Map** of all **NICs**, and all **Physical Adapters**.

### Storage

This page displays all **Disk Information**, an overview of the **Array Controller** data and information on all **Physical** and **Logical Drives**.

### Power Supply

On this page, you can find all statuses of the **Power Supplies**.

### Software

On this page, you can view **Software Information**. A toggle button allows you to switch polling of this information on or off.

### PCI

On this page, you can view **PCI Slots** details. A toggle button allows you to switch polling of this information on or off.
