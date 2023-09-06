---
uid: Connector_help_Open_Broadcast_Systems_C_Series_Encoder
---

# Open Broadcast Systems C Series Encoder

The OBE C-100 and C-200 encoder support high-quality, low-latency news, sports and channel contribution.

This driver uses an SNMP connection to monitor the OBE C-100 and C-200 encoder devices.

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

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following pages:

- **General**: Allows you to specify **which device** (C-100 or C-200) you are connected with. Also displays general system information.
- **Dashboard**: Displays a tree view that shows the content of the other pages in a **tree structure** for increased accessibility.
- **Alerts**: Displays the **traps** sent by the selected device.
- **Encoder**: Contains a table listing all the encoders available in the device.
- **Input/Video/Audio/Ancillary Data/Multiplexing/Output**: These pages display the collected information in table format. Each row is directly related to one encoder from the Encoder table.
