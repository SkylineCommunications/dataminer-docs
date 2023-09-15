---
uid: Connector_help_Elemental_Conductor_-_Elemental_Conductor_Node
---

# Elemental Conductor - Elemental Conductor Node

The **Elemental Conductor** is a video **encoder** network management system for live video delivery applications, offering comprehensive monitoring of video encoding. This connector represents one node in this system.

## About

This connector is exported by the [Elemental Conductor](xref:Connector_help_Elemental_Conductor) connector.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.0.1.x          | Version 2.6                 |
| 1.1.0.x          | Version 3                   |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the [Elemental Conductor](xref:Connector_help_Elemental_Conductor) connector.

## Usage

### General (since version 1.1.0.2)

This page displays general information about a node: **ID**, **Hostname**, **IP Address**, **Status**, **Product Name**, **Version**, **Channels**, **Inflight Channels**, **MPTS**, **Alerts**, **Messages**, **Redundancy Group ID** and **Authentication User**.

### Overview Page

The **Overview tree view** on this page contains the linking from all the tables to the **Nodes** table, resulting in one major tree view, where you can select data for each node such as **Channels**, **Channel Outputs**, **Channel Parameters**, **Alerts** and **Messages**.

### Channels

This page displays the **Channel** and **Channel Output Tables**, with the channels that exist on the current node. It also contains the **Channel Parameters** page button, which displays the **Channel Parameters Table**.

### Alerts

This page contains the **Alert Table**, with alert entries related to the current node.

### Messages

This page contains the **Message Table**, with message entries of the current node.
