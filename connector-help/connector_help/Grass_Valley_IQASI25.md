---
uid: Connector_help_Grass_Valley_IQASI25
---

# Grass Valley IQASI25

This driver monitors the activity of the Grass Valley IQASI25 device, an ASI Switch.

## About

### Version Info

| **Range**            | **Key Features** |
|----------------------|------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  |



### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.0.5                  |



### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** |
|-----------|---------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     |



## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: \[The IP port of the destination. (default: *2050*)\]
  - **Bus address**: \[The bus address of the device. (default: *UU.PP (Hex)*)\]

## Usage

### General

This page displays general information about the device, like the product info. It is possible to **Restart** the device and to set the **Default Settings**.

### Status

In this page it is possible to check the status of the **Inputs** and the **GPIs**.

### Setup

Displays the Inputs and GPIO configuration.

### Memories

This page is related with the device Memories.

### Roll Track

In this page it is possible to check the Roll Track information.

### Logging

In this page the user can configure the Logging. There are subpages for specific configurations: **Input 1**, **Input 2,** **Output** and **MIsc.**

### Connection Info

This page displays the configuration status.


