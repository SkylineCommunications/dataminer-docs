---
uid: Connector_help_Fortinet_FortiSandbox
---

# Fortinet FortiSandbox

This protocol is used to monitor the FortiSandbox server. A FortiSandbox server is used to validate possible threats by examining them in a secure environment.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.01                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Web Interface

The FortiSandbox web interface is available from the connector. However, the web interface is only accessible when the client machine has network access to the product.

## How to Use

### General page

The General page displays general information about the device: the **system name**, **serial number**, **firmware version** and **system up time**. This page also displays some key device metrics, i.e. the **CPU usage** (with and without Nice processes), **memory usage**, **memory capacity** (amount of RAM installed in the system), **disk usage** and **disk capacity**.

### Software

The Software page displays the **version** of each threat detection component, the **tracer engine**, **rating engine**, **system tools**, **system sniffer**, **network alerts signature database**, **Android analytic engine** and **Android rating engine**.

### Accounts

The Accounts page contains two tables, one for **user accounts**, the other for **administrator accounts**. These are used for firewall authentication. The user accounts table displays the **name** of the account, the **authentication method** and the **state** of the account. The administrator accounts table displays the **name** of the account, along with information about the address that identifies from where the administrator account can be accessed (the **address type**, the **address** itself and the **subnet mask**).

### Jobs

The Jobs page contains metrics related to jobs that currently being run in the sandbox. Each job is a possible threat being investigated. At the top of the page, you can see the **number of pending job queue assignment files** and the total **number** **of jobs** being processed. The number of jobs per category (**executable files**, **PDF files**, **Office files**, **Flash files**, **web files**, **Android files**, **Mac files**, **URL jobs**, **user defined files** and **non-sandboxing files**) is also displayed.
