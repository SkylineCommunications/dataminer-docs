---
uid: Connector_help_Telenor_Prometheus_ADB_Back-End
---

# Telenor Prometheus ADB Back-End

Prometheus is an open-source system monitoring and alerting toolkit. It scrapes metrics from instrumented jobs, either directly or via an intermediary push gateway for short-lived jobs. It stores all scraped samples locally and runs rules over this data to either aggregate and record new time series from existing data or generate alerts.

The **Generic Prometheus Collector** connector executes queries via HTTP to retrieve the data. This data will then be forwarded to **Telenor Prometheus ADB Back-End** connector to display the data.

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

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

First, you need to create an element using the **Generic Prometheus Collector** connector, which will be responsible for communication with your data source. This means that your **Telenor Prometheus ADB Back-End** element will get its data via another element, so no data traffic will be visible in **Stream Viewer**.

After both elements have been created, configure the **Telenor Prometheus ADB Back-End** element. To do so, on the **Configuration** page, select the **Prometheus Collector Element Name** and the desired **Namespace Filter** that should be used to perform the queries. You can then push the queries to be executed to the collector or remove them by clicking the buttons available on the Configuration page.

The **Prometheus Collector Query Table** in the selected **Generic Prometheus Collector** element will be populated by the respective queries as soon as the button **"Push"** is pressed. If the destination parameter is a table column, these rows will be added automatically, but they will not be removed by default. With the **Remove Old Rows After** parameter, you can configure after how much time a row will be removed if it has not been updated.

The **Missing Metrics** table contains received data for which the metric label cannot be mapped to a parameter, meaning that the value cannot be filled in in a parameter. In the **Name** column, you will find the name of the expected parameter. The **Status** column can be monitored to generate an alarm when this happens. Rows from this table will not be removed automatically. You can remove them by clicking the **Delete** button.

The **Executed Parameter Sets** parameter is by default refreshed every 5 minutes (depending on the Timer Base setting). This parameter displays how many parameter sets were executed during that period. It can be monitored to generate an alarm in case no new values with data from the **Generic Prometheus Collector** element were received.

## Notes

The parameters that should display the data need to be added manually to the connector. The connector has been created in such a way that no extra QAction logic or modification is needed. It is sufficient to add parameters with the correct name to have data filled in.

If you want more information about how this connector works, please check the notes for the [Generic Prometheus Base Component](xref:Connector_help_Generic_Prometheus_Base_Component).
