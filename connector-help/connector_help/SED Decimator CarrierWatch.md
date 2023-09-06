---
uid: Connector_help_SED_Decimator_CarrierWatch
---

# SED Decimator CarrierWatch

This driver is used to monitor carrier measurements performed by a **SED Decimator** device. The **SED Decimator** device is a spectum analyzer which perfoms measurements on carriers and can emit SNMP traps when some conditions are met. The **SED Decimator CarrierWatch** element collects those traps and displays them in a table. The element also retireve generic information about the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This driver contains 4 pages.

### General

This page displays general information about the device : **Device Status**, **Up Time**,...

### Measurements

This table displays the carrier measurements performed by the device. This table is only filled by traps.

### SNMP Information

This page displays general information about the SNMP interface.

### SNMP Statistics

This page displays statistics about the SNMP interface.
