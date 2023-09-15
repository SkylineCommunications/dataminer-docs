---
uid: Connector_help_CEFD_ViperSat
---

# CEFD ViperSat

The **ViperSat Management System (VMS)** is a server- and client-based network management system that gathers and processes information it receives from the modem/routers that comprise a ViperSat satellite network.
The modem's internal microprocessor-based input/output (I/O) controller measures, captures and transmits real-time network operating parameters to the VMS via either **PLDM (Path Loss Data Message)** or **SUM (Status Update Message)** packets, depending on the type of modem/router.

This connector will export different connectors based on the retrieved data (see "System Info" below).

## About

### Version Info

| **Range**            | **Key Features**  | **Based On** | **System Impact** |
|----------------------|-------------------|--------------|-------------------|
| 3.0.0.x              | Initial version   | \-           | \-                |
| 3.1.0.x              | Branched solution | 3.0.0.7      | \-                |
| 3.2.0.x              | Branched solution | 3.1.0.28     | \-                |
| 3.3.0.x              | Branched solution | 3.2.0.10     | \-                |
| 3.3.1.x              | Branched solution | 3.2.0.10     | \-                |
| 3.4.0.x              | Branched solution | 3.3.0.14     | \-                |
| 3.5.0.x              | Branched solution | 3.4.0.10     | \-                |
| 3.5.1.x \[SLC Main\] | Branched solution | 3.4.0.10     | \-                |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 3.0.0.x   | \-                      |
| 3.1.0.x   | \-                      |
| 3.2.0.x   | 3.16.0.6366             |
| 3.3.0.x   | 3.16.0.6366 3.16.1.6737 |
| 3.3.1.x   | 3.16.1.6737             |
| 3.4.0.x   | 3.16.1.6737             |
| 3.5.0.x   | 3.16.1.6737             |
| 3.5.1.x   | 3.16.1.6737             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                         | **Exported Components**                               |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------------|-------------------------------------------------------|
| 3.0.0.x   | No                  | \-                      | SLAutomation SLElement: Visio SLProtocol: Data Distribution + Remote Notifies | CEFD ViperSat - Satellite                             |
| 3.1.0.x   | No                  | \-                      | SLAutomation SLElement: Visio SLProtocol: Data Distribution + Remote Notifies | CEFD ViperSat - Satellite CEFD ViperSat - Power Strip |
| 3.2.0.x   | No                  | \-                      | SLAutomation SLElement: Visio SLProtocol: Data Distribution + Remote Notifies | CEFD ViperSat - Satellite CEFD ViperSat - Power Strip |
| 3.3.0.x   | No                  | Yes                     | SLAutomation SLElement: Visio SLProtocol: Data Distribution + Remote Notifies | CEFD ViperSat - Satellite                             |
| 3.3.1.x   | No                  | Yes                     | SLAutomation SLElement: Visio SLProtocol: Data Distribution + Remote Notifies | CEFD ViperSat - Satellite                             |
| 3.4.0.x   | No                  | Yes                     | SLAutomation SLElement: Visio SLProtocol: Data Distribution + Remote Notifies | CEFD ViperSat - Satellite                             |
| 3.5.0.x   | No                  | Yes                     | SLAutomation SLElement: Visio SLProtocol: Data Distribution + Remote Notifies | CEFD ViperSat - Satellite                             |
| 3.5.1.x   | No                  | Yes                     | SLAutomation SLElement: Visio SLProtocol: Data Distribution + Remote Notifies | CEFD ViperSat - Satellite                             |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP of the device.
- **IP port:** The IP port of the device, by default *5150*.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy*.

## How to Use

The **REST**ful interface is used to retrieve and configure the device information via different HTTP methods:

- HTTP GET: Return the current state of a VMS element.
- HTTP PUT: Update the state of a VMS element.
- HTTP POST: Create a new instance of a VMS element.
- HTTP DELETE: Delete a VMS element.

For example, to **retrieve a list of satellites**, an HTTP GET would be issued to *http://vms-server:5150/rf/satellites*. This would return an XML document containing the URLs of each satellite.

A query string appended to the URL, i.e. subset=\*, could be used to request additional details per satellite, or filter the results.

An **HTTP GET request** to the URL *http://vms-server:5150/rf/satellite/1* would return an **XML** document containing the details of the satellite with identifier of 1.

To **modify the satellite**, the document needs to be updated and then sent back to the server via an HTTP PUT request.

To **create a new satellite**, an appropriately formatted document must be created and then posted to the URL *http://vms-server:5150/rf/satellites*. This would construct the new satellite and return the URL to a specific location.

More detailed information about the RESTful interface is available via:

- http://vms-server:5150/doc/rest/guide.html
- http://vms-server:5150/doc/rest/schema.html
