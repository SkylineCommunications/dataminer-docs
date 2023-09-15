---
uid: Connector_help_Ziggo_Modem_Outage_Check
---

# Ziggo Modem Outage Check

The main purpose of the **Ziggo Modem Outage Check** connector is to revalidate the outage state (outage check) of CPEs in **Ziggo IPVPN Collector** elements.

## About

This connector is part of a larger setup and works together with the **Ziggo IPVPN Collector** and **Generic Ping** drivers.

The **modem outage check** consists of the following steps:

1. The **collectors** evaluate on **which CPEs** an outage check should be performed. This is triggered when a CPE is no longer available. The **hostname** and **MAC** address of the CPE are sent to the **Modem Outage Check** element.
2. The **Modem Outage Check** element identifies the **IP** address of the modem, given the **MAC** address of the modem, using mapping files, and sends the request to the **Generic Ping** elements via HTTP.
3. The **Generic Ping** elements perform the **pings**.
4. The **Modem Outage Check** element **polls the results** from the Generic Ping elements and removes the ping request if polling was successful.
5. The **results** are processed and sent to the **collectors**.

### Version Info

| **Range** | **Key Features**             | **Based on** | **System Impact** |
|-----------|------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version \[SLC Main\] | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, where the **Generic Ping** elements are deployed
- **IP port**: The IP port of the destination (default: *80*).

### Initialization

When the **Modem Outage Check** element is created, the following settings need to be configured:

- **General** page \> **Ping Elements Config** table:

- DMA ID
  - Element ID

- **General** page \> **Connection** subpage:

- Username
  - Password

### Redundancy

There is no redundancy defined.

## How to use

There is only one page, **General**, with multiple subpages: **IAM**, **Ping**, **Mapping** and **Connection**.

### General page

The General page contains a toggle button, **Modem Outage Check State**, and a table, **Ping Elements Config**.

The **Modem Outage Check State** button enables or disables the whole modem outage check mechanism. While it is *disabled*, all incoming messages are ignored.

The **Ping Elements Config** table contains two entries, referring to the ping elements (of different footprints) on the destination DMS. In this table, you can configure the **DMA** and **Element ID** of the ping elements, enable or disable their **State** (whether the ping request will be sent to the specific element) and adjust the ping settings of the external elements (without having to connect to the other DMS to do so). The following ping settings are available: **Ping Interval**, **Pings Per Cycle**, **Buffer Size**, **Ping Timeout Time** and **TTL**.

### IAM subpage

This subpage contains read-only information regarding the connection to the IAM database: **Element Name**, **Server**, **Database**, **User Name** and **Password**. This information is filled in automatically the first time it is required by the element. The information is obtained from the **IAM DB** element (using the **Skyline IAM DB** driver), which needs to be in the same DMS as the **Ziggo Modem Outage Check** element.

### Ping subpage

This subpage contains the configuration for the outage check mechanism:

- **Poll Frequency**: The frequency at which the **Modem Outage Check** element will poll the ping results on both ping elements.
- **Ping Success Threshold**: The successful pings percentage threshold that determines whether a modem is considered to be up or suffering an outage. This threshold is compared to the **Avg. Success** of a ping request.
- **Overload Protection Threshold**: The modem outage check will only be performed if the number of modems to be checked is not higher than this threshold, within a 30-second time window. In case this threshold is exceeded, the modems are considered to be suffering from an outage, and the outage check is not performed.

### Mapping subpage

On this page, you can configure and monitor the import of the mapping files. The mapping files contain the relation between a **MAC** address of a modem and the **IP** of the modem that should be pinged.

The page displays the following information:

- **Mapping Folder**: The folder where the mapping files need to be placed for the element to process them.

- NOTE: The mapping files must be CSV files without a header. The first column must contain the list of **MAC addresses** and the second column must contain the respective list of **IP addresses**.

- **Last Import**: The time of the last import attempt.

- **Imported Entries**: The total number of distinct **MAC addresses** that are currently imported.

- **Import Status**: Displays the current import status. Possible values: *Ready*, *Importing*, *Error* and *Clearing*.

- **Import Error Message**: In case Import Status is *Error*, this parameter displays the reason why the map import failed.

- **Mapping Files** Info table: Displays information on all the CSV files in the **Mapping Folder:**

- **Filename**
  - **File** **Size**
  - **Valid Entries**: The number of valid entries. An entry is considered valid if it has a **MAC address** that is currently known by the IAM database. Duplicate entries are also taken into account for statistics, but only the first one will be imported
  - **Process Entries**: The total number of processed entries.
  - **Import State**: Whether the file was successfully read. Possible values: *Not Processed*, *OK* and *Fail*

There are also two buttons you can use to manually perform the following actions:

- **Check for Updates**: Executes a manual import of the mapping files from the folder.
- **Clear Mapping Info**: Deletes all mapping data. All imported entries will be deleted and the **Mapping Files Info** table will be cleared.

### Connection subpage

This subpage contains the configuration for the connection to the external DMS/DMA:

- **Polling IP**: The IP address or the host name to connect to the DataMiner System where the ping elements are located. This parameter is defined upon element creation and can only be changed by editing the element.
- **Username**: The username that will be used to connect to the DataMiner System where the ping elements are located. In case of a domain user, "DomainName\Username" can be used.
- **Password**: The password that will be used to connect to the DataMiner system where the ping elements are located.
- **Connection Status**: Displays if the last attempt to connect to the DMS/DMA was successful. Possible values: *OK* and *Fail*.
- **Connection Error Message**: In case Connection Status is *Fail*, this parameter displays the response received when the connection attempts failed.
- **Startup Configs Status**: Displays if the startup configuration parameters were correctly set on the ping elements. Possible values: *OK* and *Fail*.
- **Startup Configuration Error Message**: Displays the response received if the startup configuration could not be set up.

There are also two buttons you can use to manually trigger the following actions:

- **New Connection**: Establishes a new connection to the external DMS/DMA.
- **Reset Startup Configs**: Sets the default startup configuration on the ping elements.
