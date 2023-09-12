---
uid: Connector_help_Snell_Wilcox_Sirius_850
---

# Snell Wilcox Sirius 850

This is an SNMP-based connector for the Snell and Wilcox Sirius 850 expandable router. The Sirius 850 is part of the Sirius 800 family of multi-format, expandable, advanced hybrid routers. Currently there are two different controllers in use, each having their own connector range.

## About

### Version Info

| **Range** | **Key Features**                                                                                            | **Based on** | **System Impact** |
|-----------|-------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                                                                                             | \-           | \-                |
| 2.0.0.x   | New firmware. (Obsolete)                                                                                    | 1.0.0.x      | \-                |
| 2.0.1.x   | Matrix object resize. The communication with the **Virtual Matrix connector** is implemented in this range. | 2.0.0.x      | \-                |
| 3.0.0.x   | New firmware.                                                                                               | 2.0.0.6      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2450 controller        |
| 2.0.x.x   | 2463 controller        |
| 3.0.0.x   | 2330 controller        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 3.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.
  *From version 2.0.0.5 onwards, dual-redundant controllers can be dynamically polled.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Device address**: The matrix level to be used, format: *{x}.{y}*, where {x} is the matrix number and {y} the level. The default value is *1.1*. (Only for range 2.x.x.x.)
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### Crosspoints and Matrix

Crosspoints are indicated in the **Routed Source** column. Since this is a numerical value, an additional column is available with the mapped name of that source.

- In range 1.x.x.x, this can be found in the **Outputs** table on the **General** page.
- In ranges 2.x.x.x and 3.x.x.x, this can be found in the **Destinations** table on the page with the same name. Additionally, crosspoints of the designated level are available in the **Matrix** view on a separate page as well.

When multiple levels are configured in the device, you will only be able to set sources of the same level as the destination.

The label tables will always be copied to the matrix labels. When a label is changed on the matrix element, this will not get reflected back and might get overridden later.

### 2450 Controller (range 1.x.x.x)

This range has the following tables available:

- **Inputs**: A combination of **Port**, **Digital Video Input** and **Label** data.
- **Outputs**: A combination of **Port**, **Destination**, **Protection** and **Label** data.
- **Inputs Hidden**
- **Power Supplies**: Alarm state for the power supplies.
- **Fans**: Alarm state for the fans.
- **Parking**
- **PSU Faults**: Boolean values indicating power supply alarms.
- **Fan Faults**: Boolean values indicating power supply alarms.

### 2463 Controller (range 2.x.x.x)

From the **General** page, the following parameter groups or tables are available via page buttons:

- **Default Parking Input:** Enables/disables the use of the default parking input. When enabled, whenever a crosspoint is disconnected, the output will be connected to the default parking input.
- **Serial Table** (COM button): Serial interfaces.
- **Single Controller Table** (COM button): Managed controllers in case of a single controller.
- **XPNT** (XPNT button): XPNT Main and Exp values.
- **Fan Faults Table** (Fan button)
- **PSU Faults Table** (PSU button)

The **Module** page contains a view table with the **Module ID** and **module configuration** data, as well as the **Module Configurations Audio Input Table**.

The **Ports** page contains the **Input Ports Table** and **Output Ports Table**.

**Sources** and **Destinations** are listed on separate pages of the same name. The **Destinations** page contains the **Routed Source Label** column, where you can change crosspoints as mentioned in the "Crosspoints and Matrix" section above.

The **Labels** page has both **Source** and **Destination Labels** of 4 different lengths. The 8-character-length label is the name used in the rest of the connector.

The **Others** page contains the following tables:

- **Parking Table**
- **Routing Table**
- **Level Features Table**
- **Monitor Table**

The **Alarms** page contains the **Alarm Sets Table** and **Alarms Table**.

Finally, the **Configuration** page contains a table with two rows, which allows you to set the polling IP of two redundant controllers. The connector will poll both to see which one is active, and the polling IP of the element will be set to the active controller.

### 2330 Controller (range 3.x.x.x)

From the **General** page, the following parameter groups or tables are available via page buttons:

- **Serial Table** (COM button): Serial interfaces.
- **Single Controller Table** (COM button): Managed controllers in case of a single controller.

**Sources** and **Destinations** are on separate pages of the same name. The **Destinations** page contains the **Routed Source Label** column, where you can change crosspoints as mentioned in the "Crosspoints and Matrix" section above.

The **Labels** page has both **Source** and **Destination Labels** of 4 different lengths. The 8-character-length label is the name used in the rest of the driver.

The **Others** page contains the following tables:

- **Parking Table**
- **Routing Table**
- **Level Features Table**
- **Monitor Table**

The **Alarms** page contains the **Alarm Sets Table** and **Alarms Table**.

The **Configuration** page contains a table with two rows, which allows you to set the polling IP of two redundant controllers. The connector will poll both to see which one is active, and the polling IP of the element will be set to the active controller.

Finally, the **Web Interface** page provides access to the web interface of the device. **Note: the client machine must have access to the device for this page to work.**

## Notes

For the implementation of the Matrix view in the connector, the appropriate matrix level must be selected. However, the tables are not filtered to only contain the rows for the specified level. When multiple levels are available and different elements are made to use those, data will be duplicated. An investigation can be launched to find the optimal solution in that case.
