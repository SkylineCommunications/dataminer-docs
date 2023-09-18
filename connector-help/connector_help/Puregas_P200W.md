---
uid: Connector_help_Puregas_P200W
---

# Puregas P200W

With this connector, you can gather and view information from the **Puregas P200W** device, a dehydrator.

## About

The Puregas P200W connector is used to monitor and control a Puregas P200W device. It provides an overview of the different parameters of the device along with its statuses and generated alarms. The connector uses SNMP to retrieve the data from the device. All parameters are polled every 30 seconds.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, *e.g. 10.11.12.13.*
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value in the connector is *public*.
- **Set community string**: The community string used when setting values on the device. The default value in the connector is *private*.

## Usage

### General page

On this page, you can find general information, such as the **Model** **Number**, the **Current** **Firmware** **Version** and **Device** **ID**, several statuses and values. There is also a **Network Setup** page button.

The statuses that are displayed on this page can be found below, along with their possible values.

- Online Status: *on* or *off*
- Shutdown Status: *shutdown* or *no* *shutdown*
- Open Circuit Status: *open* *circuit* or *closed* *circuit*
- Humidity Transducer Status: *connected* or *disconnected*
- Compressor Status: *on* or *off*
- Inlet Solenoid Status: *on* or *off*
- Outlet Solenoid 1 Status: *on* or *off*
- Outlet Solenoid 2 Status: *on* or *off*
- Evaporator Heater Status: *on* or *off*

The **Pressure**, **Humidity**, **Cabinet** **Temperature** and **Duty** **Cycle** are also displayed.

In the **Network** pop-up window, the network setup can be configured. The **IP** **Address**, **Subnet** **Mask**, **Gateway** **Address**, **SNMP** **Trap** **Server** **Address** and **Current** **Date/Time** can be set.

### Towers page

This page provides an overview of the parameters concerning the two towers. For both towers these parameters are the **Temperature**, the **Transducer Status**, the **Heater Status** and the global **Status:**

- The temperature is displayed in øF.
- The transducer statuses can be either '*Connected*' or '*Disconnected*'.
- The heater status is either '*On*' or '*Off*'.
- The global statuses can have eight values: '*In Use*', '*Ready*', '*Regenerating*', '*Initializing*', '*Waiting*', '*Heater Failure*', '*Overheating*' and '*Failure to Cool*'.

### Alarms page

This page displays the seven alarms: **High and Low Pressure**, **High and Low Cabinet Temperature**, **High Humidity**, **High Duty Cycle** and the **Alarm Status**. The parameters can either have the value '*Ok*' or '*Alarm*'.

With the **Reset Alarm** button, the alarms can be reset.

With the second button on this page, the **Alarm Setup** page button, the **Thresholds** window can be opened. In this window, the alarm setup can be configured. There are eight different thresholds: **High and Low** **Pressure** **Limit**, **High and Low Pressure**, **High and Low Cabinet Temperature**, **High Humidity** and **High Duty Cycle**. PSI is the unit for the pressure, degrees Fahrenheit for the temperature and percentages are used for the humidity and duty cycle.

### Traps page

On this page, the **Alarm Traps** table is displayed. It has nine columns: one for the trap **indexes**, one for the **date and time** the trap was received and seven for the **seven alarms**.

It is possible specify the maximum number of traps to be displayed in the table, and to delete a specified number of traps or all of the traps from the table.

### Web Interface

This page provides access to the web interface provided by the device's web server. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
