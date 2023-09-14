---
uid: Connector_help_Gamatronic_Power+_SA
---

# Gamatronic Power+ SA

The Gamatronic Power+ SA is used to control and manage a standalone online double-conversion UPS.

With this connector, trending and alarm monitoring are available on a lot of important parameters.

## About

This device is used to monitor the status of power supplies.

All the data is polled by SNMP. All parameters from the web interface are available in the connector, except the configuration tab, which is not included because of missing MIB.

## Installation and configuration

### Creation

This is an SNMP connector. The IP has to be configured during creation of the element.

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.11.12.13*

**SNMP Settings:**

- **Port Number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### Main Page

This page contains all general information related to the device, such as **System Name**, **Manufacturer**, **Battery Type**, **Model ID**, **Software Version**, etc.

There is also an overview of the **Active** and **Apparent Load Level** on *Line 1*, *Line 2* and *Line 3*.

In addition to these overview parameters, the **System Voltage** and **DC Voltage** (Pos., Neg. and Tot.) are also displayed.

### Analysis Page

This page contains an **Input Table** and an **Output Table**. These tables have information about each line (Input or Output). Monitoring and trending are possible for parameters such as **Voltage**, **Current**, **Apparent Power**, **Active Power** and **Power Factor**.

There are also four Summary parameters for Apparent and Active Power for the Input and Output.

### Modules Page

On this page, a tree control shows all the modules. For each module, information is displayed, such as **Input** and **Output Voltages**, **Currents**, **Module DC Voltages** and **Frequency**.

To each module, a Module Status row is linked, which displays all status parameters that have alarm monitoring enabled.

There is also a page button, **Module Table**, which displays the **Module Table** and **Module Status Table**. which hold all data from the tree control.

### STSW Page

On this page, you can see all **Static Switch** parameters. On the left, values are displayed for the Inverter and Bypass Voltages and Frequency for Line 1, Line 2 and Line 3.

On the right, status parameters that have monitoring enabled are displayed.

### Log Page

On this page, you can see a **Log Table** that holds all logs polled by SNMP. Each log has a timestamp.

The page also displays an **Alarm Table** with all possible alarms, and a column indicating if an alarm is present or not. This column has monitoring enabled.

### Control Page

This page contains several control buttons. The following settings can be configured: **Load On Bypass**, **Load On Inverter**, **Start Battery Test**, **Abort Battery Test**, **Led Test**, **Shutdown**, **Startup** and **Restart**.
