---
uid: Connector_help_CISCO_ISR
---

# CISCO ISR

The **CISCO ISR** will monitor Cisco switches with SNMP.

## About

The **CISCO ISR** connector can retrieve information from different device types with SNMPv2. This is a custom-made connector for Ziggo which will only poll a limited set of parameters.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: not required

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

On this page, an overview of general device settings is displayed, e.g. **Model**, **Software Description**, etc. **Memory Usage** is only calculated when polling of **Memory Details** is enabled.

The **Availability** will show a percentage of the device online time. This value will decrease if the element is in timeout state or was not active. The **Availability - Last Month** shows the availability from the previous month.

The **Memory Details** page button provides access to more specific information. It is possible to *Enable* or *Disable* the polling on this subpage. When it is *Enabled*, memory information will be shown in the table.

In addition, a **Redetect Config** can be performed with the corresponding button. This will remove all non-existing interfaces from the Interface tables.

### Detailed Interface Info page

On this page, the interface info is displayed. You can choose between "*IF Name:IF Custom Description*" and "*IF Custom Description*" by configuring the **Displaykey Format** toggle button. For a new element, the default displaykey is "*IF Name:IF Custom Description*".

Via the **Measurement Config.** page button, you can configure a more detailed interface. Setting the **MCT - Measure Port** to *Disabled* will remove the interface from all interface tables. The row is still polled by SNMP, but no calculations are executed and no trending/alarm monitoring is possible.

Via the **Reset Counters** page button, you can reset all counters (Errors In, Errors Out, Rx Unicast/NUnicast/Discarded Packets, Rx Unknown Protocol, TX Unicast/NUnicast/Discarded packets) of a specific interface or of all interfaces. Setting **Auto Reset Counters** to a specific time period will clear all the counters automatically every day, week or month.

More detailed information about the incoming and outgoing information can be found on the **Detailed Interface Info - Rx** and **Detailed Interface Info - Tx** pages.

### EEM

This page displays information of custom traps (1.3.6.1.4.1.9.\*). Based on the type of trap, the **Alarm** or **Logging Table** will be updated. Custom traps require a fixed format in order to be correctly processed and displayed in the tables.

### BGP

To activate the polling of the BGP data on this page, enable the **Get BGP Data** toggle button.

### IPSLA

To activate the polling of the different IPSLA tables on this page, enable the **Get IPSLA Data** toggle button.

### QoS

To activate the polling of the QoS data on this page, enable the **Get QoS Data** toggle button.

Via the **Measurement Config.** page button, you can configure the different interfaces. Setting the **MCT - Measure QoS** to *Disabled* will remove the interface from the QoS treeview and QoS tables. The row is still polled by SNMP, but no calculations are executed and no trending/alarm monitoring is possible.

The **Refresh** button will poll the the entire tree structure for the QoS. To see the results after you have configured the device, it is advised to click this **Refresh** button and check if the desired interface is enabled for QoS in the **Measurement Configuration Table**.

## Notes

This is a custom-made connector for Ziggo, which will only poll a limited set of parameters because of the high number of elements.
