---
uid: Connector_help_ETL_Systems_NGM-11
---

# ETL Systems NGM-11

This connector is intended for use with ETL Systems NGM matrix devices. The ETL Systems NGM devices have different matrix sizes. This connector will adjust its matrix size to that of the relevant module. Alarms and traps are polled via SNMP, while serial communication is used for the configuration, status and labels. Several functionalities have been added to allow bulk sets on the device as well as the import and export of certain settings.

## About

### Version Info

| **Range**            | **Key Features**         | **Based on** | **System Impact** |
|----------------------|--------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Matrix device management | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### Serial Serial Connection - 1 Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600* (default: *19200*).
  - **Databits**: Databits specified in the manual of the device, e.g. *7* (default: *8*).
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1* (default: *1*).
  - **Parity**: Parity specified in the manual of the device, e.g. *No* (default: *no*).
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No* (default: *no*).

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *4000*).
  - **Bus address**: The bus address of the device. (default: *65*) (range: *32* - *122*). Use the decimal ASCII value of the **matrix address** configured in the device, e.g. A = *65*, P = *80*.

### Initialization

Please review the connection settings for elements initialized in version 1.0.0.2 or below. The SNMP connection has become the primary connection to enable sets. This can cause incorrect connection settings when you upgrade an existing element.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page is the default page of this connector. It contains the SNMP parameters of the device. At the top are the alarm statuses, which have traps linked. Below this, you can find the trap settings.

The **Matrix** page displays all the crosspoints in the device. Initially, all the groups will be collapsed. Click once to open a group and see the input or output details.

Note that because of device restrictions, labels can only be 10 characters in length.

There are two page buttons for more advanced matrix manipulations: **Import-Export Matrix** and **Bulk Edit Matrix**. You can find more information on these below.

### Importing or exporting the matrix

Via the **Import-Export Matrix** page button, you can export or import the settings of the matrix. Any change to the path or filename will be validated, and a response will be shown in the status field. When a valid file path (folder) has been specified, the CSV files will be listed in the drop-down box of the file name. File names are automatically appended with .csv if this extension cannot be found at the end of the name.

- **Export Options**: Choose which parameters are exported.

  - *Normal*: I/O index, label, locked status
  - *With Crosspoints*: I/O index, label, locked status, connected crosspoint(s)

- **Loading Labels Indicator**: Shows how labels are synchronized when a file with different labels than the current matrix is imported.

  - *Polling labels from device*: Labels are periodically polled from the device.
  - *Importing labels from file*: Label polling is disabled, the matrix of the element is updated and sent to the device.
  - *Sending labels to device*: Label polling is disabled, the element is updated, but labels are still sent to the device.

The following export format is used (square brackets indicate the optional column): **Index;Label;Locked\[;Connections\]**
For example: *Input 9;Label In 9;False;\[001,003,112\]*

Note: Although both the *Normal* and *With Crosspoint* export types can be imported, no crosspoint settings are imported in case you import the latter.

### Editing the matrix in bulk

Via the **Bulk Edit Matrix** page button, you can perform two different types of bulk edits on the matrix:

- **Bulk Update**: Select an input and an output (**Input to Connect** and **Output to Connect With**), then use the button **Add Crosspoint** to put the crosspoint in the table. When you have entered the desired crosspoint changes, use **Execute Buffer** to perform the changes.

- **Change Crosspoints from one Input to another Input**: You can switch all outputs from one input to another in smaller sets with time delays, using the following settings:

  - **Maximum changes per Command**: The number of crosspoints that can be changed per batch.

  - **Commands Delay**: The time delay in seconds between each batch of changes.

  - **From Input** and **To Input**: the inputs to switch.

  - **Changes Crosspoints**: Executes the change.
