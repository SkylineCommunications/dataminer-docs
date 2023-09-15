---
uid: Connector_help_Dayang_Playout_Server
---

# Dayang Playout Server

This connector is used to monitor a Dayang playout server.

## About

**Dayang VIPS (Video Ingest Playout Server)** can be used as a 4In, 1In/3Out, 2 In/2Out, 3In/1Out, and 4Out playout server, with channels that can be configured independently. VIPS-2H-4XHD offers operators complete media control as an ingest server, multi-channel server, delay server and back-up server. Dayang VIPS is mainly used for HD/SD ingest systems, studio systems and on-air systems.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### VIPS

This page displays **System**, **Hardware**, **VA Interface**, **Storage** and **Alert** parameters.

At the bottom of the page, in the section **Alert Set Thresholds**, thresholds for the parameters **Network Data**, **Storage** and **Runtime** can be set.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
