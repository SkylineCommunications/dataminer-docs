---
uid: Connector_help_Amino_A140_STB
---

# Amino A140 STB

With this connector you can configure an **Amino A140** set-top box.

## About

The connector uses a Telnet connection to communicate with the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.1.3-Ax4x-opera10          |

## Installation and configuration

### Creation

#### Main connection

This connector uses a serial (Telnet) connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The IP of the device.
- **IP port**: The IP port of the device, by default *23*.

### Configuration of Telnet connection

After you have created the element, the Telnet credentials need to be configured on the **Configuration** page of the connector.

## Usage

### General

This page displays **general** parameters of the set-top box.

### Audio

This page displays all **audio** configuration parameters of the set-top box.

### Video

This page displays all **video** configuration parameters of the set-top box.

### Browser

This page displays all **browser** configuration parameters of the set-top box.

### Closed Captions

This page displays all **closed caption** and **subtitle** configuration parameters of the set-top box.

### Remote Control

This page displays all **remote control** configuration parameters of the set-top box.

### Net Config

This page displays all **network**-related configuration parameters of the set-top box.

### Sockets

This page displays statical information about the **UDP** and **TCP sockets**.

### Memory/Disk Usage

This page displays the used/available **memory** and **disk space**.

### Running Processes

This page displays all **running processes** on the Amino STB including the state and the **VM Size**.

### Device Log

This page displays the **log file** as present on the device.

### Configuration

On this page, the **Telnet credentials** need to be configured. There is also a parameter that indicates the connection state.
