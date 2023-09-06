---
uid: Connector_help_Dimetis_BOSS_Stream_Viewer
---

# Dimetis BOSS Stream Viewer

BOSS Stream Viewer is a software-based multiviewer monitoring system for Digital Video Broadcasting/Asynchronous Serial Interface (DVB/ASI) and IP. It supports Modulator Interface (T2-MI) for second-generation digital terrestrial TV (DVB-T2) for both ASI and IP.

The Dimetis BOSS Stream Viewer can monitor and analyze SDI streams in cable, satellite-terrestrial networks, compression centers, playout and transmission centers, DVB, OTT, web, remote production and IPTV headends, network operations centers, and IPTV distribution networks.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0.3.3                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General Page

This page has a **Summary** of the **Local** **Controller**.

### BSV Servers Page

This page allows you to configure the **BSV Instances**.

### Services Page

This page details the **Services**, its **Audio** and **Video** **Pids** and their **Status**.

### Configurations Page

This Page contains the existing **Configurations** and their **Status**.
