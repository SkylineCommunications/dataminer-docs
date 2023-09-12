---
uid: Connector_help_Delec_Oratis_Matrix
---

# Delec Oratis Matrix

The **Delec Oratis Matrix** is a driver that allows you to monitor and change settings of a **Delec Oratis Audio Matrix** .

## About

The ****Delec Oratis Matrix**** driver allows you to monitor the values of the different sensors (temperature and voltage) for the slots. It also allows for monitoring that cards are available.
**Crosspoints** can be monitored and set, there is a Scheduler to set a group of Ports to a particular output gain.
Multiple backup versions of the device settings can be stored, and a restore of a particular or the latest backup can be executed.

## Installation and Configuration

### Creation

This is a **multi-connection driver,** it has an **SNMP** part, and a **smart-serial** part, and an **SSH** part**.**
**SNMP polling** can be disabled from within the driver, if the device does not support it.

This driver uses a **Smart-Serial** connection and needs following user information:

**SNMP CONNECTION**:

\- **IP address/host**: the polling IP of the device eg *10.11.12.13*

\- **Device address**: not needed

**SNMP Settings**:

\- **Port number**: the port of the connected device, default *161*

\- **Get community string**: the community string in order to read from the device. The default value is *public*.

\- **Set community string**: the community string in order to set to the device. The default value is *private.*

**SMART-SERIAL CONNECTION**:

\- **IP address/host**: the polling IP of the device eg *10.11.12.13*

\- **IP port**: the port of the connected device (default : *6550*)

\- **Bus address**: not needed
**
**
The driver also uses an **SSH connection** in a **QAction**, and for this you need to copy the SLSsh.dll file from 'C:\Skyline Dataminer\files' to the 'C:\Skyline Dataminer\ProtocolScripts' folder, and restart the DMA.

## Configuration within the driver

### Credentials for SSH logon

On the **Backup** page, there is a pagebutton called **Credentials...** in the top right hand corner, which takes you to the **Credentials** page.
There you can fill in the Username and Password that are used for the **SSH** connection, which is used for a synchronsiation and reboot of the **Matrix** after restore.
The **Administrator** page is only available from a **page button** on the **General** page.
If the device does not support **SNMP Polling**, it can be disabled from the **General** page, on the left hand side here is an **SNMP Polling togglebutton.**

## Usage

### General

On the left hand side of the **General** page the selected **Intercom Address, Segment Address and Frame address** are shown.
Beneath these parameters is the **Oratis PSU table**, which shows the PSU's, with their current status.
There is a **Resync FS** button beneath the Oratis PSU, and a **Reboot** button, they can be used to perform a manual Resync of the Filesystem and a manual Reboot.
On the right hand side there is a **Voltage Sensor Table**, and below it a **Temperature Sensor Table**.
Below these two tables the **average Temperature Sensor value** is displayed.
The device is polled regularly to get its **Frame Address, Segment Address and Intercom Address**.
If this fails, its state will be set to *Timeout.*

### Cards

The **Cards Table** allows you to monitor the availability of the cards in the system.
The cards are contacted every minute, and if one or more of them do not respond for the time configured in **Minutes Before Alarm**, the **General Card Status** will be set to *Alarm* state.
Right clicking this table allows you to add rows, delete rows, or clear the table.
Below it are 3 **buttons** : **Clear Table, Request and Add...**
The **Clear Table** button clears the Table.
The **Request** button lets you request the card status immediately.
The **Add...** button enables you to add another card to the Table.

### Crosspoints

The **Crosspoints Table** allows you to monitor the and change the **Crosspoints** of the Matrix.
A **CSV File** can be imported, and the table can be cleared.

### Scheduler

The **Scheduler Table** allows you to add a specific moment in time when a group of ports will automatically receive a particular value for the Audio Gain Out setting.
In the **Scheduler Table** you can add multiple schedules and Audio Gain settings and enable or disable individual schedules.
It also displays the last time a Schedule was run.
Right clicking the table allows you to Delete Schedules, Add Schedules, or Clear the table.
The Time Format for the Scheduler is dependant on the local settings of the server.
It is entered in 24 hour format, but is converted to the local format when saved.

The **Ports Table** allows you to add or delete Card Select / Destination Port combinations.
Every time a rule goes off in the Scheduler Table, all Card Select / Destination Port combinations will have their Audio Gain out set to the value specified in the **Scheduler Table**.
Right clicking the table allows you to Delete Ports, Add Ports, or Clear the table.
There is a **Destination Port Offset** setting, that will toggle the interpretation of the Port numbers between *0-based* and *1-based*.

### Backup

The **Backup Page** contains a button to create a backup, and there is another field where you can select a particular Backup to restore, or you can restore the last backup.
When the backup is restored, a **sync and reboot command** will be sent via **SSH**.
There is also a Credentials Page button that allows you to enter the **SSH** Username and Password parameters.

# Delec Oratis Matrix

The **Delec Oratis Matrix** is a driver that allows you to monitor and change settings of a **Delec Oratis Audio Matrix** .

## About

The **Delec Oratis Matrix** driver allows you to monitor the values of the different sensors (temperature and voltage) for the slots. It also allows you to monitor the availability of cards. **Crosspoints** can be monitored and set. There is a Scheduler to set a group of ports to a particular output gain.
Multiple backup versions of the device settings can be stored, and a restore of a particular backup or of the latest backup can be executed.

## Installation and Configuration

### Creation

This is a multi-connection driver: it has an SNMP part, a smart-serial part, and an SSH part**.**
SNMP polling can be disabled from within the driver, if the device does not support it.

This driver uses a smart-serial connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not needed.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

**SMART-SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device, by default *6550*.
- **Bus address**: Not needed.

The driver also uses an SSH connection in a QAction. For this you must do the following:

1.  Copy the SLSsh.dll file from 'C:\Skyline Dataminer\files'.
2.  Paste this file in the folder 'C:\Skyline Dataminer\ProtocolScripts'.
3.  Restart the DMA.

### Configuration within the driver

#### Credentials for SSH logon

On the **Backup** page, click the page button **Credentials...** in the top right corner to go to the **Credentials** page.
There you can fill in the Username and Password that are used for the SSH connection, which is used for a synchronsiation and reboot of the matrix after restore.
The **Administrator** page is only available from a page button on the **General** page.
If the device does not support SNMP Polling, this can be disabled from the **General** page, with the **SNMP Polling** toggle button on the left-hand side.

## Usage

### General

On the left-hand side of the **General** page, the selected **Intercom Address, Segment Address** and **Frame address** are shown. Beneath these parameters, you can find the **Oratis PSU table**, which shows the PSUs along with their current status. Beneath the Oratis PSU, there is a **Resync FS** and a **Reboot** button, which can be used to respectively perform a manual resync of the file system and perform a manual reboot.

On the right-hand side, there is a **Voltage Sensor Table**, and below it a **Temperature Sensor Table**. Below these tables, the **Average Temperature Sensor value** is displayed.

The device is polled regularly to get its **Frame Address, Segment Address** and **Intercom Address**. If this fails, its state will be set to *Timeout.*

### Cards

The **Cards Table** allows you to monitor the availability of the cards in the system. The cards are contacted every minute, and if one or more of them do not respond for the time configured in **Minutes Before Alarm**, the **General Card Status** will be set to *Alarm* state. Right-clicking this table allows you to add rows, delete rows, or clear the table.

Below the table, there are 3 buttons: **Clear Table, Request** and **Add...** .

- The **Clear Table** button clears the table.
- The **Request** button lets you request the card status immediately.
- The **Add...** button enables you to add another card to the table.

### Crosspoints

The **Crosspoints Table** allows you to monitor and change the crosspoints of the matrix.

A .csv file for the inputs and a .csv file for the outputs can be imported and the combination of every input with each output will be populated in the crosspoints table. The lookup table is required in order to calculate the **Card Select**.

**Card Select**, **Source Port** and **Destination Port** are calculated using the input and output names in the .csv file.

### Scheduler

The **Scheduler Table** allows you to add a specific moment in time when a group of ports will automatically receive a particular value for the Audio Gain Out setting.

In the **Scheduler Table** you can add multiple schedules and Audio Gain settings and enable or disable individual schedules. It also displays the last time a Schedule was run. Right-clicking the table allows you to Delete Schedules, Add Schedules, or Clear the table. The time format for the Scheduler depends on the local settings of the server. It is entered in 24 hour format, but is converted to the local format when saved.

The **Ports Table** allows you to add or delete Card Select / Destination Port combinations. Every time a rule is triggered in the Scheduler Table, all Card Select / Destination Port combinations will have their Audio Gain Out set to the value specified in the **Scheduler Table**.

Right-clicking the table allows you to Delete Ports, Add Ports, or Clear the table.

There is a **Destination Port Offset** setting, which will toggle the interpretation of the port numbers between *0-based* and *1-based*.

### Virtual GPIs

This page contains status parameters for virtual GPIs that can be configured in the device. The **Virtual GPI Configuration** table on the **Configure Virtual GPIs** page can be used to link the channel of the virtual GPI to the desired parameter in the driver. The states for these virtual GPIs are updated via **UpdateEventState** messages that are received from the device.

### Backup

The **Backup** page contains a button to create a backup, and there is a field where you can select a particular backup to restore, or you can choose to restore the last backup.
When the backup is restored, a sync and reboot command will be sent via SSH.

There is also a **Credentials...** page button that allows you to enter the SSH Username and Password parameters.
