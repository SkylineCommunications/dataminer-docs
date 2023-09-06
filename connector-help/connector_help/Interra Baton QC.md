---
uid: Connector_help_Interra_Baton_QC
---

# Interra Baton QC

The **Interra Baton QC** is a Quality Control Server for media content. It allows the user to create tasks to verify, modify, and archive media content, and it is especially useful for content-providing networks, such as TV networks. The tasks can involve, for example, checking for pixelization issues in a video.

## About

This connector allows DataMiner to communicate with the Baton QC server and obtain information on the tasks associated with the Baton QC server. This includes information on tasks with the following status: *Created*, *In Queue*, *In Progress*, *Finished,* and *Archived*. The connector also allows alarm monitoring of several parameters.

**HTTP / SOAP** requests are used to retrieve information from the device.

### Version Info

| **Range** | **Description**                                                                                                                                          | **DCF Integration** | **Cassandra Compliant** |
|-----------|----------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version Not all the attributes for each task are currently being used/pulled. Only the ones common to all the task types are used at the moment. | No                  | Yes                     |
| 1.1.0.x   | New firmware version.                                                                                                                                    | No                  | Yes                     |
| 1.1.1.x   | "Completion Time" column mismatch fixed.                                                                                                                 | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware**   |
|-----------|--------------------------|
| 1.0.0.x   | 5.5.0 Enterprise Edition |
| 1.1.0.x   | 6.4.0 Enterprise Edition |
| 1.1.1.x   | \-                       |

## Configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration of Username and Password

In order to work with the server, first go to the **Login** page and add the username and password for the Interra Baton QC. Otherwise, no HTTP requests will be accepted by the server.

## Usage

### Login

On this page, you can find the Interra Baton QC **version information**, and you can specify the **username** and **password** for the server the connector is connecting to.

### Tasks Overview

This page is intended to provide an overview. It contains a table with all the tasks in the system and most of the attributes available for them.

### Recent Tasks

This page displays the recent tasks in the system. Tasks that have not been archived are displayed here.

### Tasks in Queue

This page displays the tasks waiting to be executed by a Checker. All tasks shown here will still be incomplete.

### Tasks In Progress

This page shows the tasks currently being run by a Checker. These tasks will already have a Checker assigned, and their progress will be more than 0 %.

### Finished Tasks

The tasks shown on this page have been fully checked and have finished either successfully or with errors.

### Archived Tasks

This page shows the tasks that have been archived by the system.

### Webpage

This page allows you to access the Interra Baton QC web interface to configure tasks, plans, and profiles.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Note

From range 1.1.0.x onwards, you can find search criteria as well as the date and task limit on the Recent Tasks, Tasks in Queue, Tasks in Progress, Finished Tasks, and Archive Tasks pages.

Because of server limitations with respect to processing power and resource consumption, the Baton Server recommendations advise requesting 50 to 100 tasks at a time. These parameters control the maximum number of tasks that can be retrieved, for which the limit is 3000.
