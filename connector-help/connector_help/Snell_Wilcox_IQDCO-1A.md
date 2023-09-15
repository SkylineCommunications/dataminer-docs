---
uid: Connector_help_Snell_Wilcox_IQDCO-1A
---

# Snell Wilcox IQDCO-1A

This protocol monitors and controls any **Snell Wilcox IQDCO-1A** equipment. It can perform switching operations between the device's inputs, as well as monitor the state of the current configuration. The **Snell Wilcox IQDCO-1A** works as a switching module whose main function is to perform switching operations between input signals.

## About

The connector works with **SNMP**, though no traps are supported.

Two timers are used to poll information: one for short-to-medium term operations every 30 seconds, and another for long-term/static information every minute.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**             |
|------------------|-----------------------------------------|
| 1.0.0.x          | Compatible with software version 5.2.6. |

## Installation and configuration

### Creation

#### SNMP Main Connection:

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host:** The Polling IP of the device.
- **Device address:** Range between *1-255*.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

The connector contains three pages: **General, Control** and **GPI**.

### General

This page displays general information about the device, such as:

- **Module Name, Status, Time, Input** and **Expected Input**
- **Serial Number**
- **Software Version**
- **Build Number**
- **Alarm Position**
- **Preset Device**

Via the **Logging...** page button, you can select whether logging should be enabled for the inputs and the output.

### Control

On this page, you can control the inputs by means of two buttons: **Force A** and **Force B.**

For both **Input A** and **B**, you can set up the configuration via the **Setup Input A...** and **Setup Input B...** page buttons respectively, as well as predefine rules via the page buttons **Rule 1...** to **Rule 5...**

### GPI

On this page, you can control how the GPI port outputs should behave, by means of the three drop-down lists: **GPI Port 1 Output, GPI Port 2 Output** and **GPI Port 3 Output.**

For each GPI port output, you can also configure additional options with the page buttons **Setup GPI 1...** to **Setup GPI 3...**
