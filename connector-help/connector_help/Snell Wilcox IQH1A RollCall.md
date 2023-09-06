---
uid: Connector_help_Snell_Wilcox_IQH1A_RollCall
---

# Snell Wilcox IQH1A RollCall

The **Snell Wilcox IQH1A RollCall** is a 1U rack unit accepting up to 4 modules.

## About

The Snell Wilcox IQH1A IQ 1U modular enclosures are used for high-density delivery of HD and SD modular solutions. The 1U rack unit accepts up to four "A" style modules, and is available in single and dual redundant PSU versions. RollCall control and monitoring is included as standard using a gateway control card.

This driver is an application-specific protocol for control and operation of units. The **Snell Wilcox IQH3A RollCall** driver uses a smart-serial connection.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### Serial main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device, e.g. *192.168.14.11*.
  - **IP Port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: Used to fill in the unit address and the unit port, e.g. *20.00* for unit address *0x20* and unit port *0x00*.

## Usage

### General Page

This page contains the **Display** parameter, as well as parameters related to the output display.

### Setup Page

This page contains information about the chassis, e.g. **Product**, **Software Version** and **Build**.

Buttons allow you to restart the device (**Restart**), to **Enable/Disable** the module, or to save and clear memory.

Finally, you can also name the different inputs.

### Ethernet Page

This page displays the **Unit IP Address Settings** and **Unit State**. It also allows you to set up **Client IP Ranges**.

### RollCall IP Page

This page allows you to configure the **RollCall IP**.

### Log Server Page

This page provides an overview of the **Log Server** information and allows you to **enable/disable** logging.

### Slots (1-4) Page

This page provides information for each slot, such as **Slot Name**, **Installed Unit**, **Power Usage**, etc.

### Control (1-4) Page

This page provides an overview of **S**lot** settings** related to Slots 1-4.

### Gateway Page

This page allows you to configure the current session. You can either **connect** or **disconnect** the session, and also configure the **packets count**.

### SNMP Page

This page provides an overview of **SNMP**-related settings. Note that configurable traps for each slot are present on this page.

### Logging Page

This page displays all monitored parameters, which may be enabled or disabled.

### Statistics Page

This page provides an overview of statistics such as **Data Length Errors**, **Destination Errors**, **Source Errors**, **Dropped Packets**, **Processor Use**, etc.

There is both a **Reset Stats** button and an **Enable Net Stats** button.

### Web Interface Page

This page provides access to the original web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
