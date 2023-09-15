---
uid: Connector_help_Control_By_Web_X400
---

# Control By Web X400

The **Control By Web X400** is a web-enabled programmable logic controller. The modules in the X-4xx series have various combinations of relays, digital inputs, analog inputs, 1-wire bus (for temperature/humidity monitoring), etc. Most of the modules have a fixed number of I/O; however, the X-400 has a ribbon-cable expansion bus, which allows expansion I/O modules to be directly connected to the X-400, making its I/O customizable.

This connector can only be used to monitor information. Traps received will be used to poll the most recent values.

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

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (fixed value: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### SNMP SNMP Connection Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

**Username** and **Password** must be filled in order to retrieve data from the device.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

Once a valid Username and Password have been specified, content is retrieved and shown in the table.

Rows where the Row Status is "*Not available"* can be deleted automatically if the parameter **Removed Not Available Rows** is set to *Auto,* or manually if this parameter is set to *Manual* (default setting). You can remove a row by clicking the **Delete** button.
