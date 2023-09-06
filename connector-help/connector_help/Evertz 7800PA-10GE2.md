---
uid: Connector_help_Evertz_7800PA-10GE2
---

# Evertz 7800PA-10GE2

The 7800PA-10GE2 is an integrated switch fabric that leverages 1GbE signaling, necessary for video LAN/WAN transport applications.

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

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page, you can find the **Control Network** and **Product Features** Table, as well as buttons to set the **Card Alias**, **Reboot**,and perform a **Factory Reset**.

On the **Ports** page, you can find the **Port Config, Status**,and **Bandwidth Tables.** The **Port Count** is also displayed on this page.

The **SFP** page displays the global SFP parameters.
