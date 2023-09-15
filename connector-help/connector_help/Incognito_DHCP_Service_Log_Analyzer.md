---
uid: Connector_help_Incognito_DHCP_Service_Log_Analyzer
---

# Incognito DHCP Service Log Analyzer

This connector establishes a connection with a **Linux server**. It analyzes **log files** on this server and copies them to the local machine. When the files have been successfully copied, the connector will extract **IP and MAC addresses for cable modems** and place this information in a table.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                    | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- SSH connection. - Copies files from server to local machine. - Analyzes and extracts information from log files. | \-           | \-                |

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

#### Serial Main Connection

This connector uses a serial connection (SSH) and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (22 by default).

### Initialization

Before you start running an element with this connector, you need to execute an SCP client on the local machine to make sure you can receive information through port 22.

### Redundancy

There is no redundancy defined.

## How to use

Below you can find general information about the pages of this connector.

### General

This page contains the following parameters:

- **Last poll time:** The last time when the log file was copied from the server to the local machine.
- **Number of Cable Modems:** The number of cable modems extracted from the log file last time.
- **Server Source:** Indicates if the information comes from the main server of from the failover server (not available yet).

### Config

This page shows the **Communication Frequency** parameter, which indicates the frequency fixed to establish the communication and copy the log files from the remote server.

It also provides access to the following subpages via page buttons.

- **SSH Connection:** Contains the required credentials to establish the SSH connection to the remote server, and displays the status of that connection.
- **Main Server Information:** Contains the IP of the remote server and the path where the log files to copy are located.
- **SCP Connection:** Contains the IP of the machine where log files are saved, the SCP credentials required to save the files and the destination path.

### Address Table

This page contains the cable modems addresses table.
