---
uid: Connector_help_Linear_Acoustic_Aero_2000
---

# Linear Acoustic AERO.2000

This is an SNMP connector that shows the status of the different parameters of a Linear Acoustic Aero 2000 System Controller.

The Linear Acoustic AERO.2000 is a 2RU loudness management platform capable of hosting one or two AEROMAXr processing instances (at least one is required) providing real-time adaptive wideband and/or multiband processing including an advanced ITU limiter.

## About

### Version Info

| **Range** | **Key Features**                                                                       | **Based on** | **System Impact** |
|-----------|----------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. Polls SNMP data from the device and reacts to incoming trap messages. | N/A          | N/A               |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.19.85                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **SNMP Version:** The version of the Simple Network Management Protocol to be used for communication with the device.
- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

You can find more information about the data pages of the element below.

### General

This page contains information about the connection status of the device's SNMP internal link. It also contains system information, including the device's model name, software version, and FPGA version.

### Status

This page can be used to quickly gather information about the state of the device. The page is subdivided into the following categories:

- **Hardware**: Displays information about the device's CPU and RAM usage, as well as indicators that show if these resources are overloaded or depleted.
- **Temperature**: Provides temperature readings for the device's CPU and chassis, as well as fan speed measurements. Should the CPU fan fail, or should the CPU or chassis become too hot, that state will be displayed here.
- **Inputs**: Allows you to monitor the status of video and audio inputs, as well as the status of the audio reference.
- **Other**: Displays information about the state of the redundant power supply, as well as the engine status and the state of the Cn 2000.

### Instance

This page displays the various programs that belong to instance 1, as well as the silence state and loudness of each one of these programs.

Should the loudness value fall out of range, the loudness alarm will be shown on this page.

### Traps

This page displays a log of incoming SNMP traps. It also contains settings to configure how these traps should be logged and when they should be removed from the log.
