---
uid: Connector_help_PixipNet_XOS
---

# PixipNet XOS

PixipNet is an end-to-end active testing solution. It can be used to perform test scenarios (monitors) from an end user's perspective.

This connector receives traps sent by the PixipNet solution and displays the information on the different monitors, including the alarm level and KPI/KQI value.

## About

### Version Info

| **Range**            | **Key Features**                              | **Based on** | **System Impact**                                                                                                                                                                                                                       |
|----------------------|-----------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                              | \-           | \-                                                                                                                                                                                                                                      |
| 1.0.1.x \[SLC Main\] | Monitor IDs are unique in the Monitors table. | 1.0.0.2      | \- Loss of alarm and trend data for both Monitor tables. - The export/import monitors feature does not work correctly if applied across the different ranges, e.g. when a 1.0.0.x monitor export file is imported to a 1.0.1.x element. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                            |
|-----------|---------------------|-------------------------|-----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \- [PixipNet XOS - Location](xref:Connector_help_PixipNet_XOS_-_Location) - [PixipNet XOS - Test Type](xref:Connector_help_PixipNet_XOS_-_Test_Type) |
| 1.0.1.x   | No                  | Yes                     | \-                    | \- [PixipNet XOS - Location](xref:Connector_help_PixipNet_XOS_-_Location) - [PixipNet XOS - Test Type](xref:Connector_help_PixipNet_XOS_-_Test_Type) |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP of the trap sender device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

You can **create monitors** by setting a **location** and/or **test type** on the received traps displayed on the **General** page.

The possible values for location and test types can be configured manually or imported from a .csv file on the **Configuration** **page** (one column only).

A **Dynamic Virtual Element (DVE)** will be created for every distinct **location** or **test type**, listing all monitors under it.

You can delete DVEs and monitors with the **Delete** button in the respective tables.
