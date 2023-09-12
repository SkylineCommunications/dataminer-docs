---
uid: Connector_help_CISCO_Manager_CIN_Platform
---

# CISCO Manager CIN Platform

With the CISCO Manager CIN Platform it is possible to configure and monitor CISCO switches, for example, the CISCO Catalyst 3750. The CISCO Manager CIN Platform driver can retrieve information from different device types. This data is then centralized within the driver and used by DataMiner EPM for aggregation actions.

## About

### Version Info

| **Range**            | **Key Features**             | **Based on** | **System Impact** |
|----------------------|------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.             | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Updated Temperature section. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.3.3                  |
| 1.0.1.x   | 6.3.3                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. **Default port 161.**
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### Serial Connection - CLI Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. **Default port 22.**
  - **Bus address**: The bus address of the device.

### Initialization

Once you have created the element, on the Configuration page, enter the CLI/Serial credentials so the CLI polling can work properly. Once this is done, the element will start regular polling.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

When you have created an element using this driver, first make sure credentials for the CLI interface are specified in the CLI Credentials section of the Configuration page. This allows the driver to retrieve data from the CLI endpoint.

The following configuration options allow you to change the behavior of the driver:

- **Interface Settings**: This allows you to enable or disable polling from an interface (SNMP, CLI) via a toggle button. You can also specify how frequently the interface should be polled.
  This section also contains the following buttons:

- **Update All:** Polls from both interfaces.
  - **Update SNMP**: Polls from SNMP only.
  - **Update CLI**: Polls from CLI only.
  - **Update Virtual**: Polls Virtual Custom table data.

- **Entity Export/Import Settings**: These sections allow the exporting of configuration files and importing of provisioning files. You can:

- **Enable or disable** the exporting and importing feature with toggle buttons (Entity Export and Entity Import, respectively).
  - Specify the **file paths** where files can be exported and imported (with the Entity Export Directory and Entity Import Directory, respectively).
  - Specify whether to export/import to/from a **local or remote** location via a toggle button (Entity Export Directory Type and Entity Import Directory Type, respectively). Note that for the remote file handling to work, you must enter the credentials for the system in the System Credentials section and enter the path to the remote directory in the Entity Export or Import Directory parameter. The path must be shared/accessible, or this feature will not work.
  - Start the export or import by clicking the **Apply** button in the relevant section.

## Notes

This driver requires specific **Correlation rules and Automation scripts** for communication with auxiliary drivers such as **HP Network Automation**, and EPM drivers such as **Skyline CCAP Platform EPM** and **Skyline CCAP Platform WM**. The Correlation rules and Automation scripts must be configured and enabled in order to get the full functionality of this driver.

With larger devices/large datasets, the **polling performance** may vary. You can control the number of rows and cells requested for larger tables by navigating to the Configuration page and enabling debug in the other settings section. This will make the debug page visible, where you can then change SNMP Cell Amount and SNMP Row Amount to a value that works optimally for your system. Increasing these values can cause polling issues such as RTEs and missing data, so be careful and always double-check to make sure the system is stable.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the CISCO Manager CIN Platform protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Dynamic interfaces

Physical dynamic interfaces:

- DCF Interfaces are generated from interfaces with speeds above 10 Mbps.
