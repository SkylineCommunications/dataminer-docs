---
uid: Connector_help_Evertz_Magnum_SDVN_Router
---

# Evertz Magnum SDVN Router

This connector can be used to control the Magnum application. It allows DataMiner to act as any other router panel connected to the Evertz Magnum application.

## About

### Version Info

| **Range**            | **Key Features**                                                                               | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                                               | \-           | \-                |
| 1.0.2.x              | Replaced IDX on Sources and Destinations. Duplicated global names are supported on the device. | \-           | \-                |
| 1.0.3.x \[SLC Main\] | Use of API calls to reduce Quartz polling. Renamed Counter parameters.                         | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.1.1                  |
| 1.0.2.x   | 1.1.1                  |
| 1.0.3.x   | 1.1.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

#### HTTP Connection

This connection is only used to obtain namesets and salvos. The connector can work without this connection enabled, but it still needs to be configured.

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Configuration

In order to use this connector, it is necessary to also **configure the Magnum application** itself, so that an extra router panel can take control over a certain matrix. Inside the Magnum application, this will translate into a virtual router (with x inputs and y outputs) that will be made available on a certain IP/port. It is these IP/port settings that need to be configured during creation of the DataMiner element using the Evertz Magnum Router connector.

On the **General** page of the element, you need to specify the following parameters: the **Username**, **Password**, **Device**, **Breakaway Mode**, **Number of Audio Channels**, **Operation Mode**, and **View Nameset**.

On the **Quartz** page, the **Profile ID** must be specified.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Contains general parameters such as the **Element Poll Status** number of sources and destinations, as well as **Credentials** for the Rest API, a refresh option, and the **default nameset** that will be used for any crosspoint and destination change. The **Device** parameter allows you to specify which device should be considered in quartz. This is used for the mapping of Quartz ports to namesets.
- **Sources**: Displays the **Sources** table. All the columns in this table are read-only, except for the notes, which can be used for each source.
- **Destinations**: Displays the **Destination** table, where all crosspoint operations can be done. A destination can also be locked or unlocked.
- **Debug**: Can be used for debugging purposes. Contains the HTTP responses, status codes and buffers.
- **Namesets**: Displays a table with the **Namesets**, which are groups of names that can be assigned to reference sources or destinations. You can configure up to 5 namesets to be displayed in the sources and destinations tables.
- **Audit**: Contains the **Audit** and **Messages** tables. The former contains information regarding crosspoints updates, while the latter lists errors returned by the device, for example in case a lock destination fails
