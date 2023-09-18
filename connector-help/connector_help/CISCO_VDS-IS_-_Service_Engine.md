---
uid: Connector_help_CISCO_VDS-IS_-_Service_Engine
---

# CISCO VDS-IS - Service Engine

The Service Engine is a device type in the **Cisco VDS-IS Management System**.

## About

This is an **HTTP** connector. It is automatically exported by the parent connector **CISCO VDS-IS**.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 4.2.1                       |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [CISCO VDS-IS](xref:Connector_help_CISCO_VDS-IS), from version 1.0.1.1 onwards.

## Usage

### General

This page contains general information about the device, such as the **ID**, **Name**, **Type**, **Model**, **Primary IP**, **Status**, **Local Disks** and **Software Version**.

### Statistics

This page displays the following statistics:

- **CPU Utilization**
- **Bandwidth Served**: **HTTP**, **Windows Media**, **Movie Streamer** and **Flash Media**.
- **Bandwidth Efficiency Gain**: **In**, **Out** and **Efficiency Gain**.
- **Streaming Session**: **Windows Media Unicast**, **Windows Media Multicast**, **Movie Streamer Unicast** and **Flash Media Unicast**.

These statistics are retrieved every 5 minutes, as this is the minimum time frame during which the device holds statistical data. The current values are therefore an average calculated by the device based on the last 5 minutes.

### Delivery Services

The page contains the **Delivery Service Table**, which displays information like **Content Acquirer**, **Basic Authentication**, **Encryption**, **Local Manifest ID**, **Manifest URL**, **Content Origin ID**, **Content Provider ID**, **Origin FQDN**, etc.
