---
uid: Connector_help_Seiko_Time_Server_Pro._TS-2950
---

# Seiko Time Server Pro. TS-2950

The Time Server Pro. TS-2950 is an appliance to supply the exact time to computers and servers connected to a network.

The Seiko Time Server Pro. TS-2950 connector can be used to monitor Time Server Pro. TS-2950 servers.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.2.10                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *22*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **General** page contains information about the time server.

The **PTP**-related data can be found on the **PTP Base Clock** and **PTP Base Clock Port** pages.

The **GPS** and **GPS Satellite** data are polled via the SSH connection. This means that in order to get these data, you must make sure the SSH **user name** and **password** are filled in on the **General** page.
