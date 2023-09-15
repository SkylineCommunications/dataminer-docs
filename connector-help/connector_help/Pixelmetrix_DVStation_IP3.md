---
uid: Connector_help_Pixelmetrix_DVStation_IP3
---

# Pixelmetrix DVStation IP3

This is an SNMP-based connector used to monitor and configure the **Pixelmetrix DVStation IP3**. The device settings can be monitored and changed using the **Pixelmetrix DVStation IP3** connector.

## About

The **Pixelmetrix DVStation IP3** provides a monitoring interface to the **Pixelmetrix DVStation IP3** Video Gateway device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.19.30                     |

## Installation and configuration

### Creation

The **Pixelmetrix DVStation IP3** is an **SNMP** connector. The **IP** need to be configured during creation of the **element**.

**SNMP CONNECTION:**

- **IP address/host**: the polling IP of the device eg 10.11.12.13

**SNMP Settings:**

- **Port number**: the port of the connected device, default 161
- **Get community string**: the community string in order to read from the device. The default value is public.
- **Set community string**: the community string in order to set to the device. The default value is private.

## Usage

### General Page

The **General** page displays the general information of the device, for example **Operating State, Used Bandwidth**.

### Slot Overview Page

This page presents a Treeview.

### Stream Table Page

This page presents a table with information regarding the **Streams**.

### Service Table Page

This page presents a table with information regarding the **Services**.

### PID Table Page

This page presents a table with information regarding the **PID**.

### Alarms Page

This page presents a table with information regarding **alarms**. These alarms are extracted from received traps.

On this page, there is a **Trap IP Sources** field where it is possible to specify the allowed SNMP sources and a **Traps Number** field with information about the number of traps that are being stored in the Alarms Table.

There is also one page button called **Configuration** that will open a pop-up page with the following parameters:

- **Alarm Filter Status**: A configurable parameter to enable/disable a filter for displayed alarms.

- **Alarms Max Number**: The maximum number of alarms that can be displayed. This value will only be used if the Alarm Filter is enable.

- **Alarm Clean Up Method**: There are three possible ways to clean up the Alarms Table:

  - Based on the number of rows (option Row Count)
  - Based on the number of time the alarm exists (option Alarm Age)
  - Based on a combination of the both. In this case the check on the 'Row Count' is done first (option Combo)

- **Alarms Clean Up Amount**: The number of oldest alarms removed from the Alarms Table when the maximum has been reached

- **Max Age Alarms**: The maximum age of a alarm allowed in the Alarms Table
