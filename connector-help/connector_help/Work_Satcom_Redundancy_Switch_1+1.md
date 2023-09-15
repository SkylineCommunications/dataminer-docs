---
uid: Connector_help_Work_Satcom_Redundancy_Switch_1+1
---

# Work Satcom Redundancy Switch 1+1

This connector is used to monitor and configure the redundancy switch by Work Satcom.

## About

This connector uses a serial connection to monitor the Work Satcom redundancy switch.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | SW Version RWA01.31         |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device, by default *19200*.
  - **Databits**: Databits specified in the manual of the device, by default *8*.
  - **Stopbits**: Stopbits specified in the manual of the device, by default *1*.
  - **Parity**: Parity specified in the manual of the device, by default *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, by default *No*.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *50505*.
  - **Bus address**: The bus address of the device, by default *66*. This setting is optional. Range: *64-90*.

## Usage

### General

Up to version 1.0.0.3 of the connector, this page contains three sections.

- The first section displays the status and configuration of the device:

- **Active Unit**: Displays the selected unit and also allows you to change the setting.
  - **Unit A Status** and **Unit B Status**: Displays whether any alarm from unit A or B has been detected by the redundancy switch.
  - **PSU1** **Status**: Displays whether the output power of PSU1 is within the valid range.
  - **PSU2 Status**: Displays the status of power supply 2. The PSU2 can be operational with output power within the valid range or have the state "inactive". The output power can also be outside of the valid range, in which case this is indicated with an alarm condition or the inactive state.
  - **Controller Status**: Displays whether the controller is operating normally or if there is any active alarm.
  - **Auto Switching:** Allows you to configure automatic redundancy switching when an alarm is detected on the main unit and no alarm is detected on the inactive unit
  - **Alarm of Inactive Unit**: Allows you to configure if alarms from the inactive unit have to be ignored or processed normally.
  - **Command Forwarding:** Allows you to enable or disable command forwarding for both units.

- The **Network Settings** section allows you to monitor the configuration of the network, e.g. **IP Address**, **Subnet Mask**, **Gateway** and **TCP** **Port**.

- The final section contains information about the **Date and Time** internal setting of the device, and displays the **Software Version**.

From version 1.0.0.4 onwards, there are five sections: **Switch Configuration, Switch Behavior, System Information, Status,** and **Network Information.**

- The **Switch Configuration** section contains information to configure the status of the switches, e.g. **Auto Switching**, **Active Unit** and **Alarm of Inactive Unit**.

- The **Switch Behavior** section contains the **Auto Switching Behavior** and **Reactivation Delay Time** information and configuration.

- **System Information** displays the system's **Date and Time**, **Software Version** and **Serial Number**.

- In the **Status** section, you can find the main status and configuration of the device:

- **Active Unit**: Displays the selected unit and also allows you to change the setting.
  - **Unit A Status** and **Unit B Status**: Displays whether any alarm from unit A or B has been detected by the redundancy switch.

- **PSU1** **Status**: Displays whether the output power of PSU1 is within the valid range.
  - **PSU2 Status**: Displays the status of power supply 2. The PSU2 can be operational with output power within the valid range or have the state "inactive". The output power can also be outside of the valid range, in which case this is indicated with an alarm condition or the inactive state.
  - **Controller Status**: Displays whether the controller is operating normally or if there is any active alarm.
  - **Alarm Status**: Shows whether the alarm status is enabled.
  - **Command Forwarding:** Allows you to enable or disable command forwarding for both units.
  - **Front Panel Lock State:** Allows you to lock or unlock the front panel of the switch.

- The **Network Settings** section allows you to monitor the configuration of the network, e.g. **IP Address**, **Subnet Mask**, **Gateway** and **TCP** **Port**.

### Web Interface

This page allows you to connect to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
