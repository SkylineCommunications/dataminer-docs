---
uid: Connector_help_Snell_Wilcox_IQSDA35_RollCall
---

# Snell Wilcox IQSDA35 RollCall

The **Snell Wilcox IQSDA35 RollCall** is a dual-channel 3G/HD/SD-SDI re-clocking amplifier with selectable outputs.

## About

This connector allows the management of the **Snell Wilcox IQSDA35** using smart-serial connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.5.8                       |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
  - **IP port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: Used to fill in the unit address and the unit port, e.g. *10.0D* is for unit address *0x10* and unit port *0x0D*.

## Usage

### General Page

This page contains the **Display** parameter, as well as log settings parameters such as **OS** **Version**, **Firmware Version**, etc.

The parameters of the output display are also displayed.

### Input Page

On this page, you can manage the dual-channel amplifier. The page also provides auto-changeover functionality for emergency switching, and contains the input and output GPI control.

### Memory 1-16 Page

This page provides an overview of the system memory, with a table containing 16 user memories. It also allows you to save and clear memory.

### Logging Page

On this page, you can select either the **Logging Input 1** **Config** page button or the **Logging Input 2** **Config** page button in order to enable/disable each input channel field, such as **Ident**, **Name**, **Type**, **State** and **SDI Bitrate.** You can also set some setting parameters such as **OS** **Version**, **Firmware** **Version**, etc.

### RollTrack Page

This page provides a simple command interface that can be used to send unconnected Rolltrack commands to any Rollcall-compatible unit in the network. The following parameters are displayed: **Rolltrack Disable All**, **Rolltrack Index, Rolltrack Address**, **Rolltrack** **Sending, Rolltrack Source,** **Rolltrack Command** and **Rolltrack** **Status**.

### Setup Page

This page contains information about the card, e.g. **Input 1 Name**, **Input 2 Name**, etc. In addition, buttons allow you to restart the device (**Restart**), set back the factory settings **(Factory Default**), or set back the default settings (**Default Settings**).

### Web Interface Page

This page provides access to the original web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
