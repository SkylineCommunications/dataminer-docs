---
uid: Connector_help_Sencore_MRD_5800
---

# Sencore MRD 5800

The **Sencore MRD 5800** connector is used to monitor and control the Sencore 5800 modular decoder.

## About

This connector uses **SNMP** to retrieve data about the inputs and outputs of the device.

The connector is very similar to the **Sencore MRD 4400**. In fact, the layout of both connectors is almost identical.

It is also possible to **download** a profile to a local file and to **upload** a profile.

### Version Info

| **Range** | **Description**                                                | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                | No                  | Yes                     |
| 1.0.1.x          | Added functionality to download and upload configuration files | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and Configuration

Framework version: 3.5.

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

This connector uses an HTTP connection (to download and upload profiles) and requires the following input during element creation:

**HTTP Connection:**

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the destination: 80.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### General

This page displays some general device parameters, the **primary and backup input source**, and a page button that shows the **network** parameters.

### Input Selection

This page displays the different inputs available in the device. In the **Configure Inputs** area, you can select the main and backup input and the failover conditions.

### Input

This page provides more details about the different inputs. Five kinds of inputs are available: **ASI**, **MPEG/IP**, **DVB-S**, **VSB** and **Turbo PSK**.

From connector version 1.0.1.2 onwards, this page contains a subpage, **IP - Name**, where destination names are used to resolve an IP address in the MPEG/IP table on the main Input page.

On the **IP - Name** subpage, lines can be added one by one or **imported** from a semicolon-separated CSV file. They may also be **exported** directly to a suitable format and then imported again later. In the CSV file, the destination name should be the first column, and the destination IP the second column. You can confirm the format by trying an export of a number of test lines. All exported and imported files are stored in the folder "C:\Skyline DataMiner\Documents". In the text boxes defining these files, only the file names and the extension ".csv" must be entered. All lines can also easily be removed. All of this can be done via the right-click menu of the subpage.

### Biss

On this page, you can configure **BISS** settings (Basic Interoperable Scrambling System).

### CAM

On this page, you can configure **CAM** settings.

### Service

With this menu, you can configure the **PIDs** or **Service** that the MRD 5800 will decode.

In **Service Lock** mode, the MRD is set to decode a specific service number or service name. If at any time the PIDs within the service change, the MRD will continue to decode the specified service.

In **PID Lock** mode, the MRD will only decode the PIDs specified by the user under the **PID Lock** page button.

### Video

On this page, you can configure the **Video** service settings: **Aspect Ratio**, **Overlay**, ...

### Audio

On this page, you can change the settings of the four **Audio** channels.

### Genlock

With this menu, you can configure the **Genlock** reference used by the MRD 5800.

### Baseband Outputs

On this page, you can configure the different possible outputs: **HD SDI**, **SD SDI**, **Composite**, ...

### TS Output

On this page, you can configure the **MPEG** and **ASIoutput** transport streams.

### Admin

On this page, you can configure the network properties of the device.

The following page buttons are available:

- **Security:** Allows the user to fill in the username and password used for the HTTP communication.
- **Profiles:** Provides an overview of the available profiles, and allows the user to download a profile to a local file or upload a profile.
  The profiles are stored in the DataMiner Documents folder for this protocol (C:\Skyline DataMiner\Documents\Sencore MRD 5800).

### Reporting

This page lists the alarms and events retrieved from the device.

### About

This page displays miscellaneous data regarding the MRD 5800.

### Webpage

This page contains the native web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
