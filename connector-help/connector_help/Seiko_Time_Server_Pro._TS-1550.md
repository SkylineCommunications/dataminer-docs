---
uid: Connector_help_Seiko_Time_Server_Pro._TS-1550
---

# Seiko Time Server Pro. TS-1550

The Seiko Time Server Pro. TS-1550 connector monitors the active configuration of the Seiko Time Server Pro. TS-1550 device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**      |
|-----------|-----------------------------|
| 1.0.0.x   | 2.1.0 (built on 2022-07-22) |

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
- **IP port**: The port of the connected device, by default 161.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### Smart-Serial Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The port of the connected device, by default 22.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General Page

The **General** page contains the overview of the device info including **System Uptime, System Contact** and **System Location** etc. Take note that the SSH credentials are required to be input here in order for the Smart-Serial polling to work.

### PTP Pages

Several pages are available with parameters related to PTP.

The PTP 1 and PTP 2 pages contain parameters from the default, current, parent, port, and time properties data set, daemon counters, and sync metadata for PTP 1 and 2, respectively. Both pages also have a subpage with information regarding the foreign master data set.

The other PTP pages contain clock and profile settings, and tables with information related to the base clock and base clock port.

### Entity 1550 Page

This page shows the status of the Entity 1550 RTC battery. Subpages contain the SNMP tables related to PSU and temperature.

### Other Pages

The remaining pages contain various tables with information related to BLACK, LTC, etc. Subpages provide access to the related settings.
