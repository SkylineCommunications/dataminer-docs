---
uid: Connector_help_Dantherm_Flexibox_900
---

# Dantherm Flexibox 900

This connector controls the functions of the Dantherm Flexibox 900 device. It can be used to configure cooling, humidity, damper and fan set points and controls, and also allows you to check the status of the device.

## About

This connector displays information that is polled from the device with **SNMP**. Each parameter will be written to the SNMP configuration and must be saved before it is applied to the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.1 \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.54a                       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information on the Flexibox device, such as the network connection information and various serial numbers.

It is also possible to access the **SNMP Configuration** parameters via a page button, as well as **High Level Controls** such as **Cooling/Heater Set Points**.

**Note:** After you configure settings related to the network information, such as **Host Name** or **DHCP State**, press the **Save Configuration** button to accept the changes. The same goes for the **SNMP Configuration** and other configuration pages.

### System Status

This page displays the status of the system. At the top of the page, you can find the **System Temperatures**. The status of each zone, fan and damper can be found in separate boxes below.

Page buttons provide access to specific **Digital Alarms** and **Controller** **Alarms**.

### Cooling Configuration

This page displays the configuration parameters for **Fan 1** and **Fan 2.** After you perform changes on these parameters, press the **Save Configuration** button to make the device accept the changes.

There are also page buttons leading to configuration parameters for the **Heater**, **Humidity**, **Air Conditioners** and **Dampers.** After you perform changes, make sure to press the **Save Configuration** button on the relevant page.

### System Configuration

This page displays system configuration parameters, such as the **Cooling Mode**, **Zone Configuration** and **System Limits**. After you perform changes on these parameters, press the **Save Configuration** button to make the device accept the changes.

The page buttons on this page display configuration parameters for **Night Mode**, **NONC** and **Xzone.** After you perform changes on these parameters, make sure to press the **Save Configuration** button on the relevant page.

### Alarm Configuration

This page displays the **Alarm Configurations** table, which allows you to configure alarm states and their NO/NC values or alarm delays.

If you modify an alarm state, use the **Save Configuration** button afterwards to save the changes to the device. If you change an alarm NO/NC or delay, use the **Save Delay and NONC** button to save the changes to the device.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
