---
uid: Connector_help_Snell_Wilcox_Sirius_850_Dual_Frame
---

# Snell Wilcox Sirius 850 Dual Frame

This is an SNMP-based connector for the Snell and Wilcox Sirius 850 expandable router. The Sirius 850 is part of the Sirius 800 family of multi-format, expandable, advanced hybrid routers. Currently there are two different controllers in use, each having their own connector range. This connector has two frames. Each frame has a defined number of inputs and outputs.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2463 controller        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP connection - SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Device address**: The matrix level to be used, in the format: *{x}.{y}*, where {x} is the matrix number and {y} the level. The default value is *1.1*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### SNMP connection - SNMP Connection - Second

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Device address**: The matrix level to be used, in the format: *{x}.{y}*, where {x} is the matrix number and {y} the level. The default value is *1.1*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

**Sources** and **Destinations** are listed on separate pages of the same name. On the **Destinations** page, crosspoints are indicated in the **Routed Source** column. Since this is a numerical value, an additional column is available with the mapped name of that source. The Destinations table combines two hidden SNMP tables for each frame. Crosspoints of the designated level are also available in the **Matrix** view on a separate page.

Note: When multiple levels are configured in the device, you will only be able to set sources of the same level as the destination.

From the **General** page, the following parameter groups or tables are available via page buttons:

- **Default Parking Input:** Enables/disables the use of the default parking input. When this is enabled, whenever a crosspoint is disconnected, the output will be connected to the default parking input.
- **Serial Table** (COM button): Serial interfaces.
- **Single Controller Table** (COM button): Managed controllers in case of a single controller.
- **XPNT** (XPNT button): XPNT Main and Exp values.
- **Fan Faults Table** (Fan button)
- **PSU Faults Table** (PSU button)

The **Module** page contains a view table with the **Module ID** and **module configuration** data, as well as the **Module Configurations Audio Input Table**.

The **Ports** page contains the **Input Ports Table** and **Output Ports Table**.

The **Labels** page has both **Source** and **Destination Labels** of 4 different lengths. The 8-character-length label is the name used in the rest of the connector. The label tables will always be copied to the matrix labels. When a label is changed on the matrix element, this will not get reflected back and might get overridden later.

The **Others** page contains the following tables:

- **Parking Table**
- **Routing Table**
- **Level Features Table**
- **Monitor Table**

The **Alarms** page contains the **Alarm Sets Table** and **Alarms Table**.

Finally, the **Configuration** page contains a table with two rows, which allows you to set the polling IP of two redundant controllers. The connector will poll both to see which one is active, and the polling IP of the element will be set to the active controller.

## Notes

For the implementation of the Matrix view in the connector, the appropriate matrix level must be selected. However, the tables are not filtered to only contain the rows for the specified level. When multiple levels are available and different elements are made to use those, data will be duplicated. An investigation can be launched to find the optimal solution in that case.
