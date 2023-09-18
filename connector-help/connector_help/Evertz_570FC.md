---
uid: Connector_help_Evertz_570FC
---

# Evertz 570FC

This connector can be used to monitor and control the **Evertz 570FC** frame controller.

## About

### Version Info

| **Range**            | **Key Features** | **Based On** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                              |
|-----------|-------------------------------------------------------------------------------------|
| 1.0.0.x   | Kernel Major Release: 5.1 Software Build: 1.5 Build 87 Software Build: 1.5 Build 61 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element created with this connector has several data pages:

- The **General** page displays the uptime, ID, name, and location of the system.
- On the **Product Location, Hardware, Hardware LED, Software, Proxy Configuration** and **Time Management** pages you can find various tables with information and settings related to these subjects.
- The **SNMP Traps** and **Traps Management** pages display tables where you can add/remove traps destination as well as read/change the state and value of traps.
