---
uid: Connector_help_Ruckus_Wireless_Virtual_SmartZone
---

# Ruckus Wireless Virtual SmartZone

The Ruckus Wireless Virtual SmartZone connector can be used to monitor and configure the Ruckus Wireless Virtual SmartZone Management System.

The connector uses SNMPv2 to retrieve data from the Ruckus Wireless Virtual SmartZone Management System. Traps can also be forwarded to DataMiner and will be processed by the connector as well.

## About

### Version Info

| **Range** | **Description**                                        | **DCF Integration** | **Cassandra Compliant** |
|-----------|--------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version.                                       | No                  | Yes                     |
| 1.0.1.x   | Updated display key for Access Point Statistics table. | No                  | Yes                     |
| 1.1.0.x   | Updated OIDs to support firmware version 3.6.          | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | 3.2                    |
| 1.1.0.x   | 3.6                    |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMPv2) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### System Summary

This page contains limited information about the system.

### Statistics - All Access Points WLAN

This page contains the data throughput statistics for all WLANs.

### Statistics - Single Access Points WLAN

This page contains the WLAN Statistics table, which contains statistics for each WLAN individually.

### Statistics - All Access Points

This page displays the Access Point Statistics table, which contains statistics for the individual access points.

### Configuration - All Access Points

This page contains the WLAN Configuration table, with the configuration of every access point.

### Trap Clean Up Config

This page can be used to configure the number of traps that need to be kept.

### Traps

This page displays the number of trap events.

You can access subpages to check specific traps:

- **AP Events**: Traps related to access points.
- **Rogue AP Events**: Traps related to rogue access points.
- **Wireless Client Events**: Traps related to wireless clients.

### Web UI

This page contains the linked device's web interface.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
