---
uid: Connector_help_Beenius_IPTV_Delivery_Platform
---

# Beenius IPTV Delivery Platform

Beenius Beesmart IPTV Delivery Platform is an integrated platform for heterogeneous operator environments. Beenius IPTV connectors are used to display and configure parameters of the Beenius IPTV delivery platform device.

## About

The **Beenius Beesmart IPTV Delivery Platform** connector provides an overview of useful information about Channels, Regions and Events, using different connection protocols (HTTP-SNMP) to keep the information updated. The connector also allows the user to set some of its parameters.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.2.2.6                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP Settings:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### System Information

This page displays an overview of the system information parameters. It also allows you to set the **Operator UID**, which is required for requests via HTTP.

### Events

This page contains a number of page buttons, which open pop-up pages that each contain SNMP parameters and a **Traps Table** with the same parameters, but retrieved via traps in order to keep the different events updated. The **Traps Tables** list all stored traps, ordered from new to old. The number of rows in these tables is determined via the **Number of Traps** parameter below the tables.

The following pop-up pages are available:

- **Server Events**: Provides an overview of the changes related to the MSDP service.
- **Cluster Events**: Provides an overview of the changes related to the state of the Cluster
- **Job Events**: Provides an overview of the changes related to the state of the Jobs.
- **Epg Events**: Provides an overview of the changes related to the EPG ingest.
- **DataBase Events**: Provides an overview of the changes related to the state of the Database connection pool.
- **License Events**: Provides an overview of the changes related to the state of the License pool.

### All Channels

This page displays a table with a list of all channels defined in the system.

Note that parameters retrieved via **HTTP** use the value from the parameter **Operator UID** located on the System Information page.

### All Devices Types

This page displays a table with a list of all device types.

Note that parameters retrieved via **HTTP** use the value from the parameter **Operator UID** located on the System Information page.

### All Regions

This page displays a table with a list of regions.

Note that parameters retrieved via **HTTP** use the value from the parameter **Operator UID** located on the System Information page.

### All Services

This page displays a table with a list of all services, available for subscription, for the relevant operator.

Note that parameters retrieved via **HTTP** use the value from the parameter **Operator UID** located on the System Information page.

### Licensed Services

This page displays a table with a set of licensed services of type BASIC_SERVICE or EXTENDED_SERVICE (retrieved by checking all services from the SERVICES table against services from the license).

Note that parameters retrieved via **HTTP** use the value from the parameter **Operator UID** located on the System Information page.
