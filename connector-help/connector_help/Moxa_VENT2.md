---
uid: Connector_help_Moxa_VENT2
---

# Moxa VENT2

The **Moxa VENT2** connector monitors and controls the unit through **SNMP**.

## About

The connector polls relevant information from the device every 30 seconds and every half hour.

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

This connector has several data display pages:

### General Page

This page displays the **System Description, Object ID, Up Time, Services, OR Last Change, Contact, Name and Location**.

### Diagnostics Page

This page displays the alarms and faults of the device, as well as the number of **Sent and Received COV Messages**.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
