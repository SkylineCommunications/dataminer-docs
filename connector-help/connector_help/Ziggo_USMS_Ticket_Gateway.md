---
uid: Connector_help_Ziggo_USMS_Ticket_Gateway
---

# Ziggo USMS Ticket Gateway

The **Ziggo USMS Ticket Gateway** creates, updates and queries incident, change and problem tickets in USMS via the Oracle MiddleWare.

## About

The **Ziggo USMS Ticket Gateway** will receive commands from **elements** or **Automation scripts** that need to be sent to USMS via the Oracle MiddleWare (SOAP call).

The **initial** version only supports the **creation** of **incident tickets** and returns the **Ticket ID** to the source that sent the request to the Ziggo USMS Ticket Gateway.

The **1.1.0.x range** is backwards compatible with the initial range, but was extended to support **creation**, **updates** and **queries** for **incidents**, **changes** and **problems**. In case of creation, just the ticket ID is returned, otherwise all ticket details are returned.

There is an **offload mechanism** available to store the created tickets on the local system as a CSV file.

### Version Info

| **Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                           | No                  | Yes                     |
| 1.1.0.x          | New firmware based on 1.0.0.x (see below) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | v1                          |
| 1.1.0.x          | v2                          |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### Status Overview

This page displays the **Ticket Status Overview** table, which contains the requests that have been sent to the Oracle Middleware, with their **Status** (*Succeeded* or *Failed*) and the **Reason of Failure** when applicable.

The parameter **Number of Incidents** displays the number of entries in the **Ticket Status Overview** table and can be trended, so that the number of incidents during a certain time period can be tracked.

### External Requests

This page displays the **External Requests Overview** table, which contains the received external requests. These external requests are waiting for an execution or a retry in case the previous execution(s) failed.

### Configuration

On this page, different settings regarding SOAP and offload can be configured.

The **External Configurations Overview** table can be used to indicate where the ticket response should be sent when no element/parameter info was specified in the command sent to **Ziggo USMS Ticket Gateway**.

#### SOAP CONFIG

The SOAP Config section of the page consists of the following parameters:

- The **Username** and **Password** for the SOAP call that will be sent to the Oracle MiddleWare. The **Password** is optional.
- The **Number of Retries** in case the SOAP call fails.
- The **Query Ticket Limit**, which indicates how many tickets can be retrieved per query (only for query requests available from 1.0.1.x).

#### OFFLOAD CONFIG

The parameters **Max Amount of Incidents** and **Amount of Incidents to Offload** in the Offload Config section have an impact on the **Ticket Status Overview** table. **Max Amount of Incidents** determines how many entries the table can contain before an offload will occur, while **Amount of Incidents to Offload** determines the number of entries that will be offloaded. The number of remaining entries in the table is based on the formula **Max Amount of Incidents - Amount of Incidents to Offload**. As such, even if the table already contains more entries than the allowed maximum, the remaining entries after an offload will always be the same, based on the configuration.

The other parameters in this section are used to configure when the offload check will be done, how the offload files will be stored and how long those files will be stored:

- In the **Offload Path** folder, subfolders will be created on a daily basis, with the name *yyyy_MM_dd*. These subfolders will contain offload CSV files with the structure *Offload\_\<Hour\>\_\<Timespan\>,* where *\<Hour\>* is the starting hour of the offload files and *\<Timespan\>* is the value from the parameter **Offload File Timespan**.
- With the parameter **Offload File Local Storage Period**, you can configure how long the offloaded files will be stored in the local system. This option can be set to *Disabled*, in which case there will be no cleanup of the local system.
