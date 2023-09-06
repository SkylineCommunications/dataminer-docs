---
uid: Connector_help_Newtec_Dialog_Platform_VSAT
---

# Newtec Dialog Platform VSAT

The **Newtec Dialog Platform VSAT** driver collects and organizes data from a Newtec Dialog platform that stores its metrics in a Time Series Database (TSDB, i.e. Influx DB). This driver was designed to work with the DataMiner EPM Solution.

## About

The Newtec Dialog monitoring system collects metrics from the Newtec dialog platform and stores them in a Time Series Database. This driver retrieves data from the Newtec Dialog Platform via its **REST API** and via the **TSDB API**. Data from both sources is aggregated into the driver.

The driver uses the following APIs:

- Newtec Dialog Restful Standard API (Central Dialog NMS): Configuration data of the Dialog system is retrieved using this API.
- Newtec Dialog TSDB API (Hub Gateway Database): Statistics, metrics of terminals and Sat Networks are retrieved using the Time Series Database API.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.2.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This driver uses three HTTP connections and requires the following input during element creation.

#### HTTP Connection 1, 2 & 3

These are used to communicate with the Newtec Dialog Restful Standard API.

- **IP address/host**: The IP of the Newtec Central NMS.
- **IP port:** *80* (Default Connection 1) & *8086* (Default Connection 2 & 3)
- **Device address**: *BypassProxy*

### Initialization

On the **General** page, specify the **credentials** for user authentication of the REST API in order to collect data from the Dialog platform.

On the **TSDB Polling** page, add the TSDBs that need to be polled to the **Database Configuration** table.

In addition, two toggle buttons need to be enabled to poll both the dialog REST and TSDB API.

### Redundancy

There is no redundancy defined.

## How to use

This driver was designed to follow the other collectors and to work with the DataMiner EPM Solution.

Before data can be displayed by the driver, the credentials and TSDBs must be configured, as detailed in the "Initialization" section above.
