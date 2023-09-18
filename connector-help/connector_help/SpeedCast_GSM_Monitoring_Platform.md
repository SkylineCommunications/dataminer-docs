---
uid: Connector_help_SpeedCast_GSM_Monitoring_Platform
---

# SpeedCast GSM Monitoring Platform

This connector is a SpeedCast-specific development used to poll an internal GSM database.

## About

This connector is used to poll a SpeedCast internal GSM database and use this information to create and populate a dedicated DVE for each ship using these GSM services.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

To make sure the connector functions properly, fill in the configuration parameters on the **Configuration** **page**.

## How to use

Aside from the Configuration page, the element created with this connector consists of the following data pages:

- **General**: This page lists all ships using GSM services according to the DB records. The page can also be used to enable/disable the DVE for specific ships.
- **Ships**: This page lists all created ship DVEs.
- **BTS**: This page lists the Base Transceiver Stations to which the ships are connected.
- **BTS Alarm**: This page contains tables with the information issued by alarm reports sent by the Base Transceiver Stations.
- **Pending Alarms**: This page lists all GW- and GSM-related alarms.
