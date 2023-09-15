---
uid: Connector_help_BMC_Remedy
---

# BMC Remedy

**BMC Remedy Action Request System** (ARS) is a proprietary application server developed initially by Remedy Corp and acquired by BMC Software in 2002. It is best known as part of the BMC Remedy IT Management Suite, a set of applications that runs over ARS.

## About (1.0.0.x and 2.0.0.x)

This connector communicates with the BMC Remedy server via SOAP messages. The connector will create/update fault records on the server. In addition, the connector can mask views in DataMiner. This connector works together with four Automation scripts and with two executables.

## About (3.0.0.x)

This connector is used in conjunction with an Automation script to create and update incidents in the Remedy system, through HTTP communication.

Ranges of the connector

| **Range** | **Description**                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                          | No                  | Yes                     |
| 2.0.0.x          | Branch version based on 1.0.0.x          | No                  | Yes                     |
| 3.0.0.x          | Initial version for 3.0.0.x requirements | No                  | Yes                     |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses a serial connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, by default *80*.
- **Bus address**: A field that can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

## Usage (1.0.0.x)

### Alarm page

On this page, the **Managed Alarm Table** is displayed. This table contains all the Fault Records of the Remedy server.

It is possible to synchronize with Remedy by pressing the **Synch Alarms** button.

### Settings page

On this page, the following settings can be adjusted:

- **TTL FRID**: The maximum amount of time the connector will look for the FRID of the ticket.
- **HTTP URL**: The URL that the SOAP messages will be sent to.
- **Form Name**: The name of the form that the SOAP messages will be sent to.
- **Mid Tier Server**: The name of the mid-tier server.
- **Server Name**: The name of the server that will be used to open the Remedy fault records.
- **Search Form Name**: The name of the form that will be used to open the Remedy fault records.
- **Directory Executables**: The directory where the executables are stored that are used to open Remedy.
- **Username** : The username used to log in to Remedy.
- **Password**: The password used to log in to Remedy.

## Usage (2.0.0.6)

### Alarms page

This page provides an overview of the **Root Alarms** and the **Related Alarms**. The **Root Alarms** table contains the **Request ID**, **Ticket ID** and **Ticket State**.

The **Related Alarms** table contains the ID of the alarm, the link to the root alarm (**Root Alarm ID FK**) and the **Request ID** of the related alarm.

### Message Queue

On this page, the **Message Queue** table provides an overview of all the messages that need to be processed. (This only applies to elements of which the operation mode is set to local.)

**Message Count** and **Request Count** indicate the number of messages and the number of requests (a message typically will consists of a number of requests), respectively.

### Mapping page

On this page, the **Branch Manager Overview** table provides an overview of the Branch Manager elements and their DataMiner ID.

### Settings page

This page contains configuration options for the connector:

- **Webservice URL**: The URL of the web service.
- **Username**: The username that must be provided to use the web service.
- **Password:** The password that must be provided to use the web service.
- **Operational Mode**: This denotes the location of the Service Desk. If set to local, the element can communicate directly with the Service Desk. If set to remote, communication will go via a Branch Manager element.
- **Number of Retries**: This indicates the number of times a SOAP call has to be repeated in case a call fails.
- **Auto Clear**: With this setting, you can automatically clear entries in tables that have been there longer than the specified number of days, which are therefore probably alarms that are no longer relevant.

### DEBUG page

This page contains some parameters that hold communicated messages.

## Usage (3.0.0.1)

### Connection

This page displays a **Connection Status** parameter with the response status of the last request and the current **Remedy Address**. It also displays a configurable **Remedy username** and **password** and two configurable **endpoints** for creating a ticket and updating a ticket. Finally, it also contains two buttons that can be used to retrieve the element tags from the WSDL of the web service. These will then be available in the **Mapping Table Remedy Element Tag** drop-down list.

### Mappings

This page displays a **Mapping Table** with the relations between the alarm properties from the selected alarm and the fields sent to the remedy web service. These relations can be deleted. Each row in this table will produce an element sent in the Remedy SOAP request's body.

You can use the **Load Properties** button to load DataMiner alarm properties that can then be selected in the **Alarm Property** drop-down list. The **Add Row** button can be used to add a new row to the **Mapping Table**.

Custom element tags can be added to the body of the SOAP request with the **Add Remedy Element Tag** parameter. **Clear Element Tags** will clear all tags from the **Remedy Element Tag** drop-down list.
