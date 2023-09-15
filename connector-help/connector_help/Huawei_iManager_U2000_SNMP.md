---
uid: Connector_help_Huawei_iManager_U2000_SNMP
---

# Huawei iManager U2000 SNMP

This connector uses an **SNMP** connection to monitor the Huawei iManager U2000.

## About

The **iManager U2000 Unified Network Management System** is designed to efficiently and uniformly manage transport, access, and IP equipment in both the network element (NE) layer and the network layer. The U2000 provides unified management and visual operation and maintenance (O&M) to help operators reduce O&M costs and transform networks to all-IP networks.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### Filters

This page allows you to set filters, including filters for the **Alarms**, **Alarm Clears**, **Acknowledge Alarms** and **Unacknowledged alarms**.

Two filters can also be set for the synchronization: **Synchronization command start** and **Synchronization command stop**.

### Trap Table

This page contains a **Traps** **table**, which displays the received traps along with all their bindings. At the top of the page, the page button **Trap Table Clear Options** opens a subpage page where clearing options can be defined.

Above the table, the **Traps number** parameter displays the number of traps that are currently in the table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

Although the U2000 system from Huawei can implement several different interfaces, this connector only implements the SNMP Interface used to send notifications and alarms (SNMP traps) to third-party systems.
