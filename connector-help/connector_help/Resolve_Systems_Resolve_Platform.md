---
uid: Connector_help_Resolve_Systems_Resolve_Platform
---

# Resolve Systems Resolve Platform

The **Resolve Platform** connector is an interface for the Resolve Systems Resolve Platform web service that keeps track of the commands and replies that are executed.

## About

**SOAP calls** are used to retrieve the device information. An **HTTPS** **connection** is required to send commands and retrieve responses.

The protocol is used together with an Automation script, which receives a string with the following format: **protocol/DMA id/Element id/Param id**. The Automation script is expected to set Parameter ID 200 (with name "Send") with a string that complies with the following format: **RB0x01Name=Value0x01Name=Value0x01Name=Value...** In this string, "(char)1" is the separator. The first name and value must be Id=(ID number), where the value -1 will create an automatically generated ID. The second name and value must be WIKI = runbook (e.g. *LG.Test runbook*). The rest of the name and values are parameters that can be used in the runbook command.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.2.1 (20160126)            |

## Installation and configuration

### Creation

#### HTTPS main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTPS CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, *https://...*
- **IP port**: *8080*
- **Bus address**: *ByPassProxy*

## Usage

### Saved Scripts

This page contains the **Saved Runbook Script** table, which can be used to execute, add, delete and edit a script.

You can export this table by right-clicking it, selecting Other, and then selecting the export option. To make sure the import function can find the CSV file for import, make sure you save the export in the folder **C:\Skyline DataMiner\Documents\Resolve Systems Resolve Platform**. You can import a CSV file via the button at the bottom.

### Overview

This page displays a **tree view** with the processed runbooks and with the results if they are completed.

### Logging

This page displays 2 tables:

- **Runbook**: Displays the runbook requests and indicates whether they are still being processed or whether they are done.
- **Runbook Results**: Displays the result from the runbook request. The results will only be in the table when the runbook is completed.

### Configuration

This page contains parameters that can be used to configure the element, such as the **username** and **password**. The latter need to be filled in before you can send a **SOAP** command.

The page also displays the **Number of Runbook Entries Saved** and **Number of Runbook Entries Saved Date**. These parameters can be used to **limit the number runbooks** that are in the database and table. Both parameters can be used at the same time.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
