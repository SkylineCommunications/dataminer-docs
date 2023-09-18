---
uid: Connector_help_Snell_Wilcox_IQH3A_RollCall
---

# Snell Wilcox IQH3A RollCall

The **Snell Wilcox IQH3A RollCall** is a 3U rack unit accepting up to 16 modules.

## About

This connector is an application-specific protocol for control and operation of units. The **Snell Wilcox IQH3A RollCall** connector uses a smart-serial connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.30.21                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.14.11*.
  - **IP Port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: Used to fill in the unit address and the unit port, e.g. *20.00* for unit address *0x20* and unit port *0x00*.

## Usage

### General Page

This page contains the **Display** parameter, as well as parameters of the output display.

### Setup Page

This page contains information about the chassis, e.g. **Product**, **Software** **Version**, **Build**. Buttons allow you to restart the device (**Restart**), to **En**able**/Disable** the module, or to save and clear memory.

Finally, you can also name the different inputs.

### Ethernet Page

This page displays the **Unit IP Address Settings** and **Unit State**. It also allows you to set up **Client IP Ranges**.

### RollCall IP Page

This page allows you to configure the **RollCall IP**.

### Log Server Page

This page provides an overview of the **Log Server** information and allows you to **enable/disable** logging.

### Slots (1-4) Page

This page provides information for each slot, such as **Slot Name**, **Installed Unit**, **Power Usage**, etc.

### Slots (5-8) Page

This page provides information for each slot, such as **Slot Name**, **Installed Unit**, **Power Usage**, etc.

### Slots (9-12) Page

This page provides information for each slot, such as **Slot Name**, **Installed Unit**, **Power Usage**, etc.

### Slots (13-16) Page

This page provides information for each slot, such as **Slot Name**, **Installed Unit**, **Power Usage**, etc.

### Control (1-8) Page

This page provides an overview of **S**lot** settings** related to Slots 1-8.

### Control (9-16) Page

This page provides an overview of **S**lot** settings** related to Slots 9-16.

### Gateway Page

This page allows you to configure the current session. You can either **connect** or **disconnect** the session, and also configure the **packets count**.

### SNMP Page

This page provides an overview of **SNMP-**related settings. Note that configurable traps for each slot are present on this page.

### Logging Page

This page displays all monitored parameters, which may be enabled or disabled.

### Statistics Page

This page provides an overview of statistics such as **Data Length Errors**, **Destination Errors**, **Source Errors**, **Dropped Packets**, **Processor Use**, etc.

There is both a **Reset Stats** button and an **Enable Net Stats** button.

### Web Interface Page

This page provides access to the original web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
