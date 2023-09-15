---
uid: Connector_help_Ericsson_VPC
---

# Ericsson VPC

The Ericsson VPC connector is a monitoring solution for the Ericsson Video Processing Chassis.

## About

Ericsson VPC will retrieve the active configuration file from the Video Processing Chassis and then parse this data.

### Version Info

| **Range** | **Description**                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                 | No                  | No                      |
| 2.0.0.x          | New range without DVE creation. | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.8.1                       |
| 2.0.0.x          | 2.8.1                       |

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus Address:** The bus address of the device.\[default value: "*bypassproxy*"\]

### Configuration

This is an HTTP connector. To install the connector simply enter the IP address of the device in the Element Creation wizard. Depending on your configuration, it may be necessary to use or not '*bypassproxy*' in the bus address field.

### Timing

All data gets retrieved from the device with a very specific timing:

- Get Full Configuration -- 6s wait -- Get Active Alarms -- 6s wait -- Get Active Alarms -- 6s wait -- REPEAT

## Usage

### General

Contains generic information concerning the chassis itself, including some general parameters of interest.

### Alarms

Contains all possible alarms present in the current configuration. The **Alarm Severity** will indicate if the alarm is active or not. The possible **Severity** values are:

- Inactive
- Active: Critical
- Active: Major
- Active: Minor
- Active: Warning
- Active: Mask

### Slot Overview

Displays which cards are present in the chassis and their general data such as **versions, serial numbers, card status**, etc.

Parameters of interest:

- **SlotTable Tree Displayed Name:** The name used for creating Output and Input Trees.
- **SlotTable Displayed Module Name:** The name used to indicate the type of card.

### Output Tree (Output Tables)

The **Output Tree** provides the user with a graphical tree representation of all the output streams, outputs, services and Audio-Video-Teletext components per slot in the chassis.

You can find the raw data used to create this tree in tables on the **Output Tables** page.

### Input Tree (Input Tables)

The **Input Tree** provides the user with a graphical tree representation of all the input streams, inputs, services, and Audio-Video-Teletext components per slot in the chassis.

You can find the raw data used to create this tree in tables on the **Input Tables** page

### Connectivity Tree (Stream Connectivity)

The **Connectivity Tree** provides the user with a graphical tree representation of all output streams in the connector that have a referenced input stream. Their referenced input streams are children of the Output streams in the tree view.

The raw data used to create this tree is visible as tables on the **Stream Connectivity** page

### Configurations

This page allows a user to **Download** or **Upload** the configuration file and respectively store the file locally or overwrite it on the device.

Note: Make sure the Path parameter always ends with a '/'.

### Switching VLAN

Using Cisco elements present in the DMS, this page allows a user to monitor the port bitrates monitored by those elements on specific VLANs. Use the **Get CISCO Elements** option to scan for any compatible Cisco elements in the DMS

### Base Unit

This page provides the user with in-depth and detailed information concerning the Host Controller Card present in the chassis.

The page contains page buttons to view the following information:

- the speed of the fans,
- the temperature of different elements on the card,
- the build versions,
- the authentication used to access the device,
- information concerning the voltage rails.

### SNMP

This page shows the current SNMP settings available on the device including all information concerning traps.

### Demux

This page shows the Demultiplexer settings concerning auto switching and reverting.

### Heartbeat

This page shows whether the CSM is active and in contact with the control system, along with additional detailed information.

### Input Streams

This page provides information about all input streams present in the Host Card.

### MGP Support

This page allows users to consult the current status of all MGP-related details. The page also shows the different **MGP Spare IP-Addresses** in a table.

### Network

This page contains a large table visualizing all physical interfaces on the chassis with their status and details. Bitrates are also calculated and are available for trending and alarming.

### License Overview

This page provides a summary of all the available licenses, their code and how many licenses are still available.

### Specific card pages

For each of the cards that can be present in the chassis, different pages are available.

- **ASI IO Option Pages (Cards, Ports, Temperatures, ASI Outputs, Outputs):** These pages provide all data concerning the **ASI IO Option** cards present in the chassis.
- **EN8190PP Pages (Cards, Ports, Input Streams, Output Streams, Temperatures, Dolby Metadata, Video Input, Video Encode, Video Format, AudioGroup):** These pages display all information present in any available **EN8190 Pre Processor** card. **Data, Video** and **Audio settings** are available on their respective pages and all **Input Streams** and **Output Streams** are displayed in separate tables.
- **EN7100 Pages (Cards, Ports, Input Streams, Output Streams, Temperatures, Dolby Metadata, Video Input, Video Encode, AudioGroup):** These pages provide data on any cards of type **EN7100** present in the chassis. **Data, Video** and **Audio settings** are available on their respective pages and all **Input Streams** and **Output Streams** are displayed in separate tables.
- **EN8190 Encoder Pages (Cards, Temperatures, Input Streams, Output Streams):** These pages display cards of type **EN8190 Encoder**. All **Input Streams** and **Output Streams** are displayed in separate tables.
- **EN8100 Pages (Cards, Ports, Input Streams, Output Streams, Temperatures, Dolby Metadata, Video Input, Video Encode, AudioGroup):** These pages show detailed information on any cards of type **EN8100** in the chassis. **Data, Video** and **Audio settings** are available on their respective pages and all **Input Streams** and **Output Streams** are displayed in separate tables.
- **EN7190 Encoder Pages(Cards, Ports, Dolby Metadata, Input Streams, Output Streams, Temperatures, Video Input, Video Encode, Video Format Conversion, Audio Group):** These pages display all information present in any available **EN7190 Encoder** card. **Data**, **Video** and **Audio settings** are available on their respective pages and all **Input Streams** and **Output Streams** are displayed in separate tables.

## Notes

- After uploading the connector or changing the version, initial startup can take a few minutes because of the creation of a parameter mapping in the QuickAction DLLs. Please take into consideration that each first run of a QuickAction (after startup, after pushing a button, .) will take about 40 seconds. After that, runtime of QuickActions is reduced to a minimum. Element restarts will not cause the delays to occur again; they only occur after you change the connector version and activate the element for the first time.
