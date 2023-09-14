---
uid: Connector_help_Racktivity_Energy_Switch_ES6124-16
---

# Racktivity Energy Switch ES6124-16

Racktivity's power distribution energy switch provides advanced metering and switching power capability, as well as real-time remote true PDU-level and outlet-level RMS monitoring of current (A), voltage (V), power (VA, W), power factor (%) and energy consumption (kWh).

## About

This protocol can be used to monitor and control any Racktivity Energy Switch ES6124-16. An **SNMP** connection is used in order to successfully retrieve and configure the settings of the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.0.3.4                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page provides general status information, including the System Name, Device Name, Rack Name, Rack Position, Description, System Object ID and System Up time. For some of these parameters, the value can be adjusted on this page.

### Power General

This page contains the **Overview table**, which provides a general overview of **Current**, **Power**, **Power Factor** and **Energy**.

It also contains the **Voltage/Frequency Total** **by** **Module table**, with quick information on the total frequency and voltage per module.

The following page buttons lead to subpages with additional information and settings:

- **Agent:** Displays the **Agent Table**, with information about Ports, Agent status and Agent IP.
- **Fuse:** Displays three different tables, i.e. the **Line**, **Line Current** and **Fuse table**, with information on the current and the status per fuse. Also allows you to set the thresholds and warnings.
- **Scheduler:** Displays the **Scheduler Table**, which contains information about the port name, the port state and the port on and off time, and allows you to enable or disable ports by outlet.
- **Energy:** Displays the **Energy Table**, which contains the outlets names, Port State, Active Energy, Resettable Active Energy, reset buttons, Apparent Energy and Resettable Apparent Energy. This provides an overview of the complete energy status of the device, along with the possibility to set changes to the relevant parameters.
- **Power:** Displays the **Power Table**, with the columns Port State, Actual Power, Min Power, Max Power, Reset Values, Power Warning, Switch Off, Apparent, etc.
  Note that **minimum and maximum values are calculated by the connector itself**. Because of this, it is strongly recommended to **reset the values of the device when the connector starts**.
- **Current:** Displays the **Current Table**, which allows you to set thresholds for the currents, view maximum and minimum values, and set the Current Off value.

### Environment

This page contains the **Ambient Table** and **Electrical Table**.

These provide an overview of the environmental parameters, including the temperature and RMS voltage. Information about minimum and maximum values is also displayed.

### E2 Sensors

This page contains information about the E2 sensors, including the **E2 Temperature**, **E2 Humidity** and **E2 Motion** tables, which also show an overview of the lowest and highest values.

In the **E2 Analog Table**, you can find information (including minimum and maximum values) for the analog input. In the **E2 Digital Table**, you can find this same information for the digital port.

The **E2 Management Table** contains information about the **Firmware Version** and **IUD.**

Note that **minimum and maximum values are calculated by the connector itself**. Because of this, it is strongly recommended to **reset the values of the device when the connector starts.**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
