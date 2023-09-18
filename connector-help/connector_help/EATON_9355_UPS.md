---
uid: Connector_help_EATON_9355_UPS
---

# EATON 9355 UPS

This connector is used to retrieve status information from a three-phase power protection solution and to configure operating voltages and currents.

## About

The communication is done through **SNMP**.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device (e.g. *161*).
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

## Usage

### Main View

This page displays general information: **Battery Status, Time on Battery, Line x Output Load**, etc.

### General

This page displays information about the device, such as the **Description, Up Time, Location, UPS Manufacturer, UPS Software Version**, etc.

The **UPS Settings** page button displays configuration parameters for, among others, **shutdown**, **startup** or **reboot** operations.

### Input

This page contains important data regarding the inputs: **Input Out-of-Tolerance** count, **Input Frequency**, **Line x Input Voltage, Nominal Input Voltage/Frequency, Low/High Voltage Transfer Point**.

### Output

This page displays information about the outputs: the state of the **Output Source**, the **Output Frequency**, **Line x Output Voltage/Load**, **Line x Output Current/Power, Nominal Output Voltage/Frequency**, **Nominal Output Volt-Amp/Power**.

### Bypass

On this page, you can find the **Bypass Frequency** and the **Line x Bypass Voltage**.

### Battery

This page displays monitoring information about the battery, such as the **Battery Status, Time on Battery, Charge Remaining, Battery Voltage/Current**, etc.

### UPS Test

On this page, you can select a type of test procedure with the parameter **Test ID**. With the **Test Result (Summary)** parameter, you can obtain the result of the test (once it is completed or if there were warnings or errors). With the **Test Result (Details)** parameter, you can retrieve details about the test procedure. The **Test Start Time** and **Test Elapsed Time** show the starting time and elapsed time of the test procedure.

### Alarms

This page shows the number of alarms (**UPS Alarms Present**) and different alarm states (**Low Battery, Depleted Battery, Temperature, Fuse Failure, Communication Lost, Shutdown Imminent**, ...).

### Web Interface

This page displays the web interface of the device.

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
