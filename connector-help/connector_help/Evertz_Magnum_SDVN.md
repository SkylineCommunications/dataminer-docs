---
uid: Connector_help_Evertz_Magnum_SDVN
---

# Evertz Magnum SDVN

This connector can be used to control the Magnum application. It allows DataMiner to act as any other router panel connected to the Evertz Magnum application.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.1.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

In order to use this connector, it is necessary to also **configure the Magnum application** itself, so that an extra router panel can take control over a certain matrix. Inside the Magnum application this will translate into a virtual router (with x inputs and y outputs) that will be made available on a certain IP/port. It is these IP/port settings that need to be configured during creation of the DataMiner element using this connector.

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

#### HTTP "HTTP Connection" Connection

This HTTP connection is only used to obtain namesets and salvos. While the connector can work if this connection is not enabled, the connection does always need to be configured during element creation.

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Displays general parameters such as the **Element Poll Status** and the number of sources and destinations. Also allows you to configure the **credentials** for the Rest API and select the **default nameset** that will be used for crosspoint and destination changes. A refresh button allows you to trigger an update of the displayed data.
- **Sources**: Contains the Sources table. In this table, only the notes are configurable; all other columns are read-only.
- **Destinations**: Contains the Destinations table. All crosspoint operations are done from this table. A destination can also be locked or unlocked here.
- **Debug**: Used for debugging purposes. Contains the HTTP reponses, status codes and buffers.
- **Namesets**: Contains a table with the namesets, which are groups of names that can be assigned to reference a source or destination. From here you can configure up to 5 namesets to appear in the sources and destination tables.
- **Audit**: Contains the Audit table, which displays information regarding crosspoints updates. Also contains the Messages table, which lists errors returned by the device, for example in case a lock destination fails.
- **Salvos**: Displays a table with all the configured salvos. A button allows you to trigger these.
