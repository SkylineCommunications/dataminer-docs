---
uid: Connector_help_Evertz_7880TSM
---

# Evertz 7880TSM

The **Evertz 7880TSM** connector is used to monitor and control different kinds of **Evertz 7880TSM** cards.

## About

This connector supports different types of cards. Depending on the **Card Type**, the number of inputs changes :

- 7880TSM-IP: 1 input
- other types: 2 inputs

If the card contains only one input, the parameters related to the second input will still be displayed, but the values won't be polled.

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: The polling IP of the device, e.g. 10.11.12.13.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

This connector contains 9 pages.

### General

This page displays common parameters about the device. Depending on the **Card Type** parameter, the **Number of Inputs** will change (1 for 7880TSM-IP, 2 for all other types). This page also contains a button to reboot the device.

### Network Settings

This page displays parameters related to the network settings **(VLAN**, **Trap destination**,.)

### Input1

This page displays parameters about the first input of the device (**Bitrate**, **Mode**,.)

### Input1 PID

This page contains a table with all the PIDs contained in the input 1 stream. For each PID, diverse data is shown (**PID Type**, **Name**,.).

The **PID Template** button displays a page that allows the user to create a PID Template that will be compared to the actual PID list. If the comparison mismatches, the **Input 1 Template Status** parameter will go into alarm state.

### Input1 Alarms

This page displays a list of alarms. Each parameter is associated with a trap. When a trap is received, the corresponding parameter will be polled again to update its value. You can enable or disable each by clicking on the **Traps** page buttons.

### Input2

This page is similar to the **Input1** page. If the **Card Type** is 7880TSM-IP, these parameters won't be polled.

### Input2 PID

This page is similar to the **Input1 PID** page. If the **Card Type** is 7880TSM-IP, these parameters won't be polled.

### Input2 Alarms

This page is similar to the **Input1 Alarms** page. If the **Card Type** is 7880TSM-IP, these parameters won't be polled.

### Output

This page displays miscellaneous data about the output stream.
