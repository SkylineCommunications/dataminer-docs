---
uid: Connector_help_Generic_Prometheus_MySQL
---

# Generic Prometheus MySQL

Prometheus is an open-source systems monitoring and alerting toolkit. It scrapes metrics from instrumented jobs, either directly or via an intermediary push gateway for short-lived jobs. It stores all scraped samples locally and runs rules over this data to either aggregate and record new time series from existing data, or generate alerts.

The **Generic Prometheus Collector** driver executes queries via HTTP to retrieve the data. This data will then be forwarded to an element created with a driver derived from this **Generic Prometheus MySQL** driver, where the data regarding the MySQL system will be displayed.

MySQL is a freely available open-source Relational Database Management System (RDBMS) that uses Structured Query Language (SQL).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Generic Prometheus Collector](xref:Connector_help_Generic_Prometheus_Collector) | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

This driver gets its data via an element using the **Generic Prometheus Collector** driver, which means that no data traffic will be seen in the **Stream Viewer**.

The parameter name determines where specific data is displayed. This driver is meant to be used as a basis for the creation of new drivers where these kinds of destination data parameters are added. For more information about the format, refer to the Notes section below.

There are a number of parameters in the driver that are used for the correct functioning of the driver and must not be removed. This is clearly indicated in the comments. There are also several example parameters in the driver that are intended to demonstrate the structure. You can remove these when you create a new driver.

### Configuration

The parameters on the **Configuration** page are needed for the correct functioning of the driver and must not be removed.

The **Prometheus Collector Element Name** indicates the element selected to populate this driver.

There is also an **Instance Name Filter** that defines the instance that the queries are targeting:

- If *All Instances* is selected, all queries will target all available instances.
- If *No Instance* is selected, the existing queries will be automatically removed.

The **Prometheus Collector Query Table** inthe selected **Generic Prometheus Collector** element will be populated by the respective queries as soon as the **Instance Name Filter** is changed.

If the destination parameter is a table column, then these rows will be added automatically, but they will not be removed by default. With the **Remove Old Rows After** parameter, you can configure after how much time a row will be removed if it did not get any new data.

The **Missing Metrics** table contains received data for which the metric label cannot be mapped to a parameter, meaning that the value cannot be filled in in a parameter. In the **Name** column, you will find the name of the expected parameter. The **Status** column can be monitored in order to generate an alarm when this happens. Rows from this table will not be removed automatically. You can remove them by clicking the **Delete** button.

The **Executed Parameter Sets** parameter is by default refreshed every 5 minutes (depending on the Timer Base setting). This parameter displays how many parameter sets were executed during that period. It can be monitored in order to generate an alarm in case no new values with data from the **Generic Prometheus Collector** element were received.

## Notes

The parameters that should display the data need to be manually added to the driver.

The driver has been created in such way that no extra QAction logic or modification is needed. It is sufficient to add parameters with the correct name in order to have data filled in.

### Single Numeric Parameters

These parameters are directly targeted by the **Destination Parameter Name** configured in the **Generic Prometheus Collector** element. As values can contain invalid items, such as *NaN*, always add one exception value to the parameter. The value and ID of the exception definition do not matter; as soon as an incoming value is not a number, the exception will be set as value. Please make sure that the chosen parameter name does not match a possible label name, as the value will get overwritten by the label value in that case. This functionality is intended to make it possible to map label names with a numeric parameter in case the label contains numbers, thus allowing monitoring and trending on it.

### Single String Parameters

These parameters are normally mapped based on the parameter name and metric label. If the metric label matches the parameter name, the label value will be filled in in this parameter.

### Table Column Parameters

The query result will be filled in as it was targeted by the **Destination Parameter Name** configured in the **Generic Prometheus Collector** element. Just like for single numeric parameters, you should always provide an exception value. Label values in the query result will be mapped with the column parameter name that matches with the name of the table parameter, followed by an underscore ( \_ ), then followed by the name of the label.

The primary key will be constructed by the mapped label columns. The label values will be appended, separated by an underscore ( \_ ). The order of the label values will be determined based on the ascending column parameter ID. In case the parameter name of a primary key column is also linked to a label, then the label value will be added first and optionally followed by an underscore and the label values of any other mapped label columns. It is also possible to exclude a mapped label column from being part of the primary key. You can do this by adding *\_ExcludedFromPK* as a suffix to the column parameter name. Note that adding the excluded suffix will have no effect if it is done with the primary key column that is mapped to a label value. There should always be at least one label mapped to a column, as a primary key must have a value.

### Add Custom Queries (Details for Developers)

When the **Instance Name Filter** is changed, the driver pushes the default queries with all the necessary data to allow the driver to be populated completely by the selected **Generic Prometheus Collector** element. However, if you want to add a new parameter to the driver, you will need to also add the necessary information to a collector element. If you fill in the *additionalUserDefinedQueries* list in QAction 5 (After Startup) with the targeted parameter ID, the poll speed, the query you wish to use and, if necessary, the additional labels, you will be able to push them to the **Generic Prometheus Collector Query Table.**

Examples can be found commented in the code in QAction 5.
