---
uid: Connector_help_Riello_MST_100
---

# Riello MST 100

The Riello MST 100 protects data centers and telecommunications systems by, among others, filtering harmonics and applying a power factor correction on power sources.

The aim of this connector is to monitor battery, input, output and bypass currents, voltages and frequencies. It also allows the user to configure input/output/battery voltages and input/output frequencies.

## About

The connector communicates with the device via **SNMP** to retrieve parameter values and adjust settings.

### Version Info

| **Range**     | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | Yes                 | Yes                     |
| 1.1.0.x              | Firmware upgrade | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                           |
|------------------|-------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | UPS software version: SWM022-02-21/ Agent software version: AppVer. 01.04.000 Firmware version: S14-1 |
| 1.1.0.x          | Firmware version: S16-1                                                                               |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.16.101.4*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, e.g. *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

## Usage

### Ident (Not supported since version 1.1.0.x)

On this page, you can find general information concerning the device, such as **System Up Hour**, **UPS Ident Model**, **UPS Ident UPS Software Version**, **On Battery**, etc.

### Battery

This page contains battery-specific parameters: **UPS Battery Status**, **UPS Time on Battery**, **UPS Estimated Remaining Time**, **UPS Estimated Charge Remaining** and **UPS Battery Voltage/Current/Temperature**.

### Temperature

This page contains information on the temperature from the system, power, charger and battery: **UPS Present System Temperature**, **UPS Present Power Temperature (1-3)**, **UPS Charger Temperature** and **UPS Positive**, **Negative** and **External Battery Temperature**.

### Input

This page displays the **UPS Input Number of Lines**, **UPS Input Line Bads** and the **UPS Input Table**, which displays the **Frequency**, **Voltage**, **Current** and **True Power** for each line.

### Output

On this page, you can find the following single parameters: **UPS Output Source**, **UPS Output Frequency** and **UPS Output Number of Lines**.

In addition, the **UPS Output Table** displays the **Voltage**, **Current**, **Power** and **Load** for each line.

### Bypass

This page displays the **UPS Bypass Frequency** and **UPS Bypass Number of Lines** as single parameters, and also displays the **Voltage**, **Current** and **Power** of each line in the **UPS Bypass Table**.

### Alarm

With the **UPS Alarms Present** parameter, this page shows the number of alarms present in the **UPS Alarm Table**. Each line of this table contains a **Description** of the alarm event and the **Time** when it occurred.

### Control

This page contains the following parameters: **UPS Shutdown After Delay**, **UPS Startup After Delay** and **UPS Reboot with Duration**, which you can use to control the shutdown delays, the startup delays and the reboot duration.

### Configuration (Not supported since version 1.1.0.x)

On this page, you can configure input, output and battery via different parameters (**UPS Config Input Voltage/Frequency**, **UPS Config Output Voltage/Frequency**, **UPS Config High Voltage Transfer Point**, etc.).

### Web Interface

This page provides access to the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.0.x** and **1.1.0.x** connector ranges of the **Riello MST 100** protocol support the usage of DCF and can only be used on a DMA with **9.0.0** as the minimum version.

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- Normal: **in** type.
- Bypass: **in** type.
- Battery: **in** type, created for the parameter **UPS Battery Status**.
- Booster: **in** type.
- Reducer: **in** type.
- Output: **out** type, created for the parameters **UPS Output Frequency**, **UPS Config Output Voltage** and **UPS Config Output Power**.

### Connections

#### Internal Connections

- Between **Normal** and **Output**, an internal connection is created.
- Between **Bypass** and **Output**, an internal connection is created.
- Between **Battery** and **Output**, an internal connection is created.
- Between **Booster** and **Output**, an internal connection is created.
- Between **Reducer** and **Output**, an internal connection is created.
