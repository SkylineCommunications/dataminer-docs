---
uid: Connector_help_Evertz_EQT-1616
---

# Evertz EQT-1616

This protocol has been made for an **Evertz EQT-1616** device. The EQT is a routing solution for mission-critical applications.

## About

This protocol helps the user to monitor the Evertz EQT-1616 device and to configure all the right inputs and outputs, so an efficient way to configure every parameter is provided. The protocol contains a matrix.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### General

This page displays general information, such as the **Description** of the device, the **Standard** of the used **Serial Ports** and the used **Standard Reference.** It also displays status information, such as the **Status of the Power Supplies**, **Temperature** and **Video Input Standard**.

On the right-hand side, information is displayed about the **inputs** and the **output**, along with the **Reclocker** status of the possible connection points. The **Output Table** section can be used to enable or disable the possible output connections. The **Reclocker table** can be used to **activate or deactivate the Reclocker** for a specific connection point.

### Matrix

On this page, you can **connect the input stream with a specific output channel**. An output can only be configured with one input channel, but an input can have more output channels if wanted. An input can be empty (not connected to an output), but an output has to be connected to one or more inputs.

The size of this **matrix** is linked to the **number of connection points** mentioned in the input and output (General page).

### WebInterface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
