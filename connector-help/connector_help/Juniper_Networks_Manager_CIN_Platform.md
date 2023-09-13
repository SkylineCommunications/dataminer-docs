---
uid: Connector_help_Juniper_Networks_Manager_CIN_Platform
---

# Juniper Networks Manager CIN Platform

This is an SNMP-based driver used to monitor and configure the Juniper Networks Manager. It allows you to monitor and change the device settings. The driver also uses an SSH connection to change the interface state of some ports. The data collected is centralized within the driver and used by DataMiner EPM for aggregation actions.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                       |
|-----------|----------------------------------------------|
| 1.0.0.x   | JUNOS Base OS Software Suite \[18.3R2-S3.1\] |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. (default: *161*)

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
  - **Set community string**: The community string used when setting values on the device (default: *private*).

#### Serial SSH Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *22*).

### Initialization

Once you have created the element, on the Configuration page, enter the CLI/Serial credentials so the CLI polling can work properly. Once this is done, the element will start regular polling.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On creation of an element using this protocol, you must navigate to the Configuration page and enter the credentials for the CLI Interface in the section titled CLI Credentials. This will allow the protocol to start retrieving data from the CLI endpoint.

The protocol has several configuration options that will change its behavior:

- **Interface Settings**: With these settings, you can **enable/disable polling** **from an interface (SNMP, CLI)** and also configure the **frequency** of the polling. This section also contains four buttons:

- **Update All:** Polls from all interfaces.
  - **Update SNMP**: Polls from SNMP only.
  - **Update CLI**: Polls from CLI only.
  - **Update Virtual**: Polls Virtual Custom table data.

- **Entity Export/Import Settings:** These settings handle the **export of** **configuration files** and **import of provisioning files**. You can:

- **Enable/disable** the export and import feature with the **Entity Export** and **Entity Import** toggle button, respectively.
  - Specify the **path** where files will be exported and imported, with the **Entity Export Directory** and **Entity Import Directory** parameters, respectively.
  - Switch between exporting/importing to a **local or remote location** by using the toggle button **Entity Export Directory Type** or **Entity Import Directory Type**, respectively.
    Note that for the remote file handling feature to work, you must enter the credentials for the system in the **System Credentials** section and enter the path to the remote directory in the **Entity Export/Import Directory** parameter. The **path** **must be shared/accessible**.

- Perform an export or import by clicking the **Apply** button in the relevant section.

This driver depends on Correlation rules and Automation scripts for communication with auxiliary drivers such as HP Network Automation and EPM drivers such as Skyline CCAP Platform EPM and Skyline CCAP Platform WM. To get the full functionality of this driver, make sure these Correlation rules and Automation scripts are configured and enabled.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Juniper Networks Manager CIN Platform protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic interfaces

Physical dynamic interfaces:

- DCF Interfaces are generated from interfaces with speeds above 10 Mbps.
