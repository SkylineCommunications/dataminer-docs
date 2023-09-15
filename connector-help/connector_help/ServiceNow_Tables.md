---
uid: Connector_help_ServiceNow_Tables
---

# ServiceNow Tables

The ServiceNow Tables protocol is a DataMiner connector used to connect to ServiceNow Web API and retrieve the information stored in ServiceNow Tables.

## About

The ServiceNow Tables protocol is an HTTP connector. This protocol keeps a record of different ServiceNow Tables and polls them automatically every certain number of seconds or manually by customer request. For each ServiceNow Table this protocol allows to register different susbcribers. A subscriber is another DataMiner element that will be notified each time its associated ServiceNow Table is polled.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address. (Default: ByPassProxy)

## Usage

### General

The **General** page includes two tables: **ServiceNow Tables** and **Remote Suscribers**.

The **ServiceNow Tables** allows to register different ServiceNow tables. Using a context menu, new ServiceNow tables can be added or existing ServiceNow tables can be removed. For each entry the following parameters are displayed: **Table Name, Status, Polling Frequency, Last Polled Timestamp, Response Format, Column Filter, Row Filter** and **Response Limit**. Each ServiceNow table can be polled manually by means of the **Poll Now** button.

The **Remote Subscribers** allows to register different subscribers for each ServiceNow Table. Using a context menu, new subscribers can be added or existing subscribers can be removed from the table. For each entry the following parameters are displayed: **ServiceNow Table, DataMiner Element, Element Parameter, Parameter Index** and **Status**. The **Parameter Index** is only required if the subscriber **Parameter** is a table column.

### Configuration

The Configuration page includes two groups of parameters: **Credentials** parameters and **Timing** parameters.

The **Credentials** parameters include the ServiceNow **Server IP** address and the **Username** and **Password**.

The **Timing** configuration parameters include the interval used as a **Base Time** to refresh the ServiceNow Tables, the **Base Time** Counter that displays the number of seconds left until the next ServiceNow Tables refresh and the **Polling Flag** that indicates if a ServiceNow Table is been polled or not.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

Revision History

DATE VERSION AUTHOR COMMENTS15/06/2018 1.0.0.1 AIG , Skyline Initial Version
