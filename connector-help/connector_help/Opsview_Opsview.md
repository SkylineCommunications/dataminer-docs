---
uid: Connector_help_Opsview_Opsview
---

# Opsview Opsview

This connector can be used to monitor, trend and monitor data from the Opsview platform through MySQL.

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
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the database (MySQL)
  - **IP Port**: default port 3306 is used.

### Configuration of the database settings

On the **Database Settings** page, the **Main Database Name**, **Main Database User** and **Main Database Password** have to be configured to be able to poll the database.
If a backup database is available, you can also configure this on the Database Settings page.

## How to Use

This connector uses **stored procedure** calls to retrieve the data that is stored in **MySQL** from the Opsview platform. No traffic will be displayed in Stream Viewer for the main and child elements.

- On the **Overview** page, all the hosts are displayed in an **overview table**. For each host, the creation of a DVE element can be disabled or enabled. Such an element contains all the information on the different checks performed on that host.
  By default, the DVE export setting is disabled, so that the DMA is not overloaded with DVE creations.
- On the **Hosts** page, you can find the DVE table, which contains all elements for which DVE creation is enabled. To change the DVE creation settings (e.g. to disable a DVE), you first need to change the DVE export setting in the Overview table. This will enable the reflect button. If you click that button for a specific host, the connector will try to remove the relevant DVE.
- The **Database Settings** page is the configuration page for all database settings.

## DVE Reflection

DVE reflection determines how the DVE setup in DataMiner mirrors the actual DVE setup.

In some cases, inconsistencies between the DVE configuration setup and the DataMiner DVE setup can occur, for example when a DVE export rule is enabled or disabled.

#### Overview

The **Overview** table provides an overview of the device configuration and displays the **Reflect Status** that results from the DVE reflection algorithm.

For each host, you can select whether creation of a corresponding DVE is allowed, regardless of other settings.

The **Reflect Status** for each device can be the following:

- *Ok*: The DataMiner setup reflects the device setup.
- *Detected*: The corresponding device type is not supported in the connector.
- *Changed*: The device type has been changed since the last polling.
- *Removed*: The device has been removed since the last polling.
- *Error*: It is not possible to create the corresponding DVE.

#### DVE Configuration Modes

Depending on the selected mode and on the other configuration settings, the DVE reflection algorithm will have a different result.

Three modes are available:

- **Manual (default):**

  - When a new host is added, the corresponding DVE will be created if the configuration settings allow it.

  - When a host is replaced by a host of a different type:

    - The existing DVE will be deleted if the configuration settings allow it.
    - A new DVE will be created if the configuration settings allow it.

  - When a host is removed, the existing DVE will not be deleted.

- **Semi-Automatic:**

  - When a new host is added, the corresponding DVE will be created if the configuration settings allow it.

  - When a host is replaced by a host of a different type:

    - The existing DVE will be deleted
    - A new DVE will be created if the configuration settings allow it.

  - When a host is removed, the existing DVE will not be deleted.

- **Automatic:**

  - When a new host is added, the corresponding DVE will be created if the configuration settings allow it.

  - When a host is replaced by a host of a different type:

    - The existing DVE will be deleted
    - A new DVE will be created if the configuration settings allow it.

  - When a host is removed, the existing DVE will be deleted.

#### DVE Export Settings

The connector contains a table with an overview of all the supported host types.

By changing the **State** for a specific host type, you can determine whether a DVE can be created for this host type.

- *On* (default): DVE creation is allowed for this host type.
- *Off*: DVE creation is not allowed for this host type.
- *NA*: The setting cannot be changed, as it is embedded in the core logic of the connector. This can for instance be because the host type is supported in the connector, but not implemented as a DVE.

#### Reflect (All)

After the configuration of the host is initiated via polling, the DVE reflection algorithm is run.

However, if changes have been implemented, you may want to run the DVE reflection algorithm again without waiting for the timer that controls polling.
In that case, by using the **Reflect** or **Reflect All** buttons, you can run the DVE reflection algorithm for one host or for all detected hosts, respectively.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the Opsview Opsview connector supports the usage of DCF and can only be used on a DMA with **9.0 CU9** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **Inputs/Outputs**: Inputs are created according to **DVE Table (ID:4000).**
