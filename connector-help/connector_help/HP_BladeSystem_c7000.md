---
uid: Connector_help_HP_BladeSystem_c7000
---

# HP BladeSystem c7000

The HP BladeSystem c7000 enclosure can hold up to 16 server blades. This connector allows you to monitor and configure the racks from the HP BladeSystem c7000.

An **SNMP** connection is needed for the connector so that it can retrieve and send information from/to the device.

## About

### Version Info

| **Range**            | **Key Features**                              | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                              | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Additional trap support and checklist review. | 1.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMPv3 Settings:

- **Username**: The SNMPv3 username.
- **Security level**: The SNMPv3 security level.
- **Authentication type**: The SNMPv3 authentication type.
- **Authentication password**: The SNMPv3 authentication password (default: *public*).
- **Privacy type**: The SNMPv3 privacy type.
- **Privacy password**: The SNMPv3 privacy password (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

On this page, you can find system and rack information, as well as the **Rack Mib RevMajor, Rack Mib RevMinor** and **Rack Mib Condition**.

The **Rack Table** shows overview of all the racks included in the HP BladeSystem enclosure.

Additional fan and power supply information is available via page buttons:

- **Fan**: Displays a table with information such as Enclosure Fan Rack, Enclosure ID, Name and Serial Number, as well as Fan Presence and Condition Status.
- **Power Supply**: Displays three tables: Rack Power Enclosure, Power Supply, and Rack Enclosure Temperature.

### Network

The **Network Connector Table** on this page contains the following information: Rack, Chassis, Network ID, Network Name, Enclosure Name, Network Name, Network Model, Network Part Number, Network Spare Part Number, Network Serial Number, Network Type, Network Location, Network Presence, Network Fuses, Network Technology Type and Network Device Type.

### Blades

On this page, all information regarding the server blades is displayed in the **Blades Table**: Rack, Chassis, Blade, Blade Name, Enclosure Name, Blade Part Number, Blade Spare Part Number, Blade Serial Number, Blade Product ID, Blade Position, Blade Height, Blade Width, Blade Depth, Blade Present, Blade Fuses, and Slots Used (X and Y).

### Traps

This page displays the received alarm and notification traps in the **Alarms Table** and **Notifications Table**. Both tables have Timestamp, Rack Name, Event Type, Additional Info and Delete Info columns.

The two buttons below the tables allow you to **clear** **the alarms or notifications**.
