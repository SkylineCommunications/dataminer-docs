---
uid: Connector_help_THTF_Gigamega_FM_Transmitter_Monitoring_Control
---

# THTF Gigamega FM Transmitter Monitoring Control

This connector can be used to monitor the use of FM transmitters via traps. It receives SNMP traps and notifications and shows the status results in a table. It does not poll any data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**               |
|-----------|--------------------------------------|
| 1.0.0.x   | Unknown, MIB version : July 27, 2015 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP address of the THTF Gigamega FM Transmitter Monitoring Control.

SNMP Settings:

- **Port number**: The port of the THTF Gigamega FM Transmitter Monitoring Control. By default this is *161*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **Main** page of the connector contains the **Statuses Table**, which displays information about the traps that are received from the machines in several sites.

In the table, the **Unique Name** column shows the name of the device for which status information is displayed. This name is a concatenation of **Site Name / Machine Name / (EXC/PS/PA + Machine Index)**.

Each row shows alarm information, such as **Transm. Disconn.**, **sMPS Fault**, etc. It also shows the date and time when it was last updated in the **Last Update Time** column.

With the **Remove Row** button, you can remove a row. This can be useful in case a device was renamed, its location was changed, or it was taken out of production.

## Notes

The following **notifications** are supported:

- **Clear Traps**: Clears all alarms for a particular transmitter.
- **Clear Site**: Clears all alarms for all devices from a particular site.
- **Clear All**: Clears all alarms for all devices from all sites.
