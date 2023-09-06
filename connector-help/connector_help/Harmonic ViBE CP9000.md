---
uid: Connector_help_Harmonic_ViBE_CP9000
---

# Harmonic ViBE CP9000

The Harmonic ViBe CP9000 is a contribution encoder that preserves video quality at the front of the broadcast chain by processing uncompressed UHD signals.

## About

### Version Info

| **Range**            | **Key Features**                              | **Based on** | **System Impact**                                                    |
|----------------------|-----------------------------------------------|--------------|----------------------------------------------------------------------|
| 1.0.0.x              | \- Monitoring. - Configuration of the device. | \-           | \-                                                                   |
| 1.0.1.x \[SLC Main\] | \- Monitoring. - Configuration of the device. | 1.0.0.2      | \- Changed display key of 'Alarms' table and 'Sub System Info' table |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.0-ed-A               |
| 1.0.1.x   | 2.0-ed-A               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the device.

## How to use

### General

This page contains product information, such as the **System Name**, **System Description** and **Serial Number**. It also displays the primary and secondary alarm output status.

### HW/SW Info

On this page, you can monitor the **Board Info**, **Software Licenses** and **Inventory Info** tables.

### Alarms

This page contains the following tables:

- **Sub System** **Info**: Lists alarms related to one chassis function and one function-encoding channel.
- **Alarms**: Lists the alarms that are present on the device.

### Events

This page contains a table with information regarding events for which the operator should be notified, such as alarm that have been raised or dropped.

### IP

On this page, the **IP Interfaces** table lists all external IP interfaces.

### Maintenance

On this page, you can find configurable parameters such as **BCAST Status** and **Transfer Buffer Max Size**. Two buttons are available, **Reboot** and **Shutdown**, which allow you to execute the corresponding actions on the device.

### Presets

This page contains a read-only table listing the previously saved configurations.

### Traps

On this page, the **Manager Table** displays the configured trap destinations.
