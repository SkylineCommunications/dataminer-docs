---
uid: Connector_help_ATX_Networks_Transcend
---

# ATX Networks Transcend

This connector is intended for the monitoring of ATX's Transcend platform and its application-specific modules.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.a-5.0                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                    |
|-----------|---------------------|-------------------------|-----------------------|--------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [ATX Networks Transcend - FRXC](xref:Connector_help_ATX_Networks_Transcend_-_FRXC) |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page contains system information parameters, such as the Software Version, Hardware Version, Model Name, and Serial Number.

### Modules

This page contains the **Modules Table**. This table displays all the modules of the device.

### Forward Receiver

This page contains the **Forward Receiver Modules Table** and **Forward Receiver Lasers Table**.

For each module in the Forward Receiver Modules Table,the **Slot State** indicates the status of the DVE, and the **Remove Module** button allows you to delete the DVE.

With the **Forward Receiver Auto Remove** parameter, you can enable or disable the automatic removal of **unequipped** DVE modules.
