---
uid: Connector_help_Newtec_MDM5010
---

# Newtec MDM5010

This connector allows you to monitor and manage the Newtec MDM5010 equipment.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | MDM5010 v1.0STE/6883   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page displays information regarding the device itself, such as Device Mode, System Time, System Uptime, Device Reset, and Device Temperature.

On the **Log** subpage, you can configure log parameters as well as view the log filter and alarm log.

### IP

This page allows you to configure the data interface, routes, and IP interfaces.

### Ethernet

This page allows you to monitor and control the Ethernet settings associated with the system.

The **Ethernet Alarms** subpage displays the alarm status information for the Ethernet interface, as well as various settings, e.g. related to redundancy and VLANs.

### Config

This page displays the active configuration of the device. It also allows you to create save and load a configuration for the device.

### Modulators

This page allows you to monitor the modulators.

The **Modulator Alarms** subpage displays the alarm status information for the modulators.

The **Modulator** **Config** subpage allows you to configure the settings for the modulators, including the **Link Optimization** and **Connection Configuration**.

### Demodulators

This page allows you to monitor the demodulator.

The **Demodulator Alarms** subpage displays the alarm information for the demodulator.

The **Demodulator** **Config** subpage allows you to configure the demodulator settings, including Backup Carrier, Connector Groups, Out of Lock Mutes Modulator, and MODCOD Statistic Reset.

### ACM

This page allows you to monitor theACM controls and ACM clients.

The **DVB S2 MODCOD Settings** subpage allows you to view and configure the ACM Controls MODCOD table.

The **ACM Config** subpage allows you to view and configure the ACM clients, controls, and signaling configuration.

### Redundancy

On this page, you can enable **device redundancy** and set the **initial state** (*Standby* or *Active*). You can also monitor the **device redundancy** and **alarm status.**

### GSE Encapsulation

This page allows you to monitor and configure GSE encapsulation and GSE encapsulation nodes.

### GSE Decapsulation

This page allows you to monitor and configure GSE decapsulation.

### Device Setup

This page allows you to adjust the **Auto Reference Clock Mode** and check the **Auto Reference Clock** defined through an internal or external oscillator.

The **Mgmt Interface** subpage allows you to configure remote management and the multi personality switch.

The **Alarm Handling** subpage allows you to configure settings of the device alarms.

The **Antenna Controller** subpage allows you to monitor and control the antenna settings. It also displays antenna alarms.

### Alarms

This page displays the alarm parameters for the entire modem system.

Via page buttons, you can access **Alarm History** and **Active Alarms**
