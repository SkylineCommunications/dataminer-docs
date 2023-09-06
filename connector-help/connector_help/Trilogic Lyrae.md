---
uid: Connector_help_Trilogic_Lyrae
---



# Trilogic Lyrae

This connector can be used to monitor the Trilogic Lyrae probe.

## About

### Version Info

| **Range**            | **Key Features**                                                                            | **Based on** | **System Impact**                                                                                                        |
|----------------------|---------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version. Communication happens through port 8000.                                   | \-           | \-                                                                                                                       |
| 1.1.0.x \[SLC Main\] | Communication now happens using the Lyrae REST API through the default HTTP port (port 80). | 1.0.0.2      | The description of parameters 2301 and 2302 has changed. All templates, scripts, and Visio drawings need to be reviewed. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0.15.0 0.21.2          |
| 1.1.0.x   | 0.31.0 0.36.3          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP.
- **IP port**: 80

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

This connector consists of the following pages:

- **General**: Displays the **Version** of the device, the **Start Time** of the device and **Licenses** information.
- **Overview**: Displays the sources and streams of the probes in a tree control.
- **Sources**: Lists the sources in the **Sources Table**.
- **Streams**: Lists the streams in the **Streams Table**. In case of an audio stream, audio channels are listed in the **Audio Channels Table**.
- **Alarms**: Lists the alarms retrieved from the device.
