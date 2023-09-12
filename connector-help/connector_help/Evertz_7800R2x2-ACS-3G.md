---
uid: Connector_help_Evertz_7800R2x2-ACS-3G
---

# Evertz 7800R2x2-ACS-3G

This connector allows you to manage the Evertz 7800R2x2-ACS-3G card. It communicates using SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**       |
|-----------|------------------------------|
| 1.0.0.x   | VLProProd_R2X2-ACS Version 6 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The card slot.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to Use

This connector uses SNMP to retrieve information from the card. It displays the information on the pages and allows you to perform changes to it.

The Faults polling is initially disabled. If you enable it, the Faults Polling Configuration table allows you to select which sections will be retrieved.
