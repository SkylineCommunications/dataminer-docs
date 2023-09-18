---
uid: Connector_help_CPI_T22C1
---

# CPI T22C1

With this **serial** connector you can retrieve status information and update the configuration of **CPI 2.25KW TWT amplifiers**.

## About

This connector uses a serial protocol developed by CPI. Two communication modes are available on the 2.25KW TWT amplifiers: **ASCII Based Serial Computer Interface Protocol** **(ACIP)** and **Binary Based Serial Computer Interface Protocol (BCIP)**. This protocol implements the **BCIP** mode, which gives more reliable and complete information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | \- Front Panel Boot Kernel Software Version: *03.00.19* - Front Main Program Software Version: *01.00.80* - Power Supply Boot Kernel Software Version: *03.00.03* - Power Supply Main Program Software Version: *01.00.47* - RF Controller Boot Kernel Software Version: *03.00.03* - RF Controller Main Program Software Version: *01.00.33* - External Interface Boot Kernel Software Version: *03.00.03* - External Interface Main Program Software Version: *01.00.40* |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *10.80.121.55.*
  - **IP port**: The IP port of the device, e.g. *4050.* Required.
  - **Bus address**: The bus address of the device, e.g. *50*. Required. Range: *17*-*255*.

## Usage

### General

On this page, you can find information such as the **ID Version**, **Power Supply Main Software Version**, **Unit On Time, Time Zone,** etc.

You can also perform a Snapshot by clicking on the **Snapshot** button. The progress is displayed by the **Snapshot File Progress** parameter and the operation status is displayed by the **Snapshot File Status** parameter.

### Measurements

This page displays the following parameters: **Attenuator Setting**, **Beam Current**, **User Time Delay**, **Inlet Temperature**, **Reflected RF**, **RF Drive**, etc.

Specific information can be retrieved via multiple page buttons: **Trip Point**, **Linearizer**, **Imbalance**, **Output**, **Trip Point**, **Heater** and **Helix**.

### Status

This page contains the status parameters **Step Start 1/2 Fault**, **CAN Bus Comm Fault**, etc.

Via page buttons, you can access more detailed information concerning the following aspects of the device: **Helix**, **Heater**, **Inhibit**, **EXT Controller**, **Power Supply**, **RF Controller**, **ETH**, **Px Controllers**, **Beacon,** **Low/High Alarms** and **SIM**.

### Switch Controller Status

On this page, you can set the **Switch Mode** and the **W/G Switch \#n Position** (where **\#n** ranges from 1 to 10).

The status is displayed for **Amplifier \#1** to **Amplifier \#8. Amplifier 1 Priority** to **Amplifier 10 Priority** can be set via the **Priorities** page button.

### Log

This page lists all the entries stored in the device log.
