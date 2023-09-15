---
uid: Connector_help_Miteq_DN-WS-14.125
---

# Miteq DN-WS-14.125

The **Miteq DN-WS-14.125** connector monitors and controls the unit through **SNMP**.

## About

The connector polls relevant information from the device every 15 seconds, every 10 minutes or every hour.

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community** **string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. The default value is **private.**

## Usage

This connector has several data display pages:

### General Page

This page displays the **System Contact, System Name, System Password, Firmware Upgrade,** **Telnet Access, Clock**, etc.

The page also has two buttons to **Enable** and **Disable** **Test Faults** and a button to restore **Factory Defaults.**

In addition, the **Network** page button can be used to access a page with relevant network and trap configuration information.

### Alarms Page

This page displays the alarms and faults of the device: **Temperature, Voltage, Current, LO Fault, Power Supply Fault, Fiber Fault**, etc.

### Bands Page

This page displays information regarding the configured band: **Band** **ID, High** and **Low Input Frequency, High** and **Low Output Frequency, LO Frequency, Mute** status, **Attenuation** and **LNA Current.**

### Memory Page

This page displays information regarding the 64 configurable **Memory** slots. To save a new value in the table, first select the **Selected Memory Location** value, and then update the **Attenuation in the Selected Memory Location** value. The **Refresh Memory** button refreshes the values in the **Memory** table.

### Logs Page

This page displays information regarding the **Logs** that are stored on the device. The **Clear Log** button will delete the log files *both* *in DataMiner and on the device.* The **Refresh Log** button will refresh the **Logs** table. Unless one of the buttons is clicked, the table is not updated.

Web Interface Page

This page displays the **web interface** of the device.

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
