---
uid: Connector_help_Ateme_Titan_Mux
---

# Ateme Titan Mux

## About

Ateme Titan Mux is used to interface with the Multiplexer Processing API and Alarm API to access and manage TitanMux's processing features and Alarms.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.5.11.3-0             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination. For example, http://127.0.0.1:8002/api/v1/mux/inputs
- **IP port**: The IP port of the destination
- **Bus address**: ByPassProxy


### Web Interface

"The web interface is only accessible when the client machine has network access to the product."

## How to Use

On the **General** page of this driver, you can configure the username and password to access the device.

The **Inputs** page contains the basic information about the existing inputs as well as the redundancy and Bitrate information. It also has a toggle button and drop down to automatically/manually remove the obsolete inputs based on the Row Status Column.

The **Inputs Redundancy** page contains redundancy state for all the inputs of the MUX and more details of the primary and secondary IP network source configuration parameters.

The **Inputs Programs** page contains detailed program specific information information and bitrates for each program ID and PID.

The same is applicable to the **Outputs** and **Outputs Programs** page.

The **Active Alarms** page holds the list of active alarms & alarm count and the **History Alarms** page holds the list of full alarms history and history alarm count.
