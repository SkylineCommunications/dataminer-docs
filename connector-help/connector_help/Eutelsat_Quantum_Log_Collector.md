---
uid: Connector_help_Eutelsat_Quantum_Log_Collector
---

# Eutelsat Quantum Log Collector

The **Eutelsat Quantum Log Collector** retrieves a log file from the Quantum Calibration Box using SSH and displays the log entries in a table.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.1.10                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses an SSH connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. By default, port 22 is used.

### Initialization

To start the polling, the **Username** and **Password** parameters must be filled in on the **General** page.

## How to Use

The **General** page displays some configuration parameters:

- **Username**: The SSH username used to log into the box.
- **Password**: The SSH password used to log into the box.
- **File Path**: The absolute path to the log file. This is by default set to "*~/quantum/quantum-log.txt".*

The **Log Table** displays the log entries. You can delete a log entry by clicking the **Delete** button or by using the context menu.

When the **Reload Log File** button is pressed, the **Log Table** is cleared and then updated with the current content of the log file.

The **Configuration** page displays parameters that allow you to filter the logs based on the **Filter** or the **Category**.

The **Table Cleaning** parameters control how many rows can be displayed in the table or when rows are removed based on the date of the log.
