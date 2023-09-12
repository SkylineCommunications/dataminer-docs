---
uid: Connector_help_Docker_Platform
---

# Docker Platform

The **Docker Platform** driver allows you to manage containers. A container is standard unit software that packages up code and all its dependencies, so the application runs quickly and reliably from one computing environment to another.

A Docker container image is a lightweight, standalone, executable package of software that includes everything needed to run an application: code, runtime, system tools, system libraries and settings.

Docker Engine is available for both Linux and Windows-based applications.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 18.06.0-ce             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP main connection

The driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. 10.10.10.10
- **IP port**: The IP port of the device, e.g. 2375.

## Usage

The element created with this driver has the following data pages:

- **General**: Displays the **status of the server**, information about the Docker API and general information about the containers, such as the number of **Containers Running** and **Stopped**, **Images** and **Memory Available**.
- **Containers**: Displays a tree view with information about each container. Click a container to view more information about it, such as **Name**, **Status**, **IP Address** and **Memory Swap**. Via a page button, you can also see the **processes** running in a container.
- **Images**: Displays a table with information about images, such as **Repotags**, **Created**, **Size** and **Containers**.
- **Swarm**: Displays a table with information about swarms, such as **Name**, **Version**, **Created At** and **Heartbeat Tick**.
