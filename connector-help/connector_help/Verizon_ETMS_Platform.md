---
uid: Connector_help_Verizon_ETMS_Platform
---

# Verizon ETMS Platform

This connector integrates the Verizon electronic ticket management system (ETMS).

## About

This connector interacts with the ETMS Platform via Apigee endpoints.

### Version Info

| **Range**     | **Description**                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version                    | No                  | Yes                     |
| 1.1.0.x              | New proxy DLL integrated           | No                  | Yes                     |
| 1.2.0.x              | Uses Apigee to interface with ETMS | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                    |
|------------------|------------------------------------------------|
| 1.0.0.x          | 18.8.1.1.August18 (Wed, Aug 08 2018 20:09 GMT) |
| 1.1.0.x          | 19.7.1.3.July19 (Wed, Jul 10 2019 23:32 GMT)   |
| 1.2.0.x          | Apigee                                         |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION

- **IP address/host**: [https://oa-uat.ebiz.verizon.com](https://oa-uat.ebiz.verizon.com/)
- **IP port**: 443
- **Bus address**: *ByPassProxy*

### Configuration of Authentication

On the Configuration page, you can enter the **Username,** **Password and API Key** to authenticate with the ETMS.

You must provide a value in the **Route To** parameter to specify which environment the requests will be sent to.

The **Service Account** must be set to *True* if Username and Password belong to a service account, otherwise this must be set to *False*.

The **Ticket List ID** contains the ID of the ticket list that the connector will poll from and populate the **Ticket Overview** table with.

### Configuration of ETMS Integration

With the **Element Type**, you can configure whether the connector should act as front end or back end.

- *Frontend* (1): Can poll all the tickets and show them on the Ticketing page. The front end is also responsible for the communication with the DataMiner Ticketing system.
- *Backend* (1+): Responsible for the processing of incoming tickets and updates towards the ETMS.

When the element is acting as back end, you can enable/disable the **Ticket Handling**. If this is disabled, no communication is allowed via the ETMS.

## Usage

### General

This page contains statistics for all the tickets on the ETMS:

- **Total Tickets**: Total number of tickets.
- **Managed Tickets**: Number of tickets managed by AutoVSATDataMiner.
- **Circuit Up/Down**: Number of tickets of circuit up/down.
- **Circuit Performance**: Number of tickets of circuit performance.
- **Circuit Network Connectivity**: Number of tickets of circuit network connectivity.
- **Infrastructure Up/Down**: Number of tickets of infrastructure up/down.
- **Infrastructure Performance**: Number of tickets of infrastructure performance.
- **Infrastructure Network Connectivity**: Number of tickets of infrastructure network connectivity.

### Ticketing

This page is only visible for an element configured as front end and gives an overview of all the tickets. The **Refresh Time** parameter allows you to select the polling time for the ETMS tickets.

Right-clicking a row in the **Ticket Overview** table will display a context menu where you can select **Show Activity Log**. This will copy the full activity log of the **Activity Log** parameter.

### Configuration

The **Connection Status** provides information about the authentication towards the ETMS.
