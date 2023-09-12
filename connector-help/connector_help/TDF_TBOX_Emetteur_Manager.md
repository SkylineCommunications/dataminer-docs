---
uid: Connector_help_TDF_TBOX_Emetteur_Manager
---

# TDF TBOX Emetteur Manager

The TDF TBOX Emetteur Manager is a device that allows the management of up to 6 FM transmitters.

## About

### Version Info

| **Range**            | **Key Features**   | **Based on** | **System Impact** |
|----------------------|--------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Management System. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page of this driver, you can find the following parameters:

- **Range OID**: The first OID of the first transmitter in the series of six transmitters. All other OIDs are calculated taking this OID into account. The default value is 51. E.g. if the first OID (for FM1) is 1.3.6.1.4.1.27982.1.7.1.51.0, then the value that should be specified is 51.
- **Code Point de Service**: If this is set to *Normal*, then **?tat Operationnel** will be the same as *Marche/Arrˆt*. If this is set to is *Invers‚,* it will be its inverse.
- **?metteur S‚lectionn‚**: Determines which transmitter information is displayed in the table.
- **Table ?metteur:** Displays the information for the selected transmitter.
- **Refresh Table** button: Updates the displayed values.
