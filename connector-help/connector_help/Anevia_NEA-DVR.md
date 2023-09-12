---
uid: Connector_help_Anevia_NEA-DVR
---

# Anevia NEA-DVR

The Anevia NEA-DVR handles all the packaging, streaming and recording to prepare and deliver cloud DVR, catch-up, time-shifted and live channels to a range of targeted devices such as smartphones, tablets, personal computers and set-top boxes, according to distribution policy.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page contains general information about the device, such as **System Description**, **Uptime**, **Contact**, **Name**, **Location**, **API** **Version**, **Failover** **Status**, etc.

It also contains a page button that opens the **Authentication** page where the **HTTP credentials** can be defined.

### Interfaces

This page contains the **Interfaces** table, where information about each interface of the device is displayed.

### Assets

This page displays the **Assets** table, where information about each asset is displayed, as well as the **total number of VOD**, **live** and **nPVR assets**.

### VOD

This page contains the **VOD TTL** metric, the **VOD Jobs** and the **VOD Assets** tables, where information about each VOD job and asset is displayed, respectively.

### Live

This page contains the **Live TTL** metric and the **Live Channels** table, where information about each live channel asset is displayed.

### nPVR

This page displays the **nPVR Assets TTL** metric, and the **nPVRs** table, where information about each nPVR asset of the DVR is displayed.

### Stream Adaptations

This page contains the **Stream Adaptation Families** and the **Stream Adaptations** tables, where information about each stream adaptation family and each stream adaptation is displayed, respectively.

### Scrambling Servers

This page contains the **Scrambling Servers** table, where information about each server is displayed.
