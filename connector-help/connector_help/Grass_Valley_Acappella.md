---
uid: Connector_help_Grass_Valley_Acappella
---

# Grass Valley Acappella

The **Grass Valley Acappella** is a matrix that it is used as a mixed format router, designed for myriad broadcast and production settings, including small studios, sports arenas, and space-constrained environments such as mobile production trucks.

## About

This connector was designed to work with the **Grass Valley Acappella**. It uses smart-serial to read information from the device, plus it allows to monitor and control the video router, for example connecting an output to an input.

### Range of the connector

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.2.4.1                     |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

Serial Connection:

- **IP address/host**: The polling IP of the device *(172.20.19.106).*
- **IP Port:** by default 12345

## Usage

### General

This page contains the **Device Name**, **Protocol Software** and **Software Revision** Parameters. Besides of those, it has a pop up page: *Levels* that displays the **Levels Table**.

### Matrix

It shows a graphical **Matrix** with all the **Inputs** and **Outputs** configured in the router. The connections between **Inputs** and **Outputs** are marked in **black**. It is possible to control the router from this graphical Matrix. To do so, simply click on any of the **crosspoints** and it will automatically connect the corresponding **Output** to the selected **Input**.

### Sources

This page contains the **Sources (Inputs) Table**.

### Destinations

The **Destinations (Outputs) Table** is showed in this page.

### Destinations Status

A Table containing **Output-Input connection** is displayed in this page.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
