---
uid: Connector_help_Eaton_IPV70B2
---

# Eaton IPV70B2

The **Eaton IPV70B2-EP1-10L** is a rack-mounted switched power distribution unit (ePDU) designed for datacenters that need remote site management. It provides remote power monitoring for voltage and current. The current is also displayed on a local two-digit current meter. The unit also monitors temperature and humidity.

The Switched ePDUs employ multiple configurations, available in 0U and 2U rack mount, and 42" or 66" vertical lengths. They also provide individual on/off/reboot control of up to 36 receptacles. The control interface can be customized with multiple functions and can send either SNMP traps or email alerts.

## About

This connector contains different pages with information and settings. More detailed information on these can be found in the **Usage** section of this document.

The connector uses the SNMP protocol to communicate with the device. SNMP traps can be retrieved when this is enabled on the device.

### Version Info

| **Range** | **Description** | **DCP Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |

## Installation and Timing

### Creation

This connector uses a Simple Network Management Protocol (**SNMP**) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

### Timing

All data gets retrieved from the device in two ways.

- **Timers**: Regular timer that triggers every 300 seconds.
- **Traps**: When enabled and set up on the chassis, traps can be sent to DataMiner whenever an alarm occurs. The traps are accepted and processed for the ENC1 Card.

## Usage

This connector contains a number of different pages.

### Unit Configuration

This page displays the unit configuration: **Unit Name**, **Time**, **Date**, **VA Logging Interval**, **Inverter Status**, **Unit Temperature**, etc.

There is also a page button that allows you to **manage SNMP** polling for the outlet management section and outlet management sensor values section.

### Network Settings

This page displays information and settings related to the network settings, such as the **IP Address**, **Subnet Mask**, **Gateway**, **Mac Address**, **Web Host** and **Ping**.

### Log Manager Configuration

This page displays information and settings related to unit log events on outlets, temperatures, humidity and contact closure, such as the **Mail Server**, **From Address**, **To Address** and **Frequency** logs are sent.

### Serial Settings

This page displays information and settings related to the serial baud rate transmission.

### Telnet Settings

This page displays telnet settings: **Telnet Port** and **Telnet Interface** availability.

### Outlet Management

This page displays information and settings related to the outlet status and configuration, such as the **Name**, **IP Address**, **Web Link**, **Report Time**, **Behavior Command**.

### SNMP Settings

This page displays settings related to the SNMP traps, such as the **Public/Private Community Name** and **Password**, **Trap IP Address**, and availability. Permissions can be configured via the **SNMP Traps** page button.

### Temperature Sensor

This page displays information and settings related to **Temperature Sensors 1** and **2**, including the thresholds.

### Humidity Sensor

This page displays information and settings related to the **Humidity Sensor**, including the thresholds.

### Contact Closure

This page displays information and settings related to **Contact Closures 1**, **2** and **3**.

### Outlet Sensor

This page displays the configuration of **Outlet Sections 1-6**, **Voltage** and **Current** **Thresholds** and **Control**.

### Current Sensor Values

This page displays a general overview of the **Temperature**, **Humidity** and **Contact Closure State**.

### Current Outlet Sensor Values

This page displays a general overview of each outlet section's **Voltage**, **Current** and **VA** usage, as well as the total values.

### Device Web Page

This page displays the web page of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
