---
uid: Connector_help_Microsoft_SharePoint
---

# Microsoft SharePoint

This protocol receives commands from other protocol elements and stablish a communication with Microsoft SharePoint services. At this point it executes the GetList and GetListItems functions. It is meant for communication with Skyline DCP and Intranet.

## About

The connector receives the commands on a parameter. This command will be parsed and placed in a table. The commands in the table will be executed with FIFO order. Once a command has been executed a response will be sent back to the element that sent the command. In the case there is a communication failure with the services the corresponding response will be sent to inform the situation.

SOAP is used for the communication.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: Default ByPassProxy

## Usage

## General

This page displays a table with the current pending commands. Each row will identify the DAM, Element and parameter to which the response must be sent. The table also contains per row the function to be executed and the possible configurations for that function as number of elements to retrieve and fields to retrieve. This page also contains a page button for the credentials configuration. Username and Password. Will be used in the communication with SharePoint.

## Settings

This page allows to set the connection credentials: Username and Password. In order to connect properly with the service, it is required to specify the SharePoint Host. It is also possible to specify the service subdirectory. The "\[/subdirectory\]/\_vti_bin/Lists.asmx" will be automatically appended to the IP address/host of the element.
