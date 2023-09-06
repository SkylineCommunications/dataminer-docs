---
uid: Connector_help_LGI_Spectrum_Trap_Receiver
---

# LGI Spectrum Trap Receiver

This driver can be used to store and monitor traps from a specific port. It is a custom-made driver based on the **Generic Trap Receiver** driver.

## About

This driver only retrieves **SNMP traps**. No other data is polled.

### Ranges of the driver

| **Driver Range**     | **Description**                                                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                    | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Added Incident ID (column shift, could potentially affect reports) | No                  | Yes                     |

## Installation and configuration

### Creation

#### SNMP connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The traps IP of the device.

SNMP Settings:

- **Port number**: 161
- **Get community string**: Not required.
- **Set community string**: Not required.

## Usage

### General

This page displays the **Trap Table**, which contains all the data for each specific trap. The **Total Traps** parameter shows how many traps are present in the table.

Every 10 minutes, the driver checks whether this table exceeds the specified maximum number of traps or the maximum duration, and cleans up the table if necessary. These settings can be configured via the **Auto Clear** page button.

### Heartbeat

The driver picks up heartbeats sent from the device, and if the OID of the incoming trap is the same as configured in the **Heartbeat OID** parameter, the **Time Since Last Heartbeat** will be updated.

The **Last Trap** parameter will be updated whenever a trap is received, regardless of whether it is a heartbeat.
