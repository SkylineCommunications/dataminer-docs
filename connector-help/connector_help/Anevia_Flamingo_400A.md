---
uid: Connector_help_Anevia_Flamingo_400A
---

# Anevia Flamingo 400A

**Anevia Flamingo** streamers are designed to transmit TV and radio channels from DVB sources to an IP network.

With this connector, you can monitor the inputs, services and broadcasts, as well as manage configurations.

## About

The connector uses a **SOAP interface** and was designed using the **Live SOAP API** and the **System API**.

Please check the **Supported firmware versions** table below to select which connector corresponds to the device's software.

Note that certain older versions may not function properly, because there is no backwards compatibility as of API version 2.2.5.

Backward compatibility is not guaranteed between different connector ranges.

### Version Info

| **Range** | **Description**                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. SNMP connector, basic information, support for traps. | No                  | No                      |
| 2.0.0.x          | HTTP version using the element's SOAP interface.                    | No                  | No                      |
| 2.1.0.x          | Support for new firmware SOAP Live 2.5.1.                           | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**      |
|------------------|----------------------------------|
| 1.0.0.x          | N/A                              |
| 2.0.0.x          | Live API 2.3.0, System API 1.2.0 |
| 2.1.0.x          | Live API 2.5.1, System API 1.3.2 |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

- **IP address/host**: The polling IP of the device.
- **Timeout per parameter**: By default: *5000* (5 seconds). Increase this value if you experience problems with the services. For large systems, retrieving the service configuration information can take a while and timeouts can occur, affecting the table presentation. To avoid these timeouts (and retransmissions), increase this value.

### Configuration

To make sure the element works properly, you must configure the web service **user name** and **password** on the **General Settings** page.

On the same page, you may also need to change the **default location** where **configuration files** are exported.

## Usage

### General

This page contains general information about the device, such as the **supported SOAP APIs**.

The **Web Service Status** parameter displays any possible errors returned by the server while polling.
Note: If this status indicates an error, check the log file for details.

### Inputs

This page displays a table with the equipment input. It contains information about the **type** of each input and its current **status**.

It is also possible to modify information for each input.

### Interfaces

This page displays a table with the device interfaces. It contains information about each interface, such as its **type** and its current **status**.

### Services

This page displays a table with the different services. Note that for large systems, retrieving the whole list of services can take some time.

The table displays the status of the **services** and the **programs** that are currently being broadcast.

### Broadcasts

On this page, you can manage the available **broadcasts**. They are displayed in a table, where you can **start**, **stop** and **delete** them.

It is also possible to create a **new broadcast**. To do so, click the **Create Broadcast** page button and fill in the details on the pop-up page.

### CAMs

This page displays a table with the **Conditional Access Modules**. The **name** assigned to the modules is also displayed, and it is possible to assign an **input**.

### Tree Control

This page displays a tree view with the different **inputs**. For these inputs, you can see the **services** **linked to the inputs**, and for each service, you can see the **broadcasts linked to the service**.

### Save/Load Menu

On this page, you can work with the **configuration files**. The following actions are possible: **Export**, **Import**, **Save**, **Clear** and **Load**.

To be able to work with these configuration files, make sure a **default location** has been assigned on the **General Settings** page.

### General Settings

On this page, you can **reboot the server** and configure the basic connector settings. The latter include the **default location** where configuration files are exported and the credentials to access the **SOAP interface**.
