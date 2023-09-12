---
uid: Connector_help_BGC_Live_Ads
---

# BGC Live Ads

**BGC Live Ads** is a data collector driver. This driver allows the user to monitor jobs and their related clients. An SNMP connection is used to retrieve information from the device.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | /                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### SNMP Main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Bus address**: Not required

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default: *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element created with this driver consists of the following data pages:

- **General**: Contains a tree control displaying the different **jobs** and their **related** **clients**. The information displayed in this tree control can also be viewed in the tables on the Jobs, Clients and Clarity pages.
- **Jobs**: Contains the Jobs Table, which has an Instance and Name column. The page also displays the Job Path.
- **Clients**: Contains a table with all the information regarding the clients: Instance, related Job Index, Client Name, Link Status, Data Status, Build Status and Mode. The Status can have the following values: *Not Applicable*, *Ok* or *Error*. The Mode can be *Not Applicable*, *Live* or *Generic*.
- **Clarity**: Contains the Clarity Table, with the columns Instance, related Job Index, Clarity Name and Status.
