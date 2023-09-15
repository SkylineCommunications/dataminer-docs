---
uid: Connector_help_Splunk_Enterprise
---

# Splunk Enterprise

The Splunk Enterprise connector is an HTTP connector that implements the Splunk API. The REST API provides methods for accessing every feature available in the Splunk platform.

Splunk is an application that captures, indexes, and correlates high volumes of machine-generated data in a searchable repository from which it can generate graphs, reports, alerts, dashboards, and visualizations.

## About

The Splunk Enterprise connector focuses on monitoring jobs created based on saved searches configured in the Splunk platform.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.6.0 (API)                 |

## Installation and configuration

### Creation

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

## Usage

### Saved Search

In order to retrieve job results configured in the Splunk platform for saved searches, these saved searches need to be configured manually in the connector. For this purpose, the **Saved Searches Table** provides the option to manually add saved searches. This can be done by right-clicking in the table and selecting **Add new**).

The following information needs to be specified when a new saved search is added:

- **Saved Search**: The name of the saved search as defined in the Splunk platform (case sensitive).

- **Result Type**: Since the results of saved searches don't have a specific format, the connector supports the following 5 format types:

- **Type I**: One field retrieved (Type Integer)
  - **Type II**: Two fields retrieved (Type String, Type Integer)
  - **Type III**: Two fields retrieved (Type Integer, Type Integer)
  - **Type IV**: Three fields retrieved (Type String, Type Integer, Type Integer)
  - **Type V**: Three fields retrieved (Type Integer, Type Integer, Type Integer)

> Depending on the result type, the **Job Results Table** will be populated accordingly. An example for *Type I* and *Type II* can be found in the **Job Results** section below.

Finally, a **Request Searches** button is also available, which allows you to poll the saved searches defined in the **Saved Searches Table** manually.

### Job Results

The **Job Results Table** will display the job results depending on the saved searches configured in the **Saved Searches Table**. For each saved search, multiple job results can be added to the Job Results Table. The number of rows depends on the **host** field found in the job result. In case a saved search contains more than one Job ID (that corresponds to the same *host* field but with different timestamps), the connector will process the latest job result in the Job Results Table.

The following is an example of a job result (Type I) with only one field:

*\<?xml version='1.0' encoding='UTF-8'?\>* *\<results preview='0'\>* *\<meta\>* *\<fieldOrder\>* *\<field\>count(total_errors)\</field\>* *\</fieldOrder\>* *\</meta\>* *\<result offset='0'\>* *\<field k='count(total_errors)'\>* *\<value\>* *\<text\>240\</text\>* *\</value\>* *\</field\>* *\</result\>* *\</results\>*

The job result will be displayed in the **Job Results Table** as follows:

| **Display Key \[IDX\]** | **Saved Search ID**      | **Job ID Result**               | **Type** | **Field Integer I** | **Field Integer I Value** |
|-------------------------|--------------------------|---------------------------------|----------|---------------------|---------------------------|
| 1                       | INT_SAMS_TOTAL%20_ERRORS | scheduler\_\_admin_c2t5LWFwc... | Type I   | count(total_errors) | 240                       |

The folllowing is an example of a job result (Type II) with more than one field:

*\<?xl version='1.0' encoding='UTF-8'?\>* *\<results preview='0'\>* *\<meta\>* *\<fieldOrder\>* *\<field groupby_rank="0"\>host\</field\>* *\<field\>count\</field\>* *\</fieldOrder\>* *\</meta\>* *\<result offset='0'\>* *\<field k='host'\>* *\<value\>\<text\>chiolsvolsp01\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>32\</text\>\</value\>* *\</field\>* *\</result\>* *\<result offset='1'\>* *\<field k='host'\>* *\<value\>\<text\>chiolsvolsp02\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>30\</text\>\</value\>* *\</field\>* *\</result\>* *\<result offset='2'\>* *\<field k='host'\>* *\<value\>\<text\>chiolsvolsp03\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>19\</text\>\</value\>* *\</field\>* *\</result\>* *\<result offset='3'\>* *\<field k='host'\>* *\<value\>\<text\>chiolsvolsp04\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>22\</text\>\</value\>* *\</field\>* *\</result\>* *\<result offset='4'\>* *\<field k='host'\>* *\<value\>\<text\>chiolsvolsp05\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>23\</text\>\</value\>* *\</field\>* *\</result\>* *\<result offset='5'\>* *\<field k='host'\>* *\<value\>\<text\>chiolsvolsp06\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>29\</text\>\</value\>* *\</field\>* *\</result\>* *\<result offset='6'\>* *\<field k='host'\>* *\<value\>\<text\>upapp6w0\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>11\</text\>\</value\>* *\</field\>* *\</result\>* *\<result offset='7'\>* *\<field k='host'\>* *\<value\>\<text\>upapp6x0\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>8\</text\>\</value\>* *\</field\>* *\</result\>* *\<result offset='8'\>* *\<field k='host'\>* *\<value\>\<text\>upapp6y0\</text\>\</value\>* *\</field\>* *\<field k='count'\>* *\<value\>\<text\>8\</text\>\</value\>* *\</field\>* *\</result\>* *\</results\>*

The job result will be displayed in the **Job Results Table** as follows:

| **Display Key \[IDX\]**     | **Saved Search ID** | **Job ID**                    | **Type** | **Field String 1** | **Field String 1 Value** | **Field Integer 1** | **Field Integer 1 Value** |
|-----------------------------|---------------------|-------------------------------|----------|--------------------|--------------------------|---------------------|---------------------------|
| 1/host/ chiolsvolsp01/count | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | chiolsvolsp01            | count               | 32                        |
| 2/host/ chiolsvolsp02/count | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | chiolsvolsp02            | count               | 30                        |
| 3/host/ chiolsvolsp03/count | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | chiolsvolsp03            | count               | 19                        |
| 4/host/ chiolsvolsp04/count | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | chiolsvolsp04            | count               | 22                        |
| 5/host/ chiolsvolsp05/count | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | chiolsvolsp05            | count               | 23                        |
| 6/host/ chiolsvolsp06/count | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | chiolsvolsp06            | count               | 29                        |
| 7/host/ upapp6w0/count      | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | upapp6w0                 | count               | 11                        |
| 8/host/ upapp6x0/count      | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | upapp6x0                 | count               | 8                         |
| 9/host/ upapp6y0/count      | sams_host_callback  | scheduler\_\_admin_c2t5LWFwcA | Type II  | host               | upapp6y0                 | count               | 8                         |

In order to limit the number of rows, the following two parameters are available:

- **Maximum Number of Job Results**: Defines the maximum number of rows allowed in the Job Results Table.
- **Automatic Removal of Job Results**: Once enabled, the connector will take the maximum number of job results into account and limit the number of rows in the Job Results Table.

In addition, two extra parameters are available on this page to manually remove rows from the Job Results table:

- The **Remove All** button will remove all the rows from the Job Results Table.
- Each row in the Job Results Table contains a column with a **Remove** button. Clicking this button will remove the corresponding row.

Finally, an extra parameter is available at the bottom of this page, which will dynamically define the format of the display key of the Job Results Table. This **Job Result Table Naming Suffix** parameter allows you to concatenate the column values of the **Job Results Table** using any separator. This parameter implements the same format processing as the **C# String Format** method. In order to avoid a duplicate display key, the connector will always include the index of the table as part of the display key.

### Dashboards

This page contains the **Dashboard URL** parameter.

### Configuration

This page contains the following parameters, which will be used by the connector to authenticate against the Splunk platform:

- **Username**: The username for the Splunk platform
- **Password**: The password for the specified username.
- **User Node**: The user node required for HTTP requests
- **App Node**: The app node required for HTTP requests

The Splunk Enterprise connector renews the authentication session key every 10 minutes. After a session key renewal, the connector will poll the saved searches configured in the Saved Search Table.

This page also contains a **Login** button, which can be used to force an authentication request.
