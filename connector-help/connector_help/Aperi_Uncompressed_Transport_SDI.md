---
uid: Connector_help_Aperi_Uncompressed_Transport_SDI
---

# Aperi Uncompressed Transport SDI

**Aperi Uncompressed Transport** is an application that handles encapsulation/decapsulation of 4 inputs and 4 outputs of SD/HD/3G SDI simultaneously.

## About

This connector is used to retrieve all the data regarding the Uncompressed Transport SDI card inside an Aperi chassis.

It uses the REST API to get and set all parameters associated with this type of card.

### Version Info

| **Range**         | **Description**               | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|-------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial version               | No                  | Yes                     |
| 1.0.1.x **\[SLC Main\]** | Streamlined all Aperi connectors | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.2.0                       |
| 1.0.1.x          | 1.2.0                       |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus Address:** The bus address used to access the desired card. Default: *BypassProxy*. If this is not properly set, no information is obtained.

## Usage

### General

This page allows you to monitor the general device parameters.

- The **System Information** section contains information about the system parameters and the main board specifications.
- The **System Utilization** section contains the status of the internal parameters, such as **temperature**, **memory** and other system parameters.

Via the **Security Settings** page button, you can configure the username and password to communicate with the device:

- This subpage also displays the **HTTP Status Code**, which provides information about the HTTP response status of each command, the **Application Boot Status** and the **Login Status**, which displays the authentication status. If the **Login Status** is *Not Authorized*, the username/password combination is incorrect.
- The **Login** button verifies the username/password combination and authenticates the user.

Via the **Messanine Board** page button, you can monitor the status of Messanine board specifications.

### Video

This page displays the **Video Input** and **Video Output Tables**.

### Audio

This page displays the **Audio Input** and **Audio Output Tables**.

### SFPs

This page displays information about the 4 SFPs, including whether they are installed or not.

### IP Flows

This page displays the **IP Flows TX** and **RX Tables**.

The page also contains page buttons to the following subpages:

- **Flow Management**: Contains the **Flow Management Tx** and **Flow Management Rx** tables.
- **FEC**: Allows you to configure and check the Forward Error Correction (FEC) on the system. Displays the **FEC Tx** and **FEC Rx** tables.
- **Mgt Statistics**: Contains the **Management Statistics In** and **Management Statistics Out** tables. These tables contain statistics regarding packet transmission and reception on each port of a channel.
- **IP Filter**: Contains the **Filter Rx** table for all 4 channels, which allows you to enable filters on **Source UDP**, **Source IP** and **SSRC**.

### Ethernet

This page displays the **Ethernet Table**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
