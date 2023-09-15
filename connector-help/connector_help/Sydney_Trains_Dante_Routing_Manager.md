---
uid: Connector_help_Sydney_Trains_Dante_Routing_Manager
---

# Sydney Trains Dante Routing Manager

The "Sydney Trains Dante Routing Manager" is used to create L3 audio routes and monitors the status of the Rx flows and Tx flows.

## About

A CSV file is used as input and the configuration is being sent to "Delect Oratis IF Dante" connector elements which will then create the routes using the Audinate Dante API.

The route creation status on the Delec Oratis IF Dante elements are being checked every 30sec.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | NA                          |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

The Configuration page button on the L3 Routes Creation Overview page contains a "Config. Folder" and "Config. Filename" parameter that will allow the user to load a configuration csv file using the "Apply Config" button.

The L3 Routes Creation Overview table provides an overview of all the routes retrieved from the configuration csv file and their creation status on the corresponding Delect Oratis IF Dante devices.
