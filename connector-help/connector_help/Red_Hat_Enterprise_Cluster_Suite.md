---
uid: Connector_help_Red_Hat_Enterprise_Cluster_Suite
---

# Red Hat Enterprise Cluster Suite

Red Hat Cluster Suite (RHCS) is an integrated set of software components that can be deployed in a variety of configurations for performance, high availability, load balancing, scalability and file sharing. This connector monitors the components related to this cluster suite.

## About

This connector uses SNMP in order to monitor a cluster and its nodes.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                       |
|------------------|---------------------------------------------------|
| 1.0.0.x          | MIB Version: 2 Cluster Configuration Version: 133 |

## Installation and creation

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays general information regarding the Linux OS hosting the cluster suite:

- **System info**
- **Total Processor Load**: Only available if **Poll Task Manager** is enabled (on the Task Manager page).

### Cluster Info

This page displays general information about the cluster, cluster nodes and its services.

### Task Manager

On this page, you can enable **Poll Task Manager** in order to retrieve all the data from the **Task Manager Table**. This table displays all the processes running on the Linux OS hosting the cluster suite.

### Network Info

This page displays all interfaces and data metrics.

### Memory Info

This page displays the memory info from the Linux OS hosting the cluster suite. This information is displayed in the **Storage Table**.

### Devices Info

This page displays a list of all devices contained in the cluster.

The following page buttons are available:

- **Disk IO**: Displays disk IO information.
- **File System**: Displays file system information.
- **Partitions**: Displays partition information.
- **Processor Load**: Displays information about processor load.

### HP

This page displays general **HP server**-related information.

The following page buttons allow access to additional **HP** info:

- **Fan**
- **Power Supply**
- **Temperature**
- **Memory**
- **CPU**
- **Disk**
