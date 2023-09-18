---
uid: Connector_help_Marlink_Trouble_Ticket_Interface
---

# Marlink Trouble Ticket Interface

The **Marlink Trouble Ticket Interface** element can create and resolve trouble tickets on an online service for each SLA outage. It also provides an overview of all created and all failed tickets, and an info summary for each SLA.

## About

The **Marlink Trouble Ticket Interface** connector makes it possible to create or resolve tickets by sending queries to the element via Automation, or by manually adding tickets in a table.

The ticket data is sent via an HTTP POST command and the ticket response ID is parsed by DataMiner. In case ticket creation fails, the entry in question will be entered in the **Failed** table.

With a tree control, you can navigate through the different SLAs and created tickets.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 1.0.1.x          | Connector review   | No                  | Yes                     |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP of the online service where the tickets need to be placed, e.g. *27.96.104.57.*
- **IP Port**: The IP port of the service is port "*80*" (fixed).
- **Bus Address**: "*byPassProxy*" (fixed).

## Usage

### General

This page displays a tree control with all SLAs that have created a trouble ticket. Among the available information, you can find the **Installation ID**, **Last Requested Ticket**, **Timestamp**, and **number** **of Requested**, **Open**, **Resolved** and **Failed Tickets**.

For each SLA, you can enable or disable ticket creation by changing the **SLA Ticketing Enabled** parameter (set to *Enabled* by default).

When an SLA is selected, an overview of all created trouble tickets is displayed, and the following extra information is available: **Incident Description** and **Incident** **Severity**, **SLA DMA EID**, **Element name**, **Outage ID**, **Outage Status** and **Last Change Timestamp**.

### SLA Configuration

This page displays the **SLA Ticket Config Table**, with the ticket configuration information for each of the remote SLAs. Above the table, you can find the **Poll SLAs** button, which will check all SLAs in the DMS and update the table. (This is also done automatically every 24 hours and at startup.)

### Ticket Overview

This page contains the **Ticket Overview Table**, with detailed information about all the tickets. By right-clicking the table, you can access a context menu to create, resolve or delete tickets.

### Failed Ticket Overview

This page displays the **Failed Ticket Request Overview** table, which contains information about the failed tickets requests (**Failure Timestamp**, **Installation ID Failed**, **SLA DMA EID Failed**, **SLA DMA Element name Failed**, and **Failure Reason)**.

The context menu of the table allows you to delete items or clear the table.

### Gateway Configuration

This page contains the configurable parameter **Web Service Path**, which is the path where the tickets will be created on the online service (the default path is *biztalk/biztalk.cfc*?WSDL).

The **Query Add Ticket** parameter is used for queries that are sent to the element on pid:200. These must have the following format:

> *CREATE\|sInstallationID\|sIncidentDescription\|iIncidentSeverity\|sDmaEid\|sElementName\|sOutageId\|iOutageStatus*

Or

> *RESOLVE\|sTicketID\|sIncidentDescription*

Note that:

- "iIncidentSeverity" is an integer with possible values '1' (Medium), '2' (Minor), '4' (High) or '5' (Critical).
- "iOutageStatus" must always be '1' because a newly created ticket is always '1' (Open).

The page also contains a toggle button **Auto Resolve Tickets**, which can be used to enable or disable automatic ticket resolution (by default it is set to *Enable*).

A number of other configuration parameters are also available on this page: **Default Delay Time, Alarm System, Ticket Overview Table Maintenance (Row Count)** and **Ticket Overview Table Maintenance (Timespan)**.

### Hidden

This page contains internal parameters used by the connector, such as buffer parameters, which can be manually cleared using the buttons **Clear Buffer Stack** and **Clear Retry Stack**.

### Web Interface page

This page provides access to the web portal of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **buffer mechanism** is implemented from version **1.0.1.3** onwards. When the web service is not available for a while, messages will be buffered and retried every 5 minutes.
