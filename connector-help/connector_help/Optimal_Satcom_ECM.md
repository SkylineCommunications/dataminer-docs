---
uid: Connector_help_Optimal_Satcom_ECM
---

# Optimal Satcom ECM

## About

This protocol is specifically customized to connect with a particular **database** containing information about **Carriers**, **Leases**, **Transponders** and **Satellites**.

The protocol allows you to select an **RF switch** and a **spectrum analyzer**. The main page shows a logic tree view on the left, and on the right it shows the spectrum trace corresponding with the selected tree node.

### Version Info

| **Range** | **Description**                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                   | No                  | Yes                     |
| 2.0.0.x          | Specific version for Globecomm DB | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage (range 1.0.0.x)

### General

This page allows you to set certain general parameters, such as the database connection details (e.g. **Username**, **Password**, etc.).

### Overview

This page displays a tree control that functions as an overview.

### Carrier

This page shows the carrier table.

### Lease

This page shows the lease table.

### Transponder

This page shows the transponder table.

### Satellite

This page shows the satellite table.

### Antenna Details

This page shows the **Tx** and **Rx Antenna** tables.

### Monitor Site

This page shows the **Monitor Site Table**.

## Usage (range 2.0.0.x)

### Carrier

This page displays three tables:

- **ECM Short Carrier Data Table**: Contains a summary of the carriers listed in the ECM Carrier Data View.
- **Carrier Earth Station Relationship**: Displays the relationship between carriers, Tx earth stations and Rx earth stations.
- **ECM Carrier Data**: Contains the complete register obtained from the ECM Carrier Data View selected by the user in a specific session.

### Earth Station

This page displays the complete list of the earth stations obtained from the Earth Stations View.

### Earth Station Approval

This page displays the complete list of the earth station approval obtained from the Earth Stations Approval View.

### Earth Converters

This page displays the complete list of the earth station converters obtained from the Earth Stations Converter View.

### Configuration

On this page, you can perform the database configuration.

- The **Database Source** or **Server Name** must be specified as Host\SQL Server Name.
- The **Database Port** uses the MSSQL default port by default, but a different port may be specified.
- **Default Catalog** is the \[Database\].\[Schema\] required to connect to the DB views.
- The **User** and **Password** can be used to specify the credentials to access the database.

Several buttons are available that can be used to force the retrieval of particular information immediately. Normally, the carrier data short list is renewed every 24 hours, and the rest of the information every 72 hours. Session information is cleared every 6 hours.

The **Session Control Table** displays the last session connection used.
