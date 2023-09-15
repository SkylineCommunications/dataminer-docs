---
uid: Connector_help_Pure_Storage_FlashArray
---

# Pure Storage FlashArray

This connector can be used to monitor Pure Storage FlashArray solutions.

## About

The connector uses HTTP requests to obtain the data, according to the architectural style REST (Representational State Transfer) API.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.

## Usage

### General

This page contains general information about the status of the communication with the device and the authentication status.

It also contains the necessary parameters to authenticate and create API sessions.

### Array

This page contains general information about the array attributes, as well as more detailed information in the tables **Array Space Usage** and the **Array Controllers.**

### Alerts

On this page, the **Alerts Table** displays a detailed list of alert events and audit records. In addition, the **Current Alerts Table** displays a list of active alerts.

### Array Performance

This page displays an overview of the array performance, with real-time data, data for the last hour and average data for the last hour.

### Hosts

This page displays different tables with information about the hosts on the array: **Hosts Table**, **Hosts Space Usage** and **Hosts Performance**.

### Host Groups

This page contains three tables with information related to the host groups: **Host Groups**, **Host Groups Space Usage** and **Host Groups Performance**.

### Protection Groups

This page contains information about protection groups and protection group snapshots and their attributes. You can find this information in the following tables: **Protection Groups**, **Protection Groups Space Usage** and **Protection Groups Schedule**.

### Volumes

This page lists volumes and snapshots and their attributes in the **Volumes Table** and **Volumes Space Usage** table.

### Ports

This page contains the **Ports Table**, with all the array ports and the worldwide names assigned to each port.

### Network

The page displays the **Network Interfaces** table, with detailed information about the network interface attributes.

### Hardware

This page includes the **Hardware Components** table, with information about array hardware components that are capable of reporting their status. This information is primarily useful to diagnose hardware-related problems.

### Drive Modules

This page lists flash and NVRAM modules, as well as their attributes, in the **Drive Table**.
