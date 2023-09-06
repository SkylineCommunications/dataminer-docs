---
uid: Connector_help_Harmonic_PVR-8140
---

# Harmonic PVR-8140

The Harmonic PVR-8140 belongs to the Harmonic ProView8000 family of integrated receiver-decoders. The Harmonic 8140 series has two balanced analog and four balanced digital audio outputs. Users can receive DVB-S/S2/S2X, IP, or ASI signals, decode SD and HD MPEG-2 and MPEG-4 AVC transport streams to baseband, descramble encrypted programs, and output content to analog or digital.

This connector parses all data from the device web interface and displays it to the end user in DataMiner. The connector has all read-write functionality from the web interface. It uses an HTTP connection to access the device and retrieve the data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - http

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: 192.168.9.11
- **IP port**: 80
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

When the element has been created, go to the **General** \> **HTTP Login** page and enter the HTTP credentials.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector uses an HTTP connection to get the data from the web interface and show it in DataMiner. It presents the parameters in a structure similar to that of the web interface of the device and also allows you to control the parameters in a similar manner.

On the **General** page (which is the default page), data related to the device itself is displayed (device model, name, firmware, etc.). This page also has page buttons to the GbE Port settings and HTTP Login subpages.

The **Input** page contains all input data. It also has subpages for ASI, DVB/S/S2/S2X Port, LNB, and GbE Socket Input, where you can find tables and data related to input parameters.

On the **Alarms** page, you can find tables with active alarms and alarm logs. You can clear alarm logs from the alarm logs table using a button.

The **Decryption** page displays data related to decryption received from the device web interface.

The **Outputs** page contains the Gbe Socket Output table, as well as data related to output from the device itself.

The **Services** page displays the status of services, data for programs, service video, and service audio from 1 to 4. This page also contains the programs table, and it has page buttons leading to subpages related to PIDS, OSD, DPI, PCR, Video, and Audio.

On the **VBI** page, you can find all VBI data. There are also subpages for VBI Closed Caption, VBI AMOL, VITC, VITS, TV Guide, WSS, Teletext, AFD VI, Raw Data, SCTE 104, and VPS.
