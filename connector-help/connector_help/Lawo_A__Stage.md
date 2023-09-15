---
uid: Connector_help_Lawo_A__Stage
---

# Lawo A\_\_Stage

The Lawo A\_\_stage device is networked stage box that can be deployed as a gateway for mcý consoles, audio extension for the V\_\_matrix ecosystem, or standalone IP audio gateway.

This connector uses **smart-serial Ember+** communication to poll data from the Lawo A\_\_Stage.

## About

### Version Info

| **Range**            | **Key Features** | **Based On** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart-serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the data pages detailed below. The connector is only intended for monitoring purposes.

### General

This page contains general parameters such as **Company**, **Product**, and **Version**

### Synchronization

This page contains **Configuration**, **Status**, and **Genlock** parameters, as well as **Synchronization Sources**.

### Services

This page contains only **Services** table.

### Interfaces

This page contains interface-related parameters, with the tables **Interfaces**, **Interface Addresses**, and **Interface LLDP**.

### Health

This page contains parameters related to the **Mainboard Fan**, **Mainboard Temperature**, and **Mainboard Voltage**.

### PTP

This page contains parameters related to **Port Configuration**, **Clock Configuration**, and **Clock Status**, as well as the **Port Status** table.

### Warm Start

This page contains **Auto Save Interval** and **Force Coldstart** parameters.
