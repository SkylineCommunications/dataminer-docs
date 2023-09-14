---
uid: Connector_help_Schneider_Electric_StruxureWare_-_Device
---

# Schneider Electric StruxureWare - Device

This connector is exported from the [Schneider Electric StruxureWare](xref:Connector_help_Schneider_Electric_StruxureWare) parent connector. It provides specific monitoring information for each device.

The connector was designed to interact with a SOAP interface. An HTTP connection is used to successfully retrieve the API information.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**               |
|-----------|--------------------------------------|
| 1.0.0.x   | StruxureWare Data Center Expert v7.2 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

This connector is used by DVEs that are **automatically created** by the parent element. No user input is required.

## How to use

The element consists of the following data pages:

- **Device Info**: Displays general information such as the Device Name, Device IP and Device Serial Number.
- **Alarms Info**: Displays a table listing all active alarms related to the device.
- **Sensors Info**: Displays a table with all the information related to the sensors in the device.
