---
uid: Connector_help_Novotronik_GTS6872
---

# Novotronik GTS6872

The Novotronik GTS6872 is a 2:1 redundant amplifier system designed to ensure continuous operation without disruption of signal transmission. The unit consists of two main RF paths. Both RF paths can be switched to a backup RF path.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The **General** page displays the **Unit Description** and the **System Uptime**.

On the **Settings** page, you can select which route is active (*Main* or *Backup*) for both RF paths. The gain of each path can also be configured.

The **Alarms** page displays multiple alarm parameters: **Internal Temperature**, **Amplifier Status**, etc.
