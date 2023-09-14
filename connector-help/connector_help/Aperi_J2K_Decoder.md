---
uid: Connector_help_Aperi_J2K_Decoder
---

# Aperi J2K Decoder

The Aperi J2K Decoder is an app that supports up to four channels of SD, HD and 3G de-encapsulation from IP, decoded per microserver/card.

The microserver is an SDMP (Software Defined Media Platform) designed to run the Aperi J2K Decoder and others apps.

## About

This connector uses the **HTTP API** to collect information from the device and adjust settings on the device.

### Version Info

| **Range**         | **Description**                | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|--------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial version.               | No                  | Yes                     |
| 1.0.1.x **\[SLC Main\]** | Streamlined all Aperi connectors. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.0.23                      |
| 1.0.1.x          | 2.0.23                      |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.

HTTP Settings:

- **IP Port**: The port of the connected device, by default *443* (HTTPS port).
- **Bus Address**: The card bus address. Range from 1 to 5. By default *1*.

### Configuration

After element creation, specify a valid **User Name** and **Password** to start polling data from the device. To do so, go to the **Security Settings** subpage of the **General** page.

## Usage

### General Page

This page allows you to monitor the general device parameters.

- The **System Information** section contains information about the system parameters and the main board specifications.
- The **System Utilization** section contains the status of the internal parameters, such as **temperature**, **memory** and other system parameters.

Via the **Security Settings** page button, you can configure the username and password to communicate with the device:

- This subpage also displays the **HTTP Status Code**, which provide information about the HTTP response status of each command, the **Application Boot Status** and the **Login Status**, which displays the authentication status. If the **Login Status** is *Not Authorized*, the username/password combination is incorrect.
- The **Login** button verifies the username/password combination and authenticates the user.

Via the **Messanine Board** page button, you can monitor the status of Messanine board specifications.

### Video

This page displays the **Video Output Table**, with information about each available channel. For each channel, it mentions the **Port Name**, **Lock Status**, **TRS Errors** **Status**, **AP CRC Status**, **ANC CC Status**, etc.

### Audio

This page displays the **Audio Embedded** table, which lists the following information for each channel:

- **Loss of Audio Status**
- **Pass Audio Group 1 Status**
- **Group 1 Status**
- **Pass Audio Group 2 Status**
- **Group 2 Status**

The Pass Audio Group 1 Status and Pass Audio Group 2 Status can be adjusted in the table.

### IP Flows

On this page, you can configure the IP flow for each available channel. The page has 5 subpages:

- **Flow Management**: Allows you to configure the main IP flow parameters.
- **MGT Statistics**: Displays the port statistics.
- **FEC Status**: Displays the FEC status.
- **Status:** Displays the number of dropped packets and recovered packets of each channel.
- **Filter:** Determines the filter for the IP receiver.

### Ethernet

This page displays a table with Ethernet information for each port. The table has the following columns:

- **Port ID**
- **MAC Address** (configurable)
- **Link Status**
- **RX Bytes**
- **TX Bytes**
- **RX Frames**
- **TX Frames**
- **TX Rate**

### Transport Stream

On this page, you can configure the transport stream of each channel. For example, you can configure the **PMT**, **1st AES**, **CC (CEA-708)**, etc.

The page also displays **TS Rate** and **Video Rate** information.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
