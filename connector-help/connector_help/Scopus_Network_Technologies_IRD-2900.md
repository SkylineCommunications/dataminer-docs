---
uid: Connector_help_Scopus_Network_Technologies_IRD-2900
---

# Scopus Network Technologies IRD-2900

The IRD-2900 is a broadcast-quality decoder, decryptor and interface converter that provides MPEG-2 and AVC SD decoding, advanced transport stream processing, cutting-edge IP processing technologies and a variety of front ends, including DVB-S2, MPEG over IP and more.

## About

The **Scopus Network Technologies IRD-2900** connector is used to monitor and control the Scopus Network Technologies Integrated Receiver decoder 2900.

The data for monitoring and controlling the device can be found on different pages, each pertaining to a specific part of the device.

### Version Info

| **Range** | **Description**                                                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.1.2.1          | Review: Update from 'displaycolumn' to 'naming'. Changed Name/Description/Displaying values. | No                  | No                      |
| 1.1.2.2          | Sets Reviewed. Added SNMP type tags.                                                                | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.2.x          | 4.6                         |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

This page displays general information about the device.

There is a page button available, **Set** **Date/Time**, which opens a subpage where the date and time can be set.

Underneath that button, there is a **Reset** button, which can be used to reset the values.

### Alarms page

This page displays two tables:

- **Alarm** **Status** **Table**: Displays different alarm descriptions and shows if they are in *Alarm* or *Ok*.
- **Trap** **Destination** **Table**: Displays the destination IP of the incoming traps.

### Demodulator page

On this page, you can modify the settings for the receiver.

### IP Front-End page

On this page, the network settings can be modified.

### Service page

This page displays the different services.

There are three page buttons available that will each open a subpage where additional settings can be done.

Underneath these, there is a **Load** button, which can be used to load different services in the **ServiceTable**.

### Video page

On this page, you can modify the settings for **Video 1** and **Video 2**.

There are three page buttons available that will each open a subpage where additional settings are displayed.

### Audio 1-2 & Audio 3-4 page

The **Audio 1-2** and **Audio 3-4** pages are similar, each showing information related to its specific audio channels.

On these pages, the settings for the audio channels can be modified.

There is one page button available, **MPEG Info**, which opens a subpage with additional information.

### Stream page

This page displays information regarding the stream.

A number of sets can be performed on this page, and there are also ten page buttons available. Each of these page buttons will open a subpage with additional information regarding the subject described on the button.

### Satellite Delivery System page

This page displays one table with information regarding the satellite delivery system.

Click the **Load** button at the top to have data displayed in the table.

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
