---
uid: Connector_help_Ruckus_Wireless_Virtual_SmartZone
---

# Ruckus Wireless Virtual SmartZone

The Ruckus Wireless Virtual SmartZone driver can be used to monitore and configure the Ruckus Wireless Virtual SmartZone Management System.

## About

To driver uses SNMPv2 to retrieve data from the Ruckus Wireless Virtual SmartZone Management System. Traps can also be forwarded to DataMiner and will be processed by the driver as well.

### Ranges of the driver

| **Driver Range** | **Description**                                      | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                      | No                  | Yes                     |
| 1.0.1.x          | Updated displaykey for Access Point Statistics table | No                  | Yes                     |
| 1.1.0.x          | Update OIDs to support firmware version 3.6          | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | /                           |
| 1.0.1.x          | 3.2                         |
| 1.1.0.x          | 3.6                         |

## Installation and configuration

### Creation

This driver uses a Simple Network Management Protocol (SNMPv2) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

### System Summary

This page contains limited information about the system.

### Statistics - All Access Points WLAN

This page contains the data throughput statistics for all WLANs.

### Statistics - Single Access Points WLAN

This page contains the WLAN Statistics table, which contains statistics for each WLAN individually.

### Statistics - All Access Points

This page displays the Access Point Statistics table, which contains statistics about individual Access Points.

### Configuration - All Access Points

This page contains the WLAN Configuration table with the configuration of every Access Point.

### Trap Clean Up Config

This page can be used to configure the amount of traps that need to be kept.

### Traps

This page displays the amount of trap events.

Popup pages can be accessed to check specific traps:

- AP Events: traps related to access points
- Rogue AP Events: traps related to rogue access points
- Wireless Client Events: traps related to wireless clients

### Web UI

This page contains the linked device's web interface.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
