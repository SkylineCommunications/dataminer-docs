---
uid: Connector_help_Omnitronix_SL10
---

# Omnitronix SL10

The Omnitronix SL10 device is intended to retrieve monitoring information from devices that are non-networked or that do not implement SNMP.
Moreover, there is a pass-through allowing communication with a connected serial device.

## About

This connector retrieves status information from the Omnitronix SL10 device and is also able to configure the SNMP connection and alarm management through SNMP.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation::

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *192.168.1.2*.
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device, e.g. *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

### Configuration of the LITE functionality

It is possible to enable the LITE functionality, so that only the most important parameters are polled. As soon as you disable LITE, polling of all parameters will be resumed.

To enable LITE functionality, go to the **Network Settings** page, and enable the parameter **LITE PROTOCOL**.

## Usage

### General

On this page, you can find common information such as the **Serial Number**, **Firmware Version**, **Site ID**, **SNMP Manager** IP addresses, **Traps** configuration, etc.

There are several page buttons on the page:

- With the **Temperature Sensor** page button, the **Temperature Value** can be monitored. You can also enable the **Temperature Alarm** and set the different alarm thresholds and the associated severity levels.
- The **Humidity Sensor** page button is used to monitor the **Humidity Value** and set alarm thresholds and associated severities.
- The **Passthrough** page button shows different configuration parameters for communication with an attached serial device. Some of the configurable parameters are the **Passthrough** **Username**, **Passthrough Esc Char**, **Passthrough Serial Baudrate**, **Passthrough** **Serial Parity**, ...
- With the **FTP Server** page button, you can configure the **FTP Username** and **FTP Password**.
- The **Techsupport** page button shows the network configuration to access the Omnitronix SL10 device via the element (**Techsupport IP Address**,**Techsupport NetMask**, **Techsupport Router**, etc.).

### Contacts

On this page, you can configure the contact information retrieval. You can, for example, set the **Contact Active Direction** (*Alarm On Open* or *Alarm On Closed*). The **Contact Configured State** column produces an alarm based on the actual **Contact State** and the configured **Contact Active Direction**.

You can enable the **Contact Alarm**, define a time delay before trap sending (**Contact Threshold**), and specify if a trap must be sent when the contact is returned to the normal state. Finally, you can also set an interval between alarm trap repetitions and the severity associated with the contact alarm.

### Network Settings

This page contains the **Lite Protocol** toggle button (see "Configuration of the LITE functionality" section above).
