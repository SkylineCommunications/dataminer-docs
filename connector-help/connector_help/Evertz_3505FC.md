---
uid: Connector_help_Evertz_3505FC
---

# Evertz 3505FC

This connector is used to monitor and control the Evertz 3505FC.

## About

All the monitoring and control information is retrieved via SNMP and displayed in tables and in a tree control.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.220.250.93*.
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device, e.g. *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

## Usage

### Tree Control

On this page, a tree structure shows the relations between the tables displayed in the Control, Monitor and Notify pages.

### Control

This page contains four tables:

- With the **TX Controls Table**, you can enable the **Squelch TX** and the **Laser** for a particular **SFP Index** and **Channel Index**.
- In the **RX Controls Table**, you can manipulate parameters such as the **Low Optical Threshold** or the **Output Slew Rate**.
- In the **Coax Controls Table**, you can configure the following parameters: **Output Mute**, **Reclocker Mode**, **Switch Mode** and **Switch Type**.
- The **Valid Controls Table** indicates which controls are valid and is therefore used to filter the **Controls** tables.

### Monitor 1

This page contains four tables:

- The **SFP Monitors Table** displays general information about each SFP: the **Module Type**, **Module Serial Number**, **Module Version**, ...
- The **TX Monitors Table** displays the following data about the transmitters: the **Wave Length**, **Laser Status** and **Standard Detected TX**.
- For the receivers, the **RX** **Monitors Table** displays the **Optical** **Power** and the **Standard Detected RX**.
- The **Coax Monitors Table** shows, amongst others, the **Signal Presence**, **Signal Lock**, **Signal Rate**, ...

### Monitor 2

This page contains three tables:

- The **Valid Monitors Table** indicates which monitors are valid and is therefore used to filter the **Monitors** tables in the Monitor 1 page.
- The **PSU Monitors Table** provides the following information: the **PSU Index**, the **PSU Presence** and the **PSU Temperature**.
- The **Misc Monitors Table** shows the fan status: **Fan Module Presence**, **Fan Module Temperature** and **Frame Type**.

### Notify 1

The four tables on this page, the **Mgmt RX Optical Power High Table**, **Mgmt RX Optical Power Low Table**, **Mgmt TX Faults Table** and **Mgmt SFP Communication Loss Table,** all provide the following information, related to their respective faults:

- **Fault Valid**
- **Fault**
- **Send Trap** (used to decide if a trap must be sent)
- **Fault Present**

### Notify 2

This page contains three tables:

- The **Mgmt No Input Detected Faults Table** and **Mgmt Reclocker Loss Faults Table** display the same information as the tables on the Notify 1 page, but for their respective fault types.
- The **FC Faults Table** displays the **FC Fault Index** (e.g. *PSU 1 Fail*, *Fan Fail*, ...), **FC Send Traps** (to turn trap sending off/on) and **FC Fault Present**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
