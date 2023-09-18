---
uid: Connector_help_Eaton_SC200
---

# EATON SC200

The SC200 System Controller is an advanced control and monitoring solution for the Eaton Enterprise, Access, Metro, and Core Solutions.

## About

The Eaton SC200 connector can be used to monitor and control an Eaton SC200 device. **SNMP** is used to communicate with the device. The information of the device is displayed on multiple pages, similar to the way it is displayed on the web interface of the device.

### Version Info

| **Range**            | **Key Features**                                                                            | **Based on** | **System Impact**                                                                                                                                                     |
|----------------------|---------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                                             | N/A          | \-                                                                                                                                                                    |
| 1.0.1.x \[Obsolete\] | \- Added trap receiver for OID 1.3.6.1.4.1.1918.2.13.20.\* - Changed decimals in parameters | 1.0.0.x      | \- Possible loss of external sets because of description changes in parameters 5003, 5103, 30044 and 30055. - Change in parameter Interprete type for parameter 3006. |
| 2.0.0.x \[SLC Main\] | Connector rebranded                                                                         | 1.0.1.x      | \- Possible issue with case-sensitive code that uses the connector name                                                                                               |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | 4.04                   |
| 2.0.0.x   | 4.04                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device, e.g. 10.11.12.13.
- **IP port**: The port of the connected device, by default 161

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

- **System**: Displays general information about the device.

- **Identity**: Also displays general information about the device, such as the **Serial Number**, **Manufacturer Name**, **MAC Address**, **System Type**, **Location**, and **Name**.

- **Communication - Physical Ports**: Allows you to view and modify physical port parameters. In the **Serial** group box, three page buttons are available that will each open a pop-up page with additional information.

- **Communication - Remote Access Protocols**: Allows you to view and modify parameters related to **S3P**, **SNMP**, **HTTP**, **Email**, **Serial** **Server**, and **Modbus**. Several page buttons provide access to additional information.

- **Time**: Allows you to view and modify the clock and SNTP parameters.

- **Alarms**: Displays the different alarms in the **Alarm Table**. The **Alarm** **Configuration** group box contains alarm parameters that can be modified. Two buttons are also available:

- **Reset** **Failed** **Alarm**: Resets the battery test failed alarm.
  - **Reset** **Rectifier** **Comms** **Lost** **Alarm**: Resets the rectifier comms lost alarm.

- **Smart Alarms**: Contains four tables with data that can be both viewed and modified.

- **Analog Inputs**: Displays information regarding the Analog Input. In the **Analog Input Table** at the bottom of the page, several parameters can be modified.

- **Digital Inputs - Digital Outputs**: These page display information about digital inputs and outputs. In the tables on these pages, some parameters can be modified.

- **Active Voltage Control**: Allows you to enable or disable active voltage control and displays information related to this feature.

- **Temperature Compensation**: Allows you to configure the temperature compensation.

- **Equalize**: Allows you to configure parameters related to the equalization process.

- **Fast Charge**: Allows you to configure the fast charging of the batteries.

- **BCL**: Allows you to view information and modify settings related to the **Battery Current Limit**.

- **Battery Test**: Displays multiple parameters with battery information and allows you to configure test parameters. With the **Reset Failed Alarm** button, you can reset the battery test failed alarm.

- **LVD**: Displays the **Logical** **LVDs** **Table** and **Physical** **Contactors** **Table**. In both tables, values can be modified.

- **Generator Control**: Allows you to view information and modify settings related to the generator.

- **Rectifiers**: Allows you to view information and modify settings related to the rectifiers. A page button will open a subpage with additional information. The following two buttons are also available:

- **Restart All**: Restarts all rectifiers.
  - **Reset Run Time**: Resets the runtime.

- **Batteries**: Allows you to view information and modify settings related to the batteries. Three buttons are available:

- **Reset Battery State**: Resets the state of the battery.
  - **Characterize**: Characterizes the battery.
  - **Clear String Fail**: Clears the string fail.
