---
uid: Connector_help_Electrosys_G011_FM_N+1
---

# Electrosys G011 FM N+1

The Electrosys G011 FM N+1 can be used to monitor transmitters via a transmitter controller. This connector uses SNMP to connect to the transmitter controller.

For each monitored transmitter, a DVE can be created.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                             |
|-----------|---------------------|-------------------------|-----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Electrosys G011 FM N+1 - Main Transmitter<br>[Electrosys G011 FM N+1 - Reserve Transmitter](xref:Connector_help_Electrosys_G011_FM_N%2B1_-_Reserve_Transmitter) |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Initialization

This protocol supports both MIB versions, which have slightly different OIDs. In some cases \*.1.\* is used, while in the other cases \*.255.\* is used in the OID. The connector will automatically try and select the correct OID when a new element is created.

First it will try to poll a parameter using the \*.1.\* OID. If this fails, it will switch to \*.255.\*. If both fail, by default, the connector will only retry further with \*.255.\*. However, you can configure this using the **Device OID** parameter on the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How To Use

The element consists of the following data pages:

- **General**: Contains general system information and system commands.

- **Main Transmitters**: Shows information for all the main transmitters installed on the machine. Also contains a page button to the Main DVE page.

- **Main DVE Page**: Shows the DVE table for the main transmitters. You can enable or disable all DVEs for the main transmitters here.

- **Reserve Transmitters**: Shows information for the reserve transmitters installed on the machine. Also contains a page button to the Reserve DVE page.

- **Reserve DVE Page**: Shows the DVE table for the reserve transmitters. You can enable or disable all DVEs for the reserve transmitters here.
