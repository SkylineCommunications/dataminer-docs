---
uid: Connector_help_APC_Smart-UPS
---

# APC Smart-UPS

Smart-UPS devices provide high density, true double-conversion on-line power protection for servers, voice/data networks, medical labs and light industrial applications. Capable of supporting loads from 1 to 20kVA in a rack/tower convertible form, the Smart-UPS On-Line is available from 2U to 12U. All models 5kVA and above include an integrated Network Management Card for remote management (optional on models below 5 kVA). The Smart-UPS On-Line family provides customers with a reliable source of uninterruptible power even in demanding power environments, including very wide input voltage windows, extremely tight output voltage regulation, frequency regulation, internal bypass, and input power factor correction.

## About

This connector can be used with all APC Smart-UPS models. It makes it possible to monitor the state of the battery, power status and alarms, as well as to configure different parameters and functionalities. The different parameters from the device are displayed on multiple pages grouped by function.

### Version Info

| **Range** | **Description**              | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version, added traps | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | UPS 07.4 (ID1003)           |

## Installation and configuration

### Creation

Follow the standard procedure for SNMP managed devices. No additional information is required.

**SNMP Connection**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. The connector has 8 pages, plus a page with the web interface.

### General

This page contains general information such as **software versions**, **diagnostics**, **serial number** and **model** of the device.

### Battery Status

On this page, it is possible to check different parameters related to the operational state of the battery as well as the information
concerning battery packs.

### Power Status

This page displays electrical information from the UPS input and output

### Configuration

This is the main page for the configuration of the device. Here, you can set the **Rated Output Voltage**, **High and Low Transfer Voltages**, and **Return delay** from battery, as well as other miscellaneous settigns. The page also provides access to **Management**, **Control**, **Test**, and **Sync Control** settings.

### Alarms

This page displays all the available **alarms** reported by the device.

### Traps

This page displays the **Traps** table as well as the **Total Traps** parameter and the following buttons

- **Refresh Table** - refreshes the number of total traps, and deletes traps if total number exceeds **Max Traps**, or age exceeds **Max Age**
- **Clean Up Config... -** opens a pop up that contains **Trap Clean Up Method, Max Traps, Max Age Traps,** and **Trap Clean Up Amount**

### Outlet Groups

On this page, you can get the status of the **outlet groups** and configure them.

### Diagnostics

On this page, you can diagnose the operation of the device. It includes diagnostics for the **Batteries**, the **Interfaces card**, the **Power Supply system**, etc.

### Environmental Monitor

From this page, you can get the list of probes supported by the Environmental Monitor and their configurations. The page also displays the list of contacts.

### Web Interface

This page displays the **web interface** of the device.
