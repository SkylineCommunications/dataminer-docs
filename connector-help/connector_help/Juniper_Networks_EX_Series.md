---
uid: Connector_help_Juniper_Networks_EX_Series
---

# Juniper Networks EX Series

The Juniper Networks EX Series connector is an SNMP-based connector used to monitor and configure the Juniper Networks with EX series.

### Version Info

| **Range**            | **Key Features**   | **Based on** | **System Impact** |
|----------------------|--------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version    | \-           | \-                |
| 1.0.1.x              | New SSH Connection | 1.0.0.2      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### SSH Connection

This connector uses SSH and requires the following input during element creation:

SSH CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP Port**: The IP port of the destination (Default: 22)

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product. In addition, this interface needs to be enabled on the device.

## How to use

The element consists of the following data pages:

- **General**: Contains general information about the device.
- **System Health**: Allows you to monitor temperature, memory and CPU load.
- **Operating States**: Displays the operating states of the different components of the device. Also allows you to import and export the monitoring configuration.
- **Chassis**: Provides information about the different containers and contents of the device.
- **Configuration**: Contains configuration parameters to enable or disable polling of various tables. Also displays information about configuration events.
- **Alarms**: Provides information about the yellow and red alarms.
- **Interfaces**: Contains the Interface Table. Also allows you to choose the naming format to identify interfaces in all 4 tables, including those that are accessible via page buttons. The Interface Poll table allows you to enable or disable polling for each interface.
- **IP**: Contains different monitoring parameters related to IP.
- **VLAN**: Contains monitoring and configuration parameters for everything related to VLAN.
