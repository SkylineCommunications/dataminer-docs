---
uid: Connector_help_Teleste_HDM100
---

# Teleste HDM100

The Teleste HDM100 module communicates with HFC network transponders via its RF modem, maintains a list of transponder statuses, manages the data link, and provides connectivity between element/network management system and transponders.

This connector allows you to interface with various modules. For an overview of the supported modules, refer to the "System Info" section below.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|--|--|--|--|
| 1.0.0.x | Initial version | \- | \- |
| 2.0.0.x \[SLC Main\] | Removed DVE generation. Instead the controller will generate standalone elements for connected modules. | \- | Most of the existing parameters are still available, but parameter IDs have changed. Existing alarm and trend templates will no longer work. New elements should be created when upgrading from 1.0.0.x to this range. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 2.0.0.x   | 1.36                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|--|--|--|--|--|
| 1.0.0.x | No | No | \- | \- [Teleste HDM100 - AC8000](/Driver%20Help/Teleste%20HDM100%20-%20AC8000.aspx) <br/>- [Teleste HDM100 - AC3200](/Driver%20Help/Teleste%20HDM100%20-%20AC3200.aspx) <br/>- [Teleste HDM100 - AC3000](/Driver%20Help/Teleste%20HDM100%20-%20AC3000.aspx) <br/>- [Teleste HDM100 - AC8810](/Driver%20Help/Teleste%20HDM100%20-%20AC8810.aspx) <br/>- [Teleste HDM100 - AC8800](xref:Connector_help_Teleste_HDM100_-_AC8800) |
| 2.0.0.x | No | Yes | \- [Teleste AC8810](/Driver%20Help/Teleste%20AC8810.aspx) <br/>- [Teleste AC8000](/Driver%20Help/Teleste%20AC8000.aspx) <br/>- Teleste AC8710 | \- |

## Configuration

### Connections

#### Serial Connection - Main (1.0.0.x and 2.0.0.x)

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. Default value: *2500*.

Communication from this connection can be seen in the Stream Viewer.

#### Serial Connection - Module Polling (1.0.0.x only)

This connector has a second connection that cannot be configured manually. It is used to poll every connected node on a regular basis using a round-robin mechanism. Communication from this connection can be seen in the Stream Viewer.

### Initialization

A configuration file can optionally be linked to the element from the **Configuration** page. This configuration file should be a semicolon-delimited .csv file with the following headers: "ip address", "name", and "view name". This file should be available in the Documents folder for the Teleste HDM100 connector. The values from this file will be used in the HFC devices table and during element generation.

On the **Module Overview** page, there are several parameters that specify when elements should be generated. By default, elements will be generated for nodes that are not part of the config file, elements will not be generated if they are not part of the same subnet as the controller, and missing modules will not be removed automatically.

### Redundancy

No redundancy is defined in the connector.

## How to Use

### 1.0.0.x

The element created with this connector consists of the following data pages:

- **General**: Displays general parameter information, such as the **Rack Number**, etc. The **Alarm Limits** page button displays the general alarm limits.
- **Module Overview:** Displays information on the active modules. Each subpage is specific to an installed/supported module, for which a DVE is exported.
- **Modem**: Displays modem information.
- **Settings**: Contains page buttons to the **Accepted Device Groups** subpage, which contains device group settings, and the **Clustering Settings** subpage, where you can configure the **Master Tx** parameter.
- **Interfaces**: Displays the available interfaces.
- **ONU Spectrum Monitoring**: Provides spectrum monitoring.
- **RF**: Contains radio frequency info and settings.
- **Station**: Contains station info and settings.
- **Alarm Limits AC8000/AC8810/AC8800**: These pages display the alarm limits tables for the Teleste AC8000, AC8810, and AC8800, respectively.

### 2.0.0.x

The most important parameters for monitoring can be found on the **General**, **Alarm Limits**, and **Module Overview** (HFC Devices table) pages.

Every 2 minutes, the connector will retrieve the connected nodes from the HDM100 controller. All connected nodes are displayed in the HFC Devices table. When a new node is discovered, the configuration file will be checked for its presence. Depending on the settings and the type of node, a new element will be created. The connector searches for a compatible connector (set to production) in the system and uses this to create the new element. If no compatible connector is found, the element creation status of the node will be set to *Fail* in the HFC Devices table.

#### Managing Generated Module Elements

By selecting and right-clicking modules in the HFC Device table, you can easily start, stop, or restart module elements that were generated by this connector.

#### Trend and Alarm Templates

On the Templates page, you can define the default alarm and trend templates for every supported module type. Whenever a new module gets connected, the configured templates will be assigned to its linked element in DataMiner. By selecting and right-clicking a module in the HFC overview table, you can overwrite the currently assigned alarm or trend template with the configured one.

**NOTE**: If **no template** is defined, this action will **cause the templates to be unassigned** from the selected module elements.

#### Main Element Property

Every element generated by this connector will have the Main Element property. This property contains the name of the controller element and gets updated every time the modules get polled from the controller. So if you change the name of the controller element, you will need to wait until the next module poll cycle before the property gets updated with the correct value.
