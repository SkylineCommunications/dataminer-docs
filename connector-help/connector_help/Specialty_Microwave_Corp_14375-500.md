---
uid: Connector_help_Specialty_Microwave_Corp_14375-500
---

# Specialty Microwave Corp 14375-500

This device is a 1:1 protection switch (part no. 14375-500), which consists of a logic panel used in satellite communication earth stations. The system mechanism operates waveguide or coaxial switches to operator-desired positions. The mechanisms provide switching for the radio frequency (RF) outputs of High Power Amplifiers (HPA) in an automatic (unattended) or manual (local and/or remote) mode. During normal operation of a protection switch panel, one active unit is connected between RF transmitters and the antenna/receiver. The standby unit is connected to input and output dummy loads. The RF output of the active unit is applied to the antenna/receiver. In the event of a failure of an active unit, the standby unit is switched in place of the malfunctioning unit when the panel is in automatic mode. The malfunctioning unit is then connected to a dummy load.

The connector polls and displays the current status of the switch. This includes the operation mode of the controller, the local/remote status, the HPAs and the power supplies.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 02.22                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, by default *9600 (*range: from *300* to *19200,* except *600*, which is not supported).
  - **Databits**: Databits specified in the manual of the device, by default *8.* The eighth bit is the parity bit or 0 when the parity is set to *none*.
  - **Stopbits**: Stopbits specified in the manual of the device, by default *1.*
  - **Parity**: Parity specified in the manual of the device (*even*, *odd* or *none*).
  - **FlowControl**: FlowControl specified in the manual of the device, by default *No*.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *6001* (range: from *1* to *65534*).
  - **Bus address**: The bus address of the device (range: from *33* to *126*).

## How to Use

The **General** page displays the operation mode, operation control status, the status of the power supplies and HPAs, and the switch position of the HPAs. You can change the operation mode and the switch position. Changing the switch position (HPAs) is only possible if the operation mode is set to Manual mode and the local/remote control status is Remote mode. If the operation mode is Automatic or the local/remote status is in Local mode, you will not be able to change the switch positions.

The **Configuration Data** page provides general information on the device, as well as configuration data, including the firmware version, serial number and information related to the serial communications interface (SCI2).
