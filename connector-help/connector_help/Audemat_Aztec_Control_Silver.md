---
uid: Connector_help_Audemat_Aztec_Control_Silver
---

# Audemat Aztec Control Silver

The **Audemat Aztec Control Silver** is a controller device.

## About

This connector allows the management of the Audemat Aztec Control Silver device using the **SNMP** protocol.

## Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page contains general information about the device: **System Type**, **Software Version** and **Serial Number**.

### Alarms Page

This page provides an overview of the alarms in the **Alarm Table**. This table shows the **Alarm Severity**, **Alarm Name**, **Alarm Description**, **Alarm State** and **Alarm Timestamp**.

### Inputs Page

This page provides an overview of the inputs in the **Digital Input** **Table** and the **Analog Input Table**.

### Outputs Page

This page provides an overview of the outputs in the **Digital Output Table**.

### Events Page

This page provides an overview of the events in the **Event Log Table**.

### Action Button Page

This page provides an overview of the action buttons in the **Action Button Table**.

### Web Interface Page

This page allows the user to access the original web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
