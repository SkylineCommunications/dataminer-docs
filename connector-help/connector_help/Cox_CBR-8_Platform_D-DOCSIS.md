---
uid: Connector_help_Cox_CBR-8_Platform_D-DOCSIS
---

# Cox CBR-8 Platform D-DOCSIS

The CBR-8 is designed to support distributed-access architectures, remote PHY, DOCSIS 3.0 and 3.1, all video types, and software-defined networking. This connector allows you to collect all the data for the Cisco CBR-8 from KAFKA using the **Generic KAFKA Consumer** along with complementary data from auxiliary connectors, e.g. Smart PHY, Vecima RPM, HP Network Automation, etc. This data is then centralized within the connector and used by DataMiner EPM for aggregation actions.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | 16.12.1z               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. **Default port: 161.**
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### Serial Connection - CLI Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. **Default port: 22.**

### Initialization

Once you have created the element, on the **Configuration** page, enter the **CLI credentials** so the CLI polling can work properly. Once this is done, the element will start regular polling.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

When you first start using this element, navigate to the Configuration page and enter the credentials for the CLI Interface in the CLI Credentials section. This will allow data retrieval from the CLI endpoint to begin. A number of configuration options are available that can change the behavior of the connector.

- **Interface Settings**: Allows you to enable or disable polling from an interface (SNMP, CLI) via a toggle button. You can also specify how frequently the interface should be polled. This section also contains three buttons:

- **Update All:** Polls from both interfaces.
  - **Update Virtual**: Polls from Virtual only.
  - **Update CLI**: Polls from CLI only.

- **Entity Export/Import Settings**: These sections allow the exporting of configuration files and importing of provisioning files. You can:

- **Enable or disable** the exporting and importing feature with toggle buttons (**Entity Export** and **Entity Import**, respectively).
  - Specify the file paths where files can be exported and imported (with the **Entity Export Directory** and **Entity Import Directory**, respectively).
  - Specify whether to export/import to/from a local or remote location via a toggle button (**Entity Export Directory Type** and **Entity Import Directory Type**, respectively). Note that for the remote file handling to work, you must enter the credentials for the system in the **System Credentials** section and enter the path to the remote directory in the **Entity Export** or **Import Directory** parameter. The path must be shared/accessible, or this feature will not work.
  - Start the export or import by clicking the **Apply** button in the relevant section.

- On the **Topics** page, you can configure the Subscription Interval, Timeout Interval and Max Back Poll Interval for each configured topic.

- On the **Topic Settings** page, make sure that the **Topics Import Directory** is set to the export location of the **Skyline CCAP Platform WM**.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the Cox CBR-8 Platform D-DOCSIS connector supports the usage of DCF.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic interfaces

Physical dynamic interfaces:

- DCF interfaces are generated from interfaces with speeds above 10 Mbps.

## Notes

This connector requires specific Correlation rules and Automation scripts for communication with auxiliary connectors such as **Generic KAFKA Consumer**, **Cisco Smart PHY**, **HP Network Automation**, **Vecima RPM**, and **Cox Ceeview Platform**, and EPM connectors such as **Skyline CCAP Platform EPM** and **Skyline CCAP Platform WM**. The Correlation rules and Automation scripts must be configured and enabled in order to get the full functionality of this connector.
