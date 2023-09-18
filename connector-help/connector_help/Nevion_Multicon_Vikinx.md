---
uid: Connector_help_Nevion_Multicon_Vikinx
---

# Nevion Multicon Vikinx

The Multicon provides fully integrated state-of-the-art element management and system control capabilities for Flashlink and VikinX systems. It supports a wide range of applications, ranging from optical network monitoring and configuration to controlling live media networking.

## About

A Nevion Multicon system can have multiple Vikinx routers. Each router has a unique 'level' in the system. To get the information of these routers, the main IP of the Multicon system is polled. This connector populates one matrix for a specific router in the system, which can then be used to set the input and output crosspoints in the system.

The router used to populate the matrix is determined by the device address value that is specified during element creation.

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device Address**: The device address determines which device you will be polling from. A complete list of the available devices and their device addresses can be found on any created element on the **Level Table** page.

## Usage

### Matrix

This page contains a graphical matrix with all the inputs and outputs configured in the router. The connections between inputs and outputs are marked in black.

It is possible to control the router from this graphical matrix. To do so, simply click any of the crosspoints, and the corresponding output and input will automatically be connected.

### Level Table

On this page, you can find the parameter that determines which router you populate the matrix from (default value is 1).

Below this, a table displays the routers that are currently connected to the device. The bus address for each device is the first value in the **Label** column of the table. For example, if the label is "*21.RouterType*", the bus address for router RouterType is 21.
