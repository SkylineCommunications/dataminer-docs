---
uid: Connector_help_Aperi_MPEG_Transport_Stream_ASI
---

# Aperi MPEG Transport Stream ASI

The Aperi ASI Transport Stream to IP Network app is an FPGA-based application that is designed to run on the Aperi platform. It offers up to four channels of unidirectional transport stream encapsulation and decapsulation for ASI video signals compliant with DVB and ISO/IEC MPEG-2 transport stream standards.

This connector collects information from the device using an HTTP connection. It uses the **REST API** to get and set the parameters associated with this type of card.

## About

### Version Info

| **Range**            | **Key Features**                                                  | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version. DCF is implemented from version 1.0.0.2 onwards. | \-           | \-                |
| 1.0.1.x \[Obsolete\] | Support for firmware 1.6.12. Complete cleanup of the connector.   | \-           | \-                |
| 1.0.2.x \[Obsolete\] | Streamlined all Aperi connectors.                                 | \-           | \-                |
| 1.0.3.x \[Obsolete\] | Flow Management Tx Table cleaned up.                              | \-           | \-                |
| 1.1.0.x \[SLC Main\] | Support for firmware 1.7.17.                                      | 1.0.3.8.     | \-                |

### Product Info

| **Range** | **Device Firmware Version** |
|-----------|-----------------------------|
| 1.0.0.x   | 0.5.38                      |
| 1.0.1.x   | 1.6.12                      |
| 1.0.2.x   | 1.6.12                      |
| 1.0.3.x   | 1.6.12                      |
| 1.1.0.x   | 1.7.17                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus Address**: The bus address used to access the card. If this is not properly set, no information is obtained. Default: *BypassProxy*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page allows you to monitor the general device parameters.

- The **System Information** section contains information about the system parameters and the main board specifications.
- The **System Utilization** section contains the status of the internal parameters, such as **temperature**, **memory** and other system parameters.

Via the **Security Setting** page button, you can configure the username and password to communicate with the device:

- This subpage also displays the **HTTP Status Code**, which provides information about the HTTP response status of each command, the **Application Boot Status** and the **Login Status**, which displays the authentication status. If the **Login Status** is *Not Authorized*, the username/password combination is incorrect.
- The **Login** button verifies the username/password combination and authenticates the user.

Via the **Messanine Board Info** page button, you can monitor the status of Messanine board specifications.

### SFPs

This page contains information about the installation status of SFPs in the 4 channels.

### ASI

This page contains the **ASI In** table and the **ASI Out** table.

### IP Flows

This page contains the **IP Flows Tx** and **IP Flows Rx** tables.

The page also contains the following page buttons:

- **Flow Management**: Displays the **Flow Management Tx** and **Flow Management Rx** tables.
- **Failover Config**: Allows you to configure several parts of the failover system on the device. This includes **Flow Failover** data, **Channel Failover** data and **PID Monitoring**.
- **FEC**: Allows you to configure and check the status of the Forward Error Correction (FEC) in the system. Displays the **FEC Tx** and **FEC Rx** tables.
- **Mgt Statistics**: Displays the **Management Statistics In** and **Management Statistics Out** tables. These tables contain statistics regarding packet transmission and reception on each port of a channel.
- **IP Filter**: Displays the **Filter Rx** table for all 4 channels, which allows you to enable filters on **Source UDP**, **Source IP** and **SSRC**.
- **Rx Status**: Displays the **Status Rx** table (packet and RTP unlock statistics) and an **Input Status** table, which displays the status of several aspects of the ASI streams (**Synchronization**, **PAT**, **PMT**, **PID**, **RTP**, etc.).
- **PID Status**: Displays the status of the program side of the device. Depending on the configured **PID Failover**, the displayed data should reflect the program data being monitored.

### Ethernet

This page displays the status of Ethernet ports 0 and 1 in the **Ethernet** table.
