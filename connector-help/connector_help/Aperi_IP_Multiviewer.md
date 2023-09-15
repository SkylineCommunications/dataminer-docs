---
uid: Connector_help_Aperi_IP_Multiviewer
---

# Aperi IP Multiviewer

The Aperi IP Multiviewer is an FPGA-based application designed to run on an Aperi microserver with the A1105 platform. The multiviewer can receive IP flows from up to three sources: the two 10 GbE backplane Ethernet ports and the "SFP 1" 10 GbE front panel port. Each of the two 10 GbE backplane Ethernet ports supports up to six SMPTE 2022-6 (uncompressed) IP flows per port (12 in total). The front panel SFP 1 port supports up to six SMPTE 2022-6 (uncompressed) IP flows. The app is configured to support 16 uncompressed IP flows across the three inputs.

## About

This connector collects information from the device using an HTTP connection. It uses the **REST API** to get and set all parameters associated with this type of card.

### Version Info

| **Range**         | **Description**                | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|--------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial version.               | No                  | Yes                     |
| 1.0.1.x **\[SLC Main\]** | Streamlined all Aperi connectors. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.8                       |
| 1.0.1.x          | 1.0.8                       |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus** **address**: By default *bypassproxy*.

## Usage

### General

This page allows you to monitor general device parameters.

The **Security Settings** page button allows you to configure the username and password to communicate with the device:

- This page also contains the **HTTP Communication Status** and **Login Status**, which provide information about the HTTP response status of each command and the authentication status, respectively. If the **Login Status** is *Not Authorized*, the username/password combination is incorrect.
- The **Login** button verifies the username/password combination and authenticates the user.

### SFPs

This page contains information about the Ethernet ports. It contains two tables:

- The **Backplane Statistics Table** contains all the statistical information on the backplane ports **BP1** and **BP2**, such as **Rx bytes**, **Tx bytes**, **Rx bitrate**, **Tx bitrate**, **Tx Frames**, **Rx frames** etc.
- The **Front Panel Statistics Table** contains similar statistical information on the front panel ports **SFP1**, **SFP2**, **SFP3** and **SFP4**.

### Layout

This page contains information related to the 16 tiles in the multiviewer and allows you to configure their settings.

For each tile, the parameters are grouped in a box. Each group box contains a page button **Advanced**, which links to advanced settings such as the **tile protocol**, **UDP ports**, **statistics**, **alarms**, **encapsulation settings**, etc.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
