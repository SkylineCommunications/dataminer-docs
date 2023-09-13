---
uid: Connector_help_Grass_Valley_IQAMD40
---

# Grass Valley IQAMD40

This driver allows you to set up and manage the IQMIX40 multi-channel video-over-IP transceiver, developed for use within low-latency and high-bandwidth Ethernet IP networks.

## About

### Version Info

| **Range**            | **Key Features**                                                       | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                       | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Reworked backend. Works with initial polling and unsolicited messages. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *2050*).
  - **Bus address**: The bus address of the device. Specify the bus address in the following format: **UU.PP**, with UU being the rollnet address and PP being the slot number (chassis is 00), e.g. **10.00**.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element created with this driver has the following data pages:

- **General**: Shows the Display, Temperatures and Voltages of the device.
- **Connection Info:** Shows the status of the connection with the device.
- **Configuration**: Contains the general configuration of the device.
- **Ethernet 1**
- **Ethernet 1 RTP**
- **Ethernet 1 RTP Receiver**
- **Ethernet 2**
- **Ethernet 2 RTP**
- **Ethernet 2 RTP Receiver**
- **RollCall IP**
- **Logging Misc**
- **Logging Network**
- **Logging Spigot**
- **RollTrack**
- **Recall Memory**
