---
uid: Connector_help_Oracle_Database_Node
---

# Oracle Database Node

This is a **serial** connector that is used to monitor and configure the log files of the **Oracle Database Node**.

## About

The information on tables and parameters is retrieved via **Serial SSH** communication.

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

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the Oracle database node.
- **Port:** The polling port for the SSH connection. (Default: *22*)

## Usage

### General

This page displays the following general information:

- **User Information:** Login and password.
- **Automatic Storage Management Information:** Get data, maximum number of entries and log file location.
- **Cluster Information:** Get data, maximum number of entries and log file location.
- **Fan Information:** Get data, maximum number of entries and log file location.
- **Alert AREMA Information:** Get data, maximum number of entries and log file location.

### Resources

This page displays the **Resources** table. This information is retrieved using the command *crsstat*.

### Automatic Storage Management

This page displays the **Automatic Storage Management** table. This table is updated with information included in the specific log file.

### Cluster

This page displays the **Cluster** table. This table is updated with information included in the specific log file.

### Fan

This page displays the **Fan** and **Fan Node** table. These tables are updated with information included in the specific log file.

### Alert AREMA

This page displays the **Alert AREMA** table. This table is updated with information included in the specific log file.
