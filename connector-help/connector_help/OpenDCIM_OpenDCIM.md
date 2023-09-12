---
uid: Connector_help_OpenDCIM_OpenDCIM
---

# OpenDCIM OpenDCIM

This driver can be used to interact with an OpenDCIM Data Center Infrastructure Management application. The purpose of this driver is to request information from OpenDCIM about one or more elements on a DMA.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 19.01                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

After the element has been created, you will need to provide the username and password to connect to the OpenDCIM system. This is the same username and password as is used to access the OpenDCIM system in a browser.

### Redundancy

No redundancy is defined in the driver.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The main function of this driver is to request additional information about a physical device that is monitored by DataMiner through the OpenDCIM system.

This works by writing a serialized ExternalRequest in JSON format to parameter 1221 (IncomingExternalRequest). This can be done from an Automation script. This request contains a unique ID and one or more ElementData instances (containing the DMA ID and Element ID of an element to be retrieved).

When a new request is received, an entry will be created in the External Requests table and the status will be set to "Pending". The driver will then check if the requested elements are available in the DataMiner System. If an element is available, its name will be used to retrieve information about the physical device by polling the OpenDCIM system. This implies that the name of the device in the OpenDCIM system must match the name of the element in DataMiner (case-insensitive).

The driver will make several calls to the OpenDCIM API to retrieve information about the device and its location in the data center (if available). When the polling of information is done, an ExternalResponse instance will be created, containing the retrieved information for each requested element. This object will be serialized in JSON format and placed in the Response cell of the request in the External Requests table. The status will be updated to "Completed". Should something go wrong during the execution of the request, the status will be set to "Failed".

## DataMiner Connectivity Framework

This driver does not support DCF.

## Notes

The external requests and responses are grouped in the ExternalRequests namespace. This namespace can be found in QAction 1 of the driver.
