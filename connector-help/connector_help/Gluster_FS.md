---
uid: Connector_help_Gluster_FS
---

# GlusterFS

**Gluster** is a free, open-source, scalable network file system.

## About

Gluster runs in a **Linux** environment. There is no API; communication takes place via the command shell available under Linux.

The connection to the server is made via **SSH** (username/password).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: By default: *ByPassProxy*.

### Configuration

In order for the connector to communicate with the system, the **SSH** username and password must be filled in on the **Settings** page.

## Usage

### Peer Status

This page displays the **Peer Status Table**, which lists the **Peer Name**, **Cluster State** and **Connection State** for each of the peers.

### Overview

This page displays a **tree view** with the relations between the **volumes** and the **bricks.
**For each brick, you can see information such as the **State**, **TCP Port**, **File System** and **Total** and **Free Disk Space**.

### Snapshots

This page displays the **name** and **UUID of the last snapshot**, and shows whether **polling of the snapshot status** is enabled.
It also displays a table with several **snapshots**, the **Volume Group**, **Brick Status**, **Brick PID**, **Data Percentage** and **Logical Volume Size**.

### Settings

This page allows you to change the **SSH Username** and **SSH Password** used to communicate with the system.
