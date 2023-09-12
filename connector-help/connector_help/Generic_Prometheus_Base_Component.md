---
uid: Connector_help_Generic_Prometheus_Base_Component
---

# Generic Prometheus Base Component

Prometheus is an open-source systems monitoring and alerting toolkit. It scrapes metrics from instrumented jobs, either directly or via an intermediary push gateway for short-lived jobs. It stores all scraped samples locally and runs rules over this data to either aggregate and record new time series from existing data, or generate alerts.

The **Generic Prometheus Collector** driver executes queries via HTTP to retrieve the data. This data will then be forwarded to an element created with a driver derived from this **Generic Prometheus Base Component** driver, which will display the data. This driver is **NOT** intended to be used as is. It should be considered as a starting point to which parameters should still be added, which will then be automatically filled in.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Generic Prometheus Collector](xref:Connector_help_Generic_Prometheus_Collector) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No additional configuration of parameters is needed in a newly created element.

## How to Use

Data is pushed to this driver by an element using the **Generic Prometheus Collector** driver, which means that no data traffic will be seen in the **Stream Viewer**.

The parameter name determines in which parameter the data will be placed. The idea of this driver is that new drivers are created based on it, and these kinds of destination data parameters are added to them. For more information about the format, refer to the Notes section below.

A number of parameters in the driver are used for the correct functioning of the driver and must not be removed. It is clearly indicated in the comments that these should not be removed or modified. There are also some example parameters present to demonstrate the structure; these can be removed when a new driver is created.

### Configuration

The parameters on the **Configuration** page are needed for the driver to function correctly. Do not remove these.

If the destination parameter is a table column, these rows will be added automatically, but they will not be removed by default. With the **Remove Old Rows After** parameter, you can configure after how much time a row will be removed if no new data has arrived for this row.

The **Missing Metrics** table contains data for which the metric label cannot be mapped to a parameter, meaning that the value cannot be filled in in a parameter. The **Name** of the expected parameter will be filled in, and you can enable alarm monitoring on the **Status** column in order to get an alarm when this happens. Rows from this table will not be removed automatically; to remove these, click the **Delete** button.

The **Executed Parameter Sets** will by default be refreshed every 5 minutes (depending on the Timer Base setting). This displays how many parameter sets were executed during that period. You can enable alarm monitoring on this parameter to get an alarm in case no new values entered with data from the **Generic Prometheus Collector** element.

## Notes

Parameters that should contain the data need to be added to the driver manually.

The driver has been created in such way that no extra QAction logic or modification is needed; only adding parameters with the correct name should suffice to have data filled in.

### Single Numeric Parameters

These parameters are directly targeted by the **Destination Parameter Name** configured in the **Generic Prometheus Collector** element. As values can contain invalid items, such as *NaN*, always add one exception value to the parameter. The value and ID of the exception definition do not matter; as soon as an incoming value is not a number, the exception will be set as the value. Make sure that the chosen parameter name does not match a possible label name, as the value will get overwritten by the label value in that case. You can map label names with a numeric parameter in case the label contains numbers, which allows alarm monitoring and trending.

### Single String Parameters

These parameters are normally mapped based on the parameter name and metric label. If the metric label matches the parameter name, the label value will be filled in in this parameter.

### Table Column Parameters

The query result will be filled in based on the **Destination Parameter Name** configured in the **Generic Prometheus Collector** element. Just like for the single numeric parameters, you should always configure an exception value. Label values that were present in the query result will be mapped with the column parameter name that matches the name of the table parameter, followed by an underscore ( \_ ) and the name of the label.

The primary key will be constructed by the mapped label columns. The label values will be appended, with an underscore ( \_ ) as separator. The order of the label values will be determined based on the ascending column parameter ID. In case the parameter name of a primary key column is also linked to a label, the label value will be added first, optionally followed by an underscore and the label values of other mapped label columns, if such columns are present. You can also exclude a mapped label column from being part of the primary key, by adding *\_ExcludedFromPK* as a suffix to the column parameter name. Note that adding the excluded suffix will have no effect when this is applied to the primary key column that is mapped to a label value. There should always be at least one label mapped to a column, as a primary key must have a value.
