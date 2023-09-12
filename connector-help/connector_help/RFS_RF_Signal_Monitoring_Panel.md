---
uid: Connector_help_RFS_RF_Signal_Monitoring_Panel
---

# RFS RF Signal Monitoring Panel

This connector is used to monitor radio frequencies. An **RFS** (Radio Frequency System) is typically used for monitoring the **RF** status of broadcast antenna and combiner systems. The MS Series 2 supports **SNMP** (simple network management protocol) communication, which enables integration with a high-level **NMS** (network management system).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.0 (Build 0)          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General Page

This page displays parameter information about the **System**, **Forward Power**, **Reflected Power**, and **Return Loss**.

### Input Modules

This page displays parameter information about **Analog Input Module 1 and 2** and the **Analog Input Module 1 and 2 Threshold**.

### Antenna

This page displays parameter information about **Antenna Feeder 1 and 2** as well as **VSWR**.

### Patch Panel

This page displays parameter information about **Patch Panel U-Links**.
