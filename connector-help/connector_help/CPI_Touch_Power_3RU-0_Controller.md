---
uid: Connector_help_CPI_Touch_Power_3RU-0_Controller
---

# CPI Touch Power 3RU-0 Controller

The Touch Power remote control panel design can be used either as a remote controller or as a switch remote controller that interfaces specifically with CPI amplifiers.

## About

The CPI Touch Power 3RU-0 Controller connector is used to control and monitor the parameters via SNMPv2.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | No           | Yes               |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 01.00.01               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

## How to use

### General

This page displays the **System Description**, **System Up Time**, **System Type**, **Number of Amplifiers** and **Firmware Version Table**.

### Static Configuration

This page displays configurable parameters for the device, including **Priority Switching**, **System Installed**, **Drive Type**, **Switch on Tx Inhibit**, **Switch on Hv ON**, **Switch on Tx no Inhibit** and **Power Copy**.

### Position

This page contains a table with the switch positions. Switches from HPA1 to HPA2 should be changed jointly.

### Priority

This page contains the **Amplifier** **Priority Table**, where the priority setting of the switches can be changed.

### Preset

This page contains the **Preset Table**, which allows you to set switches to a preset using the **Preset Active** column.

### Amplifier State

This page displays a table with information on the **communication status** of the amplifier and the **amplifier state**.

### Event

This page displays information about any event that has occurred.

### Web Interface

This page displays the web interface of the device. However, the web interface is only accessible when the client machine has network access to the product.

## Notes

The SNMP sets on the Switch Position Table only will be executed if **Switch Mode** is set to ***Manual.***
