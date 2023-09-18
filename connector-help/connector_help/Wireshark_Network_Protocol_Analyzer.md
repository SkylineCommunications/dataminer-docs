---
uid: Connector_help_Wireshark_Network_Protocol_Analyzer
---

# Wireshark Network Protocol Analyzer

The **Wireshark Network Protocol Analyzer** is a connector that can be used to take captures on a remote Linux server.

## About

This connector uses a serial connection to allow the user to take captures on a Linux server. Tshark CLI commands are used to start the captures.

After the captures are taken, they are moved to a configurable remote destination. This way, the disk space usage on the remote Linux wireshark server is kept low.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Linux Server                |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the server.
  - **IP port**: The SSH IP port of the server. The default SSH port is *22*.

### Linux Server configuration

A Linux machine needs to be accessible from the DataMiner server hosting the Wireshark Network Protocol Analyzer element.

- The following modules need to be supported on that Linux server:

- SSH enabled
  - Wireshark (tshark CLI)
  - Samba (Configure a **shared folder** with the same name as the destination folder from the Configurations page - refer to the **Configurations section** below for more information.)

## Usage

### Capture Overview

In the **Active Captures** table, this page provides an overview of all the running captures and the captures that are waiting to be copied over.

You can start a capture by selecting **Start Capture** in the context menu of the table. A pop-up message will then ask for user input. **Description** and **Filter** are not mandatory fields, but **Interface** and **Duration** are mandatory. The duration can be between 15 seconds and 24 hours.

When the capture data is valid, an entry will be added to the table representing the capture. The **Process ID** will be taken from the remote server that represents this tshark process. The **Remaining Time** column will update every 5 seconds.

When a capture is complete and the copy delay time has passed, a move of the file will be initiated. After this move, the row will also be moved to the **Closed Captures** table. This table provides an overview of the request details, such as **Description**, **Interface**, **Filter**, **Duration** and **End Time**. Each entry is also marked with a **State** and a **File Location** (in case the capture and file move were successful).

The **State** can also be monitored and can have the following values:

- Copy Completed
- Capture Not Available
- File Copy Failed: Compression
- File Copy Failed: Move File
- File Copy Failed: Decompression
- File Copy Failed: General Failure
- Failed with Incorrect Input Data

Via the context menu of the **Closed Captures** table, you can **Remove Row(s)** or **Remove Row(s) and Capture(s)**. This will remove rows without or with the actual capture files, respectively.

The Closed Captures table will be automatically cleaned based on the cleanup configuration. (See Configurations section below.)

### Configurations

On this page, you need to configure the following settings:

- **Destination Path Capture Server**: The path where the tshark process will write its file. This path is also used to do the remote copy of the captures. Make sure this path is locally available on the server and also make sure the Samba shared folder has this same name.
  For example, when this path is set to "*/WiresharkCaptures*", that means the local folder "/WiresharkCaptures/" needs to be available, and the shared folder (configured in Samba) should also have this path name: "*\\serverip\WiresharkCaptures\\*".
- **Time to Wait Before Copying Files From Server**: To make sure the capture process is fully closed, there will be a delay of at least 15 seconds and at most 10 minutes.
- **Amount of Closed Captures to Keep** and **Auto Delete Removed Captures** will make sure that the **Closed Captures** table will not grow endlessly. Older captures can be removed with this as well.
- **Remote Central Server Path**: The path where the captures will be moved when they are complete and the wait delay has passed. Note that in the background, the capture will be compressed and decompressed to speed up the file move over the network.
- **Remote Central Server User Name**, **Domain** and **Password**: When authentication is required to access the remote shared folder on the capture server or the destination server, the user name, domain and password can be used to impersonate the file moves. Note that you should use credentials that will allow full access to both locations.

### Filters

On this page, filters can be predefined to make it easier to start captures.

### Security

On this page, you can enter the SSH connection details with the **Username** and **Password** parameters. You can then test the connection with the **Connect** button. The **SSH Connection State** parameter shows the connection state.

After restart, the element will automatically try to connect to the server.
