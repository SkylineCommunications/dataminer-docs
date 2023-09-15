---
uid: Connector_help_Eutelsat_Siecams_Manager
---

# Eutelsat Siecams Manager

This DataMiner connector allows to monitor the Tx and Rx power of multiple carriers/txp, based on the information stored in the (Oracle) database of the SIECAMS monitoring system.

## About

The connector connects to the configured Oracle database to retrieve data. Two tables are queried: "BG_MEAS" (displayed on **Carrier** page) and "TXP_EIRP" (displayed on **TXP** page).

Because this connector uses a virtual connection, no communication can be seen in the element stream viewer.

Each data row contains the timestamp when the values were measured. When values are older than x minutes, the values are replaced with the "NA" value. This timeout time is configurable on the **Setup** page.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the Oracle database settings

On the **Setup** page, the Oracle database credentials must be configured, before the element will be able to gather data from the Oracle database.

## Usage

### Carrier page

Contains a table with one line per carrier. Carriers can be added manually to the table, or imported from a CSV file.

Only carriers that are defined in the table are polled in the database.

### TXP page

Contains a table with one line per sat + txp pair. Rows can be added manually to the table, or imported from a CSV file.

Only the items that are defined in the table are polled in the database.

### Setup page

On this page, some important parameters can be configured:

- **Database credentials**: server address + port, username, password
- **Polling Interval**: data is polled from the Oracle database every x seconds
- **Carrier Discard Time**: measured values in **Carrier Table** that are older than x minutes are discarded, and replaced with "NA" value
- **TXP Discard Time**: measured values in **TXP Table** that are older than x minutes are discarded, and replaced with "NA" value

### Statistics page

Shows statistics about the database connection: status and time to execute the queries
