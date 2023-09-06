---
uid: Connector_help_Rohde_Schwarz_Prismon
---

# Rohde Schwarz Prismon

This is a DataMiner connector for the **Rhode Schwarz Prismon** **Audio/Video Content Monitoring and Multiviewer**, a solution for visual monitoring of encoded or unencoded audio and video services.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP(S) CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

**Note:**

- When you use **port 80**, "Allow insecure REST-API access" needs to be enabled on the device.
- When you use **port 443**, **HTTPS** will be enabled. In the background, the **Remote Access Settings** are then used to request a token and provide the request with an authentication token. These will be filled in according to the device's default settings. Note that these need to be updated accordingly when this is changed in the device.

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *private*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page allows you to monitor the system parameters, as well as configure specific system parameters (e.g. System Name, System Contact, System Location, etc.).

The page also contains information regarding the **Polling State**, the last obtained **Status Code** and the **URL** used in the latest request. You can also disable the device polling by changing the **Polling State**.

Additionally, the page displays a **Changes Log** table, which keeps track of changes performed to the modules. If there is an entry in this table, the **Configuration Overall Status** is set to *Not Applied*, which indicates that *the configuration changes performed on the device are NOT RUNNING yet*. To apply the changes performed on the configuration, you need to restart the modules on which changes were implemented. When **Restart Modules** is clicked, this will restart all the modules listed in the **Changes Log** Table.

### Input

This page allows you to monitor the **service status** of the **SPU sources**. This information is polled via SNMP.

The page also contains page buttons to the following pages:

- **Input Mode:** Contains the table used to configure all the input information for the SPU sources (e.g. Input Mode, Input Address, Input Port).
- **Main Configuration**: Contains the configuration information regarding the source **Aspect Ratio** and **Audio Filters**.
- **T2MIParameter:** Contains the **PID** and **PLP** configured for each module.
- **Analyzing**: Contains the configuration of the error analysis for each module.
- **Multiple Inputs**: Contains the configuration of the input information regarding additional input sources.
- **Video Configuration**: Contains the video configuration, including the interfaces used, for each module.
- **Audio Configuration**: Contains the audio configuration, including the interfaces used, for each module.
- **Data Configuration**: Contains the data configuration, including the interfaces used, for each module.

### Decoding & Analyzing

This page allows you to monitor the services (or SPU inputs). All tables are polled via SNMP, exceptthe **SU Inputs** table, for which information is retrieved via HTTP.

The page also contains page buttons to the following pages:

- **Input Configuration** Allows you to configure the source inserted in the service and the component query of each service.
- **Video Analyzing**: Allows you to configure the video-related analysis of each service.
- **Audio Analyzing**: Allows you to configure the audio-related analysis of each service.
- **Data Analyzing**: Allows you to configure the data-related analysis of each service.
- **PSI/SI Analyzing**: Allows you to configure the PSI/SI analysis of each service.
- **Deep Video Analyzing**: Allows you to configure the deep video analysis of each service.
- **Hybrid Monitoring**: Allows you to configure the hybrid monitoring of each service.
- **Layout And Streaming**: Allows you to enable the audio web streaming of each service.
- **Dolby Parameter**: Allows you to configure the Dolby parameters of each service.
- **Custom Monitoring**: Allows you to configure the custom monitoring for each service.

### Processing

This page allows you to configure the description of the views (or SPU BMM). This information is polled via HTTP.

The page also contains page buttons to the following pages:

- **Input Tiles**: Allows you to configure the input tiles of each view.
- **Additional Remote Tiles**: Allows you to configure the additional remote tiles of each view.
- **SMPTE 2110 Output**: Allows you to enable the SMPTE 2110 output for each view.
- **SDIoIP output**: Allows you to enable the SDIoIP output for each view.
- **TSoIP Output**: Allows you to configure the TSoIP output of each view.
- **OTT Output**: Allows you to configure the OTT output of each view.
- **Remote Monitoring Devices**: Allows you to configure the remote monitoring device IP address for each view.
- **Tally Configuration**: Allows you to configure the tally configuration network port for each view.
- **Penalty Box Configuration**: Allows you to configure the penalty box of each view.
- **Dynamic System Tiles**: Allows you to configure the dynamic system tiles for each view.
- **Static Description Tiles**: Allows you to configure the static description tiles for each view.

### Processing

This page allows you to configure the output modules. This information is polled via HTTP.

### System & Hardware

This page allows you to configure the network interfaces, SNMP trap servers, mail servers, and SPU recorder via HTTP.

It also allows you to monitor the memory usage and CPU usage for each task running on the device. This information is polled via SNMP.

### Interfaces

This page allows you to monitor the interfaces of the device. This information is polled via SNMP.

## Notes

Every table retrieved via HTTP contains a **Change Status** column, which indicates if a change was implemented on the device via DataMiner and the affected module has not been restarted.

When you click the **Restart Modules** button on the General page, the **Change Status** switches to *Not Changed.*
