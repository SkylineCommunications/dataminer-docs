---
uid: Connector_help_MySql_Stratos_Perth_CDIS
---

# MySql Stratos Perth CDIS

This connectors polls a MySQL database.

## About

This connector sends MySQL queries to a MySQL database and fetches the returned rows.

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version  | No                  | Yes                     |
| 1.1.0.x          | Based on 1.0.0.x | No                  | Yes                     |

## Installation and configuration

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

- Interface connection:

  - **IP address/host**: The polling IP of the device (e.g. *192.168.10.19*).
  - **IP port**: Not required.
  - **Bus address**: Not required.

## Usage

### DataMiner Provider Query

This page contains the **DataMiner Provider Query** table, which displays the following information: **Provider \[IDX\], Provider Number of Calls, Provider Number of Successful Calls, Provider Call Success Ratio, Provider Average Call Duration, Provider Total Call Duration**.

Extra parameters determine the start and end limits used to fetch the database records: **DataMiner Provider Query Start Time (UTC)** and **DataMiner Provider Query End Time (UTC)**.

The **Security** page button provides access to the configuration of **Username** and **Password**.

### DataMiner Traffic Flow Query

In the **DataMiner Traffic Flow Query** table, for each **Traffic Flow Call Direction**, the following data are displayed: the **Traffic Flow Number of Calls, Traffic Flow Number of Successful Calls, Traffic Flow Call Success Ratio, Traffic Flow Average Call Duration** and **Traffic Flow Total Call Duration**.

Extra parameters determine the start and end limits used to fetch the database records: **DataMiner Traffic Flow Query Start Time (UTC)** and **DataMiner Traffic Flow Query End Time (UTC)**.
