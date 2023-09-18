---
uid: Connector_help_Tektronix_ECO_8000
---

# Tektronix ECO 8000

The **Tektronix ECO 8000** connector monitors and controls the changeover unit through SNMP.

## About

The connector polls relevant information from the device every 15 seconds, 15 minutes or 1 hour. It receives traps from the device and updates the corresponding values.

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: *161*
- **Get community** **string**: *public*
- **Set community string**: *private*

## Usage

This connector has several data display pages:

### General Page

This page displays the **type**, **hardware** and **software version** of the **system, power supply** and **modules**.

Some general system configuration is possible here: **SPG Input**, **Expansion Port**, **Preferred Power Supply**, **Startup Delay**, **Front Panel Timeout**, **Front Panel Display Contrast**, **LTC Channel Direction**, **Relay Path**, **Watchdog Timer**.

With the **Installation Options** page button, you can view the **Installed Software Options** and **Installed** **Hardware Options** and set the **Option Key**.

### Configuration Page

This page displays the **SNMP** and **Network Configuration** of the device. You can also view and configure the **Email Settings** for reporting**:** **SMTP**, **Login Name** and **Password**, **To** and **From E-mail Address**.

With the **Internal Clock** page button, you can display and set the **Local Time** and **Daylight Savings Schedule**.

### Diagnostics Page

This page displays information regarding the **Main Board Power Supply Voltages**, **Temperature Status**, **Fan Speed**, and **Battery Status**.

Several buttons are available with which you can reset the **Factory Defaults** and set some testing procedures of the device.

### Power Supplies Page

This page displays information regarding **Power Supply 1** and **2**. Four page buttons also provide access to information on all **Voltages** for the four different modules that can be installed.

### Event Reporting Page

This page displays the **Event Reporting** table, which contains an overview of the different event reports that the device is capable of handling, with toggle buttons to enable or disable these.

### Status Page

This page displays the overall status of the device: the status of the frontal **LEDs**, **Time** and **Date** when information was last polled, **Number of Channels, Last Front Panel Button Pressed** and **Status Faults**.

### Trap Monitor Page

This page displays a table with the **Active Alarms Triggered by Traps** and keeps a **Record** **of Past Traps**, containing the last 50 to 100 received traps.

### Channels Page

This page displays the **Channel Configuration** table, where you can view information regarding each active channel in the device, and change some of the channel configuration settings.

### LTC Channels Page

This page displays the **LTC Channel Configuration** table, where you can view information regarding each LTC channel in the device, and change some of the LTC channel configuration settings.

### Web Interface Page

This page displays the **web interface** of the device.

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
