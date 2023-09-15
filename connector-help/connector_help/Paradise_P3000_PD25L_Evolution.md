---
uid: Connector_help_Paradise_P3000_PD25L_Evolution
---

# Paradise P3000 PD25L Evolution

This connector can be used to control and monitor the Paradise P3000 PD25L Evolution device.

## About

This connector uses SNMP to poll and control all values of the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.x          | 1.5.28                      |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device
- **Set community string**: The community string used when setting values on the device

## Usage

### Status

This page contains info on the status of the device.

### Unit

This page contains general info about the device.

### Tx Configuration

This page contains the important configurable parameters of the transmitter.

### Rx Configuration

This page contains the important configurable parameters of the receiver.

### Monitor

This page displays the measured values of the device.

### Test

This page contains all configurable parameters for testing.

### Memories

This page allows you to save, recall and delete configurations.

To perform save, recall and delete commands, the DMA must be logged on to the PUP protocol. For details on how to log on, refer to the "PUP Manager" section below.

To be able to save a configuration, the **Save Configuration File Name** must be specified.

This page also contains a toggle button that can be used to enable or disable the use of a recall delay when the recall button of a specific configuration is clicked. If this is enabled, the recall will only occur after the time defined in the **Recall Delay** parameter.

### PUP Manager

On this page, you can log in by specifying the **Administrator Password** defined for the UI and clicking **Log In**. This action is required to allow interaction with the configuration memory management.

The page also displays the incoming response from a **PUP command request.**

### Web Interface

The web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
