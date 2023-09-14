---
uid: Connector_help_Open_Daylight_Controller
---

# Open Daylight Controller

OpenDaylight (ODL) is an open source framework for migrating to an SDN network architecture. It has been deployed in data center, enterprise and carrier networks, supporting a broad range of use cases. OpenDaylight provides the abstraction, programmability, and openness that paves the way towards an intelligent, software-defined infrastructure. The connector is used to send the PUT commands to the HTTP URL of the software, which in turn controls the switches of the OpenFlow in Arista Manager.

## About

The connector communicates through an HTTP protocol.

### Version Info

| **Range** | **Description**                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------|---------------------|-------------------------|
| 0.0.0.x          | Initial version (proof of concept) | No                  | Yes                     |

### Product Info

| **Range** | **Firmware Version** |
|------------------|----------------------|
| 0.0.0.x          | Unknown              |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

## Usage

### General

This page contains the Table ID, Flow ID and Openflow Name parameters, and the XML that is sent to the OpenDaylight software.
