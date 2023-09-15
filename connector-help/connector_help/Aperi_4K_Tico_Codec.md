---
uid: Connector_help_Aperi_4K_Tico_Codec
---

# Aperi 4K Tico Codec

This is an **HTTP** connector that is used to monitor and configure the **Aperi 4K Tico Codec** equipment.

## About

The information on tables and parameters is retrieved via **HTTP** communication.

### Version Info

| **Range**         | **Description**                | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|--------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial version.               | No                  | Yes                     |
| 1.0.1.x **\[SLC Main\]** | Streamlined all Aperi connectors. | No                  | Yes                     |
| 1.1.0.x                  | New firmware version.          | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |
| 1.1.0.x          | 1.1.2                       |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The microserver slot ID (range: *1 - 5*).

### Configuration

After element creation, specify a valid **User Name** and **Password** to start polling data from the device. To do so, go to the **Security Settings** subpage of the **General** page.

## Usage

### General

This page allows you to monitor the general device parameters.

- The **System Information** section contains information about the system parameters and the main board specifications.
- The **System Utilization** section contains the status of the internal parameters, such as **temperature**, **memory** and other system parameters.

Via the **Security Settings** page button, you can configure the username and password to communicate with the device:

- This subpage also displays the **HTTP Status Code**, which provides information about the HTTP response status of each command, the **Application Boot Status** and the **Login Status**, which displays the authentication status. If the **Login Status** is *Not Authorized*, the username/password combination is incorrect.
- The **Login** button verifies the username/password combination and authenticates the user.

Via the **Messanine Board Info** page button, you can monitor the status of the Messanine board specifications.

### Video

This page displays all video interface error info in the **Video Input** and **Video Output** tables.

### Audio

This page displays all channel and audio group statuses in the **Audio Input** and **Audio Output** tables.

### SFPs

This page contains information about the installation status of SFPs in the 4 channels.

### IP Flows

This page displays the IP flow out information. You can find all channel information in the **IP Flow Out Channels** table and all port information in the **IP Flow Out Management** table.

### Ethernet

This page displays the status of the Ethernet ports 0 and 1 in the **Ethernet** table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
