---
uid: Connector_help_Generic_Prometheus_Collector
---

# Generic Prometheus Collector

Prometheus is an open-source systems monitoring and alerting toolkit. It scrapes metrics from instrumented jobs, either directly or via an intermediary push gateway for short-lived jobs. It stores all scraped samples locally and runs rules over this data to either aggregate and record new time series from existing data, or generate alerts.

This **Generic Prometheus Collector** connector executes queries via HTTP to retrieve the data. This data will then be forwarded to an element using a connector derived from the **Generic Prometheus Base Component** connector.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API v1                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**             | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Generic Prometheus Base Component | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. [*http://demo.robustperception.io*](http://demo.robustperception.io/).
- **IP port**: The IP port of the destination, e.g. 9090.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

Queries have to be entered into the **Query Table**. You can do so either by clicking on the **Add Row** button and filling in the appropriate columns, or by importing a CSV file with the settings by clicking on the **Configurations** page button and using those parameters. For more information, refer to the "How to Use" section below.

## How to Use

HTTP GET messages are used for the multi-threaded execution of the queries. On the **Statistics** page, you can see how many queries, element calls and remote sets were executed in the last 5 minutes.

### Manual Configuration

To manually add a row to the **Query Table**, click the **Add Row** button and fill in the necessary fields:

- Fill in a unique name in the **Name \[IDX\]** column. This is not needed for the correct functioning of the connector but will be handy in case the other columns have trending or alarm monitoring enabled. It will allow users to more easily recognize what is going wrong.

- Insert the query in the **Query** column. The value is the part that comes after "*query="* in the URL.

- **Destination Element** should contain the name of the target element to which the query result should be forwarded. This is an element that is running a connector derived from the **Generic Prometheus Base Component** connector. The value can be hard-coded, referring to the name of the element, or can contain placeholders that can be dynamically filled in with the content of the labels. Labels can be referred to using the *\[label:\<labelName\>\]* placeholder and can be combined with hard-coded text, e.g. "*prefix \[label:labelName1\] second \[label:labelName2\] suffix*".
  RegexReplace can also be executed on the label value. Use *\[RegexReplace:x,y,z\]* with x being the regular expression, y being the input, and z containing the string that will replace each of the matches. RegexReplace can contain *\[label:\]* placeholders and can contain nested RegexReplace definitions. Note that a label placeholder cannot contain a RegexReplace. For example, for a label with content "*test (info) data that will be removed*", using "*\[RegexReplace:^(?\<start\>\[^\\\\\]+\\\[^()\]+\\)\[^()\]+\$,\[label:labelName\],\${start}\]\_some suffix*" will result in "*test (info)\_some suffix*".
  You can prefix RegexReplace with *\[Sep:,\<new_separator\>\]* to replace the comma separator with a different separator in case the label value were to contain spaces, e.g. "*\[Sep:,\]\[RegexReplace:xyz\]*".

- **Destination Parameter Name** should contain the parameter name of the destination element where the value of the query will be displayed.

- With **Poll Speed**, you can configure how often this query should be executed. Possible values are:

- *Disabled*: Prevents the query from being executed.
  - *Fast*: Executes the query every thirty seconds.
  - *Slow*: Executes the query once every five minutes.

The following information will also be displayed in each row:

- **Last Successful Poll** displays the last time when it was possible to successfully execute the query.
- **Last Poll Attempt** displays when the last attempt to execute the query occurred.
- **Communication Status** indicates if any errors were encountered when the query was executed or if everything was OK.
- **Last Query Duration Time** displays how long it took to execute the last query.
- **Failed Polling** shows the number of cycles that have failed since the last successful query execution or since polling was enabled. You can enable alarm monitoring on this parameter in order to get notified when queries are failing.

To remove a query row, click the **Delete** button in the appropriate row.

### File Configuration

It is also possible to populate the **Query Table** by means of a CSV file import. To do so:

1. Click the **Configuration** page button. This will open a pop-up page.

1. On the pop-up page, check the specified **Folder Location** where the CSV files are located and adjust it if necessary. By default, this is set to the documents folder of the connector.

1. Click the **Refresh** button to refresh the list of CSV files with the files that are currently present in the specified Folder Location.

1. Select the file to import in the **Import File to Query Table** box and click **Execute** to populate the Query Table.

   Note that existing rows in the **Query Table** will be removed when a file is imported.

You can also export the current content of the **Query Table** to a CSV file by clicking the **Export Query Table to File** button. The generated file will have the name of the element suffixed with the current datetime, and will be located in the configured **Folder Location**. Note that this folder needs to be present in case it is not the default location.

Both the import and export functionality are also available via the context menu of the **Query Table**.

For information on the structure of the CSV file, refer to the Notes section below. Good practice could be to first export the **Query Table** to a CSV file, adapt that generated file and then import it back.

## Notes

The structure of the CSV file is described below.

The first line is a header line, and the order of columns should not be changed:

*"Name \[IDX\]";"Query";"Destination Element";"Destination Parameter Name";"Poll Speed"*

This is followed by a new line containing the values for every query line. The values must be placed between double quotation marks ( " ); if a value itself contains a double quotation mark, that quotation mark must be replaced by two double quotation marks.
