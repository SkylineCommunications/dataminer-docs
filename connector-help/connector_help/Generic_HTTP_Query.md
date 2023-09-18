---
uid: Connector_help_Generic_HTTP_Query
---

# Generic HTTP Query

The Generic HTTP Query connector can be used to **monitor HTTP and HTTPS addresses** over a network in order to check the response and evaluate the reply time.

This connector uses custom HTTP/HTTPS requests in order to retrieve a reply from a remote server and display its status code, response data, and response times, such as the maximum reply time, minimum reply time, and average reply time.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |
| 2.0.0.x   | Version remake.  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

### General

The General page displays a table, **HTTP Queries**, where you can **define multiple HTTP queries** and monitor responsiveness by **measuring max, min and average reply times** as well as the **status code** and **response content** of the remote server response. Each line represents an HTTP call that will be executed every time the interval value is checked.

Note: **if the Interval is Disabled**, the query is **not automatically triggered** but can only be executed using the **Execute** button.

You can add data to the table **HTTP Queries** by:

- Adding data row by row via the right-click menu of the table:

  1. Right-click the **HTTP Queries** table, and select the VERB, e.g. Add GET, or add a new header to the query.
  1. Fill in the **URI**, **Interval**, and **Timeout** values. The URI has to have the following structure: *http://\<address\>*.
  1. After you have successfully added a row, you can define a **User Name**, a **Password**, and a **Request Body**. You can also edit the **URI**, **Verb**, **Interval**, and **Timeout**.

- Importing from a CSV file. To do so:

  1. Set the **Import Path** where the CSV files are located. By default, the connector sets the path to *C:\Skyline DataMiner\Documents\Generic HTTP Query\\* at startup. You can define a new path by specifying a different valid path.
  1. If the import path is valid and the directory contains CSV files, you can select them in the **Import File** drop-down box. If necessary, use the **Refresh File List** button to refresh the drop-down box based on the **Import Path File**.
  1. Click the **Import Data From CSV** button to import the data.

#### CSV file structure

To import a CSV file, the file **must have the same headers** as displayed in the **HTTP Queries Table**, and each row must have the same number of columns with meaningful data.
All imported data is validated. If **no** **index** is found in a row or there is an **invalid or non-existing URI**, that specific row will **not be added**.

CSV file example:

```
"Index (HTTP Queries)";"URI (HTTP Queries)";"User Name (HTTP Queries)";"Password (HTTP Queries)";"Request Body (HTTP Queries)";"Verb (HTTP Queries)";"Status Code (HTTP Queries)";"Response (HTTP Queries)";"Max Response Time (HTTP Queries)";"Min Response Time (HTTP Queries)";"Avg Response Time (HTTP Queries)";"Interval (HTTP Queries)";"Timeout (HTTP Queries)";"Display Key \[IDX\] (HTTP Queries)";"Headers (HTTP Queries)";"Foreign Key (HTTP Queries)";"Proxy (HTTP Queries)"

"1";"http://www.skyline.be";"-1";"-1";"-1";"0";"-1";"-1";"0";"0";"0";"5";"30";"1- https://www.skyline.be - GET";"\[\]";"0";"-1"
```

### Headers

The Headers page displays a tree control with the queries in the HTTP Queries table filtered by VERB.

You can drill down in the tree control to view the list of headers associated with each query. At that level, you can remove header entries by clicking the remove button for the specified header.

### Proxy

From version 2.0.0.4 onwards, a Proxy column is available, which can be used to define a proxy configuration for each query if necessary.

The value in this Proxy column must have the following format: "*http://proxyaddres:proxyport".*

If no proxy has to be configured, fill in *"-1" (N/A)* in this column instead*.*
