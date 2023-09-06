---
uid: Connector_help_Ateme_Kyrion_DR5000
---

# Ateme Kyrion DR5000

The Kyrion DR5000 is an integrated receiver decoder dedicated to professional contribution over satellite, IP and ASI networks.

## About

This driver uses **SNMP** to allow the user to monitor the **Ateme Kyrion DR5000** decoder and make changes to the configuration of the device.

### Version Info

| **Range**            | **Key Features**                                                     | **Based on** | **System Impact**                                                                                         |
|----------------------|----------------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                      | \-           | \-                                                                                                        |
| 2.0.0.x              | Improved driver                                                      | 1.0.0.12     | \-                                                                                                        |
| 3.0.0.x \[Obsolete\] | Full driver review                                                   | 2.0.0.10     | See "Notes" section below                                                                                 |
| 3.0.1.x              | Changed descriptions and display keys                                | 3.0.0.24     | \-                                                                                                        |
| 3.0.2.x \[Obsolete\] | Reviewed DCF implementation                                          | 3.0.0.28     | \-                                                                                                        |
| 3.0.3.x \[Obsolete\] | Added missing SNMP parameters to Program Stream Table                | 3.0.2.2      | \-                                                                                                        |
| 3.0.4.x \[SLC Main\] | Fixed IDX of "Audio Output - Decoding Status" table to unique value. | 3.0.3.3      | From version 3.0.4.2 onwards the driver include the changes made on versions from 3.0.0.29 till 3.0.0.37. |
| 3.1.0.x              | New firmware; fixed validator errors                                 | 3.0.4.22     | Forward IP Streams Table: Parameter "IP Output" changed to "Type"                                         |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 2.0.0.x   | Unknown                |
| 3.0.0.x   | 1.4.255.210            |
| 3.0.1.x   | 1.4.255.210            |
| 3.0.2.x   | 1.4.255.210            |
| 3.0.3.x   | 1.4.255.210            |
| 3.0.4.x   | 1.4.255.210            |
| 3.1.0.x   | 2.5.0.0                |

### Product Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 2.0.0.x   | No                  | No                      | \-                    | \-                      |
| 3.0.0.x   | Yes                 | No                      | \-                    | \-                      |
| 3.0.1.x   | Yes                 | No                      | \-                    | \-                      |
| 3.0.2.x   | Yes                 | No                      | \-                    | \-                      |
| 3.0.3.x   | Yes                 | No                      | \-                    | \-                      |
| 3.0.4.x   | Yes                 | No                      | \-                    | \-                      |
| 3.1.0.x   | Yes                 | No                      | \-                    | \-                      |

## Installation and configuration

### Creation

#### SNMP main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **Software Version**, **System info**, **Temperature**, **Licenses**, **Fan Status** and **Power Supply Status**.

### Preset Page

This page displays the **Preset Table** and **Channel Action** parameters.

From version 3.0.2.2 onwards, there is an **Export/Import** page button. This allows you to export the active configuration of the device in XML format or to import it from a specified location.If the export file path field does not end with the *.xml* extension, the driver assumes that only the directory is specified, and the exported file is named as *configuration_active\_\<date\>\_\<time\>*. Otherwise, the exported file path is exactly the one specified in the field.

### RF Input Page

This page displays **RF Input** values and contains settings for the **RF Configuration**.

### IP Input Page

This page displays **IP Input** values and contains settings for the **IP Configuration**.

Note that from version 3.0.0.17 onwards, the IP settings on this page have been reviewed. The device accepts values in HEX for IP config parameters and values in ASCII for IP failover config parameters.

### ASI Input Page

This page displays the ASI **Input Type** and **Interface Settings**.

### Decoding Page

This page displays the decoding status, including the **Mode**, **Primary Service**, **Secondary Service**, etc.

It also contains a **buffer mechanism** for services that need to be set. This mechanism can be **triggered** **externally** (e.g. via Automation scripts) or from within the driver.

There is a **Program Stream Table** page button that displays all the input program streams configured in the device. This button opens the page **Stream Status**. The table that displays the streams is a static table, and can take a long time to be polled.

From **version** **3.0.0.22** **onwards**, you can adjust the amount of stream data polled from the device using the sliders **Programs in Table** and **Streams in Table**. This adjustment polls data from the device using the **subtable** option. If too much data is being polled from the device, this can cause RTEs, or a very long delay updating the remaining parameters that need to be polled from the device. Note: If you want to view all programs and streams, do not use the "all" option. Instead, manually enter the total number of programs/streams.

### Audio/Video Page

This page displays the audio and video status, including the **Codec**, **Profile**, **Level**, **Resolution**, **Bitdepth**, etc.

### Data Page

This page contains a number of page buttons. Prior to version 3.0.0.18, the page buttons **Ancillary**, **Smpte 2031** and **VBI** are displayed.

From version 3.0.0.18 of the driver onwards, there is an additional **Overlay** page button, which opens a subpage where **DVB Subtitle**, **Teletext** and **CC Service** parameters can be enabled, depending on the mode defined in the **Mode** parameter.

### Conditional Access Page

This page displays values related to the CAM, such as **Force 3V3**, **Service**, **Bitrate Limit**, **BISS Mode**, **Audio Embedded Aes**, etc.

### Virtual Page

This page displays values related to **Source**, **Aux** and **Decoder**.

### Output Page

This page displays values related to the output configuration, such as **SDI**, **Genlock** and **Emulation**.

### Polling Control Page

This page contains a table that allows you to define how fast each table in the driver must be polled.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **3.0.0.x** driver range of the protocol supports the usage of DCF, starting at version **3.0.0.14**, and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

In range **3.0.2.x** of the driver, DCF has been re-implemented, with a change to the number of available inputs and outputs.

### Interfaces (3.0.0.x)

#### Fixed interfaces

Physical fixed interfaces:

- **Input: ASI Input 1**
- **Input: IP Input 1**
- **Input: RF Input 1**
- **Input: ZIXI Input 1**

<!-- -->

- **Output: ASI Output 1**
- **Output: ASI Output 2**
- **Output: IP Output 1**
- **Output: IP Output 2**
- **Output: IP Output 3**
- **Output: SDI Output 1**
- **Output: SDI Output 2**
- **Output: SDI Output 3**

### Connections (3.0.0.x)

#### Internal Connections

- Between **ASI Input 1** and **all outputs**
- Between **IP Input 1** and **all outputs**
- Between **RF Input 1** and **all outputs**
- Between **ZIXI Input 1** and **all outputs**

### Interfaces (3.0.2.x)

#### Fixed interfaces

Physical fixed interfaces:

- **Input: ASI Input 1**
- **Input: ASI Input 2**
- **Input: RF Input 1**
- **Input: RF Input 2**
- **Input: RF Input 3**
- **Input: RF Input 4**
- **Input: VPSC Clock**
- **Input: ZIXI Input**

<!-- -->

- **Output: ASI Output 1**
- **Output: ASI Output 2**
- **Output: SDI Output 1**
- **Output: SDI Output 2**
- **Output: SDI Output 3**

<!-- -->

- **Input/Output: IP Stream 1**
- **Input/Output: IP Stream 2**

### Connections (3.0.2.x)

#### Internal Connections

- Between **ASI Input 1** and **all outputs**
- Between**ASI Input 2** and **all outputs**
- Between **VPSC Clock** and **ASI Output 2**
- Between **RF Input 1** and **all outputs**
- Between **RF Input 2** and **all outputs**
- Between **RF Input 3** and **all outputs**
- Between **RF Input 4** and **all outputs**
- Between **IP Stream 1** and **all outputs**
- Between **IP Stream 2** and **all outputs**

## Notes

The **3.0.0.1** version of this Ateme Kyrion DR5000 driver has been fully reviewed, causing some changes to the number of pages and the names of the pages. Compared to the previous versions, the **General**, **Preset** and **Output** pages remain the same. For the other pages, the following changes were applied:

- For consistency with the web interface, instead of one **Input** page, there are now three input pages, **RF** **Input**, **IP** **Input** and **ASI** **Input**.
- The **Stream** page is now a subpage that can be accessed via a button on the **Decoding** page.
- An **Audio/Video** and **Data** page were added to resemble the device GUI on the web interface.
- The **Encryption** page is now the **Conditional** **Access** page.
