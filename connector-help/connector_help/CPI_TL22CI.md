---
uid: Connector_help_CPI_TL22CI
---

# CPI TL22C1

This is a **serial** connector to retrieve status information and update the configuration of **CPI 2.25KW TWT amplifiers**.

## About

This connector uses a serial protocol developed by CPI. Two communication modes are available on the 2.25KW TWT amplifiers: **ASCII Based Serial Computer Interface Protocol** **(ACIP)** and **Binary Based Serial Computer Interface Protocol (BCIP)**. This connector implements the **BCIP** mode, which provides more reliable and complete information.

### Version Info

| **Range**            | **Description**                            | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                            | No                  | Yes                     |
| 1.1.0.x \[SLC Main\] | Firmware update. Change in status command. | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware**                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
|-----------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | \- Front Panel Boot Kernel Software Version: *03.00.19* - Front Main Program Software Version: *01.00.90* - Power Supply Boot Kernel Software Version: *03.00.03* - Power Supply Main Program Software Version: *01.00.49* - RF Controller Boot Kernel Software Version: *03.00.03* - RF Controller Main Program Software Version: *01.00.36* - External Interface Boot Kernel Software Version: *03.00.03* - External Interface Main Program Software Version: *01.00.42* |
| 1.1.0.x   | N/A                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |

## Configuration

### Connections

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *10.80.121.55.*
  - **IP port**: The IP port of the device, e.g. *4050.* Required.
  - **Bus address**: The bus address of the device, e.g. *50*. Required. Range: *17*-*255*.

## Usage

### General

On this page, you can find information such as the **ID Version**, **Power Supply Main Software Version**, **Time**, **Unit On Time**, **Time Zone**, **Temperature**, etc.

### Measurements

This page displays the following parameters: **Attenuator Setting**, **Linearizer** parameters, **UPC Mode**, **Beacon States**, **Helix Currents**, and **Voltage**, etc.

With a page button, you can retrieve specific information regarding the **Inhibits**: **CIF**, **External Interlock**, **Internal**, **Local**, **Remote**, **Switch Controller**, and **SIM Inhibit**.

### RF Measurements

This page contains all **RF** status parameters, such as **RF Drive**, **Imbalance RF**, **RF Output**, **Reflected RF Output Power**, **ALC RF Output Power**, and **Manual RF Output Power**.

The **Set RF Units** button allows you to choose the unit: **dBm**, **dBW**, or **W**.

### Switch Controller Status

On this page, you can set the **Switch Mode** and the **W/G Switch \#n Position** (where **\#n** ranges from 1 to 10). The **Waveguide Switches** can be **toggled** via the corresponding page button.

The status is displayed for the **Amplifier \#n** (where **\#n** ranges from 1 to 10). These **Amplifier Priorities** can be set via the **Priorities** page button.

In addition, the **2.25KM TWT Error** for **Amplifier \#1 to \#8** and the **Off-Line** for **Amplifier** **\#1 to \#10** can be accessed via page buttons.

### Status

This page contains the status parameters **Step Start 1/2 Fault**, **BBRAM Data Fault**, etc.

Via page buttons, you can access more detailed information concerning the following aspects of the device: **Helix**, **Heater**, **EXT Controller**, **Power Supply**, **RF Controller**, **ETH**, **Px Controllers**, **Beacon,** **Low/High Alarms**, and **SIM**.

### Trip Limit - RF Control

This page contains the **RF Control Faults and Alarms Trip Points**: the **High/Low RF Fault/Alarm Trip Points**, and **High Reflected RF Fault Trip Points**.

### Trip Limit - PS and Temperature

This page contains the **Power Supply and Temperature Faults and Alarms Trip Points**, such as the **Helix Over Voltage Fault Trip Point** and **High TWT Temperature Fault Trip Point**.

### Logging

This page lists all the entries stored in the device log. Via the **Log Settings**, you can set the lower and higher limit for the logging table. The polling of the table can also be enabled or disabled.
