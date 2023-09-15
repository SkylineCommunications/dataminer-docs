---
uid: Connector_help_Tektronix_MTM400A
---

# Tektronix MTM-400A

The Tektronix MTM-400A connector can be used to monitor and control the MTM400A transport stream monitor. It also provides a scheduler for monitoring.

## About

This connector is used to control and monitor the MTM400A.

A scheduler has also been implemented in the connector, which can be used to monitor different frequencies based on a weekly schedule.

## Installation and configuration

### Creation

This is an SNMP/HTTP over serial connector.

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, default *161*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, e.g. *80.*

### Configuration

In order to use the Scheduler, you first have to upload a template configuration file.

To do so:

1. On the **Scheduler Configuration** page, click the page button **Configure Slots**.
2. Fill in the location of the template configuration file. Example: "C:\Folder1\File.xml".
3. Save the parameter.
4. Click the button **Read File**.

To verify if the upload was successful, check if the value of the parameter **XML Configuration File Template** is *File Loaded*.

## Usage

### Overview

This page contains a tree view that sorts the data according to transport stream program name and PID.

### General

This page displays general information about the device.

### IP Traffic

This page displays an overview of the traffic passing through the device in the **Status Table**.

### Transport Streams

This page displays an overview of the transport streams in the **Transport Streams Table**. Different transport streams can be monitored using the scheduler.

### Program

This page displays the **Program Table**, which contains an overview of the different programs running on the device.

### PID

This page displays the **PID Table** and the **PID To Program Table**.

### Scheduler Configuration

On this page, you can configure the scheduler for the device. These settings have to be configured before you upload the schedule to the device. They include the **Start schedule item**, which is necessary for the device to have a starting point.

Note: When you enable the scheduler, it starts on the time and date of the start schedule item. Until that point in time, it may appear as if the scheduler has not started.

There is also a **Scheduler Table**, where you can specify the days of the week when each slot is applicable and the time when the slot should be configured. When you enter the days of the week, separate each day with a space, a pipe character and another space. E.g. "*Mon \| Tue \| Wed \| Thu \| Fri \| Sat \| Sun*". When you add a row, by default the slot will be applied every day at 00:00:00 PM.

#### Slots Configuration subpage

You can access this subpage via the **Configure Slots** page button. It contains the **Slot Frequency Table**, where you can set up to eight different frequencies. Once these have been configured, these settings must be uploaded to the device. To do so, click the **Apply Slots** button. The parameter **Upload Status of Slots** will display the progress of the upload.

Note that the XML template has to be uploaded before you configure slots. See "Configuration" section above.

### Scheduler Results

This page displays a table with the different frequencies that the scheduler has locked onto.

### Priority 1 TreeControl

This page contains information related to the priority table. Here, you can **reset** generated events, **enable/disable** different alarms, see the **status** of the associated event, etc.

### Priority 2 TreeControl

This page functions in the same way as the Priority 1 Tree Control page.

### Priority 3 TreeControl

This page functions in the same way as the Priority 1 Tree Control page.

### Table Tests TreeControl

This page functions in the same way as the Priority 1 Tree Control page.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
