---
uid: Connector_help_Specialty_Microwave_Corp_14862-500
---

# Specialty Microwave Corp 14862-500

This device is a 1:2 protection switch (part no. 14862-500), which consists of a logic panel used in satellite communication earth stations. The system mechanism operates waveguide and coaxial switches to positions set by the operator. The mechanisms provide switching and combining operations for the radio frequency (RF) outputs of high power amplifiers (HPA) in an automatic (unattended) or manual (local and/or remote) mode. During normal operation of a protection switch panel, two active HPA units are connected between RF transmitters and the antenna. The standby HPA is connected to input and output dummy loads. The RF output of the active HPA is applied to the antenna. In the event of failure of an active unit, the standby HPA is switched in place of the malfunctioning HPA when the panel is in automatic mode. The malfunctioning HPA is then connected to a dummy load.

The protocol allows the user to check the status of the controller switch and set certain commands.

## About

The connector polls and displays the current status of the switch. This includes the operation mode of the controller, the local/remote status, the HPAs and the power supplies.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 02.30                       |

## Installation and configuration

### Creation

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: *9600*
  - **Databits**: 8, eighth bit is the parity bit or 0 when the parity is set to "none"
  - **Stopbits**: 1
  - **Parity**: None
  - **FlowControl**:

- Interface connection:

  - **IP address/host**: 192.168.52.10
  - **IP port**: 4008
  - **Bus address**: 49

## Usage

### General

This page provides general information on the device, as well as configuration data, including the firmware version, serial number and information related to the serial communication interface (SCI2).

### Controller

This page displays the **Operation Mode Status/Remote Control Status**, the status of the **Power Supplies** and **HPAs**, and the **switch position** of the **HPAs**.

Each HPA switch is either in the **Main** or the **Standby** position. The outputs of the HPAs are fed to either the **Antennas** or the **Loads**.

You can change the operation mode here and switch positions using the toggle buttons. Changing the switch positions (HPAs) is only possible if the operation mode is set to **Manual** mode and the local/remote control status is **Remote** mode. If the operation mode is **Automatic** or the local/remote status is in **Local** mode, you will not be able to change the switch positions.
