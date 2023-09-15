---
uid: Connector_help_Integral_Systems_Monics
---

# Integral Systems Monics

This is a virtual connector that uses database queries to retrieve transponder, carrier and beacon measurements.

## About

This connector has two ranges, each with their own table layout depending on customer requirements. Since SQL calls are made directly to a database, no DataMiner interface is used and the database information needs to be entered after the element is created. An important feature of the connector is the alarm monitoring of the **EIRP** values with normalization.

### Version Info

| **Range** | **Description**                                                                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. In range 1.x.x.x, the minimum and maximum EIRP values are provided by a manager connector. | No                  | No                      |
| 2.0.0.x          | Different table design.                                                                                  | No                  | No                      |

### Product Info

This connector is not associated with particular firmware, but does require the correct database setup.

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

Once the element has been created, fill in the following information on its **General** page.

- **Server**: The URL or IP address of the database server, e.g. *localhost.*
- **UserName**: The username of an account with sufficient access rights, e.g. *guest.*
- **Password**: The password for the account specified above, e.g. *guestPassword.*
- **Database** **Name**: The name of the database to access, e.g. *SCDB.*

When all information has been filled in, click the **Connect** button.

Note: For security reasons, the password value is not displayed.

## Usage

Once the database information has been entered as described in the "Configuration" section above, the database is polled every 2 minutes by default. The **Transponder**, **Carrier** and **Beacon** values will be updated in their respective tables.

Note: Some of the columns are filled in by a different connector/element.

### General

This page contains the database settings and the connection state. Click **Connect** after you have entered the database information.

### Carrier Measurements

This page displays the values for the carrier downlink and uplink measurements.

### Lease - Transponder Measurements

This page displays the values for the lease downlink measurements and Txp Downlink (XPDR).

### Beacon Measurements

This page displays the values for the beacon measurements.
