---
uid: Connector_help_AviWest_StreamHub
---

# AviWest StreamHub

The AviWest StreamHub DataMiner connector will interface with StreamHubs using a REST API, so that you can use DataMiner to monitor all incoming video streams, manage the transcoding of these streams, and monitor all outgoing video streams. The AviWest StreamHub Series is a range of transceiver platforms that are used to receive, decode, and distribute live video streams coming from any AviWest encoder/transmitter or third-party system.

Up to 8 videos can be decoded simultaneously thanks to 8 SDI outputs, while up to 32 IP outputs are supported to re-stream the video contents over LAN or WAN to CDNs, media servers, streaming platforms, social networks, IRDs, or other StreamHubs. Each StreamHub also features video encoding and transcoding capability, so that incoming feeds can be adapted to the desired output format.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**         |
|-----------|--------------------------------|
| 1.0.0.x   | 3.4.03.5.03.5.24.0.14.1.04.2.3 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the destination.
- **IP port**: 8893. Specify the **default IP port of the StreamHub RESTful API service**, not the IP port of the web interface.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

To make sure the element can poll data and display information, you need to fill in the **API key** and the **Web Interface IP** on the **General** page.

- The **Web Interface IP** must comply with the following format: 10.10.10.10:8888. By default, the IP port of the web interface is 8888. Note that 10.10.10.10 is merely an example IP address; you will need specify your web interface IP address instead.
- To obtain the **API key**, go to the web interface and log in with your credentials. Then go to admin \> REST API doc and copy the API key located in the top-right corner of the page.

### Redundancy

No redundancy is defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

HTTP REST calls (GET and POST) are used to retrieve the device information. To see the actual traffic between the element and the device, a built-in DataMiner tool called Stream Viewer can be used. You can access it by right-clicking the element in the Surveyor and selecting View \> Stream Viewer.

### General Page

The General page shows basic information and contains all configuration parameters. In case the element does not seem to poll data (the Stream Viewer remains empty), please verify if the API Key parameter is filled in correctly. In case the built-in web interface shows a blank page, please check if the Web Interface IP parameter is filled in correctly.

### Inputs Page

This page contains a table with information related to the inputs. Enabling and disabling the live stream is only possible from this page.

### Outputs Page

This page contains a table with the data associated with the outputs. Assigning an input to an output is only possible from this page.

It is possible that the Outputs table remains empty. This can happen when no outputs are configured. Check the web interface to verify if outputs are shown/configured.

### IP Outputs page

This page contains a table with information related to the IP outputs. Assigning an input to an IP output is only possible from this page.

It is possible that the IP Outputs table remains empty. This can happen when no IP outputs are configured. Check the web interface to verify if IP outputs are shown/configured.

### Live Statistics Page

The Live Statistics page contains live data of the field units connected to the corresponding input. This data is only shown when the field unit is currently live.

When some streams were live earlier but are currently no longer live, the corresponding entries may be represented as *Not Initialized*.

The connector will not send HTTP requests to collect the live statistics in case no field unit is currently live.

### Audio Levels Page

This page contains a table with the live audio levels of the field units connected to the corresponding input. This information is issued by the StreamHub's internal decoder, but only in case a field unit is currently live.

When no streams are live, the Audio Levels table will remain empty.

### Video Previews Page

This page contains a table with the thumbnail URLs of the field units connected to the corresponding inputs.

When no field units are currently live, this table will remain empty.

### Stream Statistics Page

The Stream Statistics page contains numerical live data of the field units connected to the corresponding input, but only in case the field unit is currently live.

The data is classified in five types: IP, Video, Audio, MpegtsDown, and MpegtsUp. It can happen that not all types are defined for every live input.

### Link Statistics Page

This page contains a table with information related to the link statistics of the field units connected to the corresponding input.

### Log Page

This page contains a table with the device log in chronological order.
