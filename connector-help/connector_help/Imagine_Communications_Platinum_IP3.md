---
uid: Connector_help_Imagine_Communications_Platinum_IP3
---



# Imagine Communications Platinum IP3

This device is a rack-sized expandable matrix. The **Platinum IP3** provides matrix expandability beyond 8x8 to 576x1024 in a single 28RU frame, with very flexible configuration in terms of input, output and control modules. The system can be composed of up to six frames with a final matrix size of 1152x3072. Each IP3 frame can accommodate up to 576 inputs across 64 modular input slots, and 1024 wideband outputs distributed across 65 output slots.

## About

This is a dual SNMP/smart-serial connector. For the smart-serial connection, a proprietary Imagine Communications protocol is used, called LRC. This connector uses the same serial logic base as the Imagine Communications Platinum Router connector.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.160.0.268                 |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial LRC Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Required. By default: *52116*.
  - **Bus address**: The bus address of the device. Required. By default *1*; range: from 0 to 16.

## Usage

### Matrix

This page contains the graphical representation of the matrix.

### Resource Controller

This page displays the general information provided by the resource controller as well as the **routing control** of the matrix itself. The routing control uses the **LRC** protocol instead of SNMP operations.

### 576x1024 Matrix

This page contains the parameters required for the monitoring of the **redundant matrices** inside the IP3 shelf.

### Outputs

This page contains a table with all the **outputs**, with their **description** and the **input** they are connected to, as well as the description of the input.

### Layouts

On this page, you can **add** **layouts** to the **table**, which will then be available in the **Monitors** **table**. The page allows you to **delete** **everything** or only the **layouts** that **are not used**.

You can also **import** **a CSV file** to populate the table.

### Virtual Monitors

This page contains a **table** where you can add **multiviewer** **monitors**, and specify their **group**, **layout**, **source**, **IP and port.**

In the table, you can also set the **UMD** of the **monitor**.

A page button on this page allows access to the **IP table**, which lists all IPs of the **multiviewers** that you can add, with their **description**.

### HS9C-IBG

This page displays information on the **SD/HD/3G input module**

### HS9C-OBG

This page displays information on the **SD/HD/3G input module** with fiber **optical interfaces**.

### HSR16C-OBG

This page displays information on the **SD/HD/3G output module**

### HSR16O-OBG

This page displays information on the **SD/HD/3G output module** with optical **SFP** modules.

### Configuration

This page contains general configuration settings.

### Alarms

This page contains alarm-related information and settings.

## Notes

When you do a set on the **matrix** or on the **outputs** **table**, there is a **delay** **of 3 seconds** before the matrix is updated.
