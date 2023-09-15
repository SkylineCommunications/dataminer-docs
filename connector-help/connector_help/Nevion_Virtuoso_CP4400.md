---
uid: Connector_help_Nevion_Virtuoso_CP4400
---

# Nevion Virtuoso CP4400

This is a DataMiner connector for the **Nevion Virtuoso CP4400**, a device for the processing and handling of MPEG transport streams.

## About

This SNMP connector is used to monitor and configure the **Nevion Virtuoso CP4400**.

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact** |
|----------------------|---------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version     | \-           | \-                |
| 1.0.1.x              | New HTTP connection | 1.0.0.2      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.8.70                 |

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

#### HTTP Connection (Range 1.0.1.x)

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page allows the monitoring and configuration of basic information related to the device, such as the **System Description** and **System Name**.

### Device Status

This page allows the monitoring and configuration of the status information regarding ASI and Ethernet interfaces, by means of a tree view. Other interfaces can also be found on this page, e.g. **Ref Sync Input**, but no additional information is provided on these.

The page also contains page buttons to the following subpages:

- **Ethernet**: Contains all the tables related to Ethernet interfaces used in the tree view.
- **ASI Inputs**: Contains all the tables related to ASI input interfaces used in the tree view.
- **ASI Outputs**: Contains all the tables related to ASI output interfaces used in the tree view.

### Alarms

This page allows the monitoring of all active alarms on the device provided by the system itself.

It also contains a page button, **Alarms Log**, which displays a table with the log of all the alarms. As this can be a very large table, the **Polling Status** toggle button allows you to enable/disable its polling**.**

### Alarms (Range 1.0.1.x)

In range 1.0.1.x, the information about the **Active Alarms** was moved to a subpage and a table for the **Current Alarms** was added on the main page.

### Chassis Config

This page allows the monitoring of information regarding the physical cards available on the device. It also allows the configuration of the mode for each available interface.

### Time Settings

This page allows the monitoring and configuration of time-related information, including the **SNTP Time Source**.

It also contains a page button, **Leap Seconds**, that allows the monitoring and configuration of the information regarding leap seconds.

### TXP Settings

This page allows the monitoring and configuration of the information regarding the TXP configuration.

### SNMP Settings

This page allows the monitoring and configuration of the information regarding the SNMP configuration, as well as the SNMP trap servers.

### Maintenance

This page allows the monitoring of basic information regarding device physical cards.

### Users

This page allows the monitoring of basic information regarding stored sessions of users.

### Switches (Range 1.0.1.x)

This page displays information about the unit **Switches** and the **Switch Inputs**.

### Seamless Switches (Range 1.0.1.x)

This page displays information about the unit **Seamless Switches** and **Seamless Switch** **Inputs**.

### Network

This page allows the monitoring and configuration of network information regarding all Ethernet interfaces, by means of a tree view.

The page also contains page buttons to the following pages:

- **IP Interfaces:** Contains all the tables used in the tree view.
- **IP Routes:** Contains the table regarding the static IPv4 configured routes.
- **IP Snooping:** Contains all the tables and status parameters related to the snooping capability provided by the device.
- **IP Ping**: Contains all the information regarding the running ping actions (Manual and Channel pings).

### Connect (Range 1.0.1.x)

On this page, you can set up the **Credentials** and the **Authentication Method** for the HTTP connection.
