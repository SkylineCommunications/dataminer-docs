---
uid: Connector_help_Marlink_Blind_Sector_Platform
---

# Marlink Blind Sector Platform

The **Marlink Blind Sector Platform** is a monitoring platform for iDirect Platform Virtual elements.

## About

This connector retrieves all elements using the iDirect Platform Virtual protocol and monitors a set of coordinate parameters present on these elements.

Via element connections, the GPS coordinates of all remotes are shared between the "iDirect Platform" elements and the "Marlink Blind Sector Platform" element.

Each time a parameter changes, the element will query a web service to check whether it is currently in a blind sector.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: Blind Sector Webservice IP
- **IP port**: by default *443*
- **Bus address**: *bypassproxy*

### Configuration

Create an element connection between the following parameters:

- iDirect Platform: GPS Data XML (PID 4100)
- Marlink Blind Sector Platform: iDirect GPS Data XML (PID 100)

## Usage

### General

This page displays the relevant information concerning the monitored elements in the system.

The parameter **Webservice Response Status Code** indicates the status code from the last attempted HTTP connection.

The **Refresh** button at the bottom of the page allows you to refresh the **Elements Table**.

The **Elements Table** displays the following columns:

- **DmaId/ElementId**
- **Element Name**
- **Installation ID**
- **Latitude**
- **Longitude**
- **Satellite Position**
- **Within Blind Sector** - *Yes* or *No*
