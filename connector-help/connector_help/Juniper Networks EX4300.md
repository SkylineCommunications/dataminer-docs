---
uid: Connector_help_Juniper_Networks_EX4300
---

# Juniper Networks EX4300

The Juniper Networks EX4300 driver is an SNMP-based driver used to monitor and configure the Juniper Networks EX4300.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

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

### Webinterface

The web interface is only accessible when the client machine has network access to the product. Note that this interface should be enabled first on the device.

## How to use

### General Page

This page contains some general information about the device.

### System Health Page

The three tables on this page provide monitoring for temperature, memory and CPU load.

### Operating States Page

Three tables display the operating states of the different components of the device.
This page also provides the possibility to import/export monitoring configuration.

### Chassis Page

This page provides information about the different containers and contents of the device.

### Configuration Page

This page provides configuration parameters to enable or disable polling of various tables.
It also displays some information about configuration events.

### Alarms Page

This page provides information about the yellow and red alarms.

### Interfaces Page

This page contains the Interface Table. It also provides the option to choose the naming format used to identify interface in all 4 tables, including those that are accessible via the pagebuttons.
The Interface poll table provides the option to enbale or disable polling for each interface.

### IP Page

Different monitoring parameters concerning IP can be found on this page.

### VLAN Page

The tables on this page provide monitoring and configuration parameters for everything related to VLAN.


