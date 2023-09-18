---
uid: Connector_help_CISCO_4G_LTE_NIM
---

# CISCO 4G LTE NIM

The CISCO 4G LTE NIM is a connector used to monitor and configure the CISCO 4G LTE Network Modules via SNMP.

## About

The CISCO 4G LTE NIM devices are 4G multimode LTE WWAN (Wireless Wide Area Network) interfaces used with ISRs (Service Integrated Service Routers), in order to provide WWAN primary and backup solutions.

The main features offered by this solutions are network resiliency with greater speeds (up to 50 times higher than 3G links), while guaranteeing Quality of Service functions.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x \[SLC Main\] | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **Username**: The SNMPv3 username.
- **Security level**: The SNMPv3 security level.
- **Authentication type**: The SNMPv3 authentication type.
- **Authentication password**: The SNMPv3 authentication password.
- **Privacy type**: The SNMPv3 privacy type.
- **Privacy password**: The SNMPv3 privacy password.

## Usage

### General

Contains the system general parameters such as the device IP address and the system name.

### Interfaces Info

Here you can find the system **Interfaces** status, configurations and **communication statistics** (Bandwidth, Input/Output Throughput, In/Out Utilization, ..).

Here you can also find the **Measurement Configuration** and the **DCF Info** page buttons.

The first can be used to enable\disable the display and the calculation of communications KPIs, while the second contains information on the interfaces used by the DataMiner Connectivity Framework.

### WAN Configurations

This page contains a two tables with **common information** to all **4G WAN** (**Wide Area Network**) **modules**.

In the **first table**, you will find each **module status information** about the **modem status**, **RSSI** and **Ec/Io** measurements, **current system time** and **cellular capacities**.

The **second table** contains each **module** **settings**, where it is possible to configure the thresholds to send notifications for parameters such as **Modem Temperature**, **RSSI**, **Ec/Io** or **Modem Status**. It's also possible to **reset** or **power cycle** the modules separately.

### GSM

This page contains information about the **GSM (**Global System for Mobile Communications**) capabilities** on the existing modules. This info is distributed by the following tables:

- **GSM Identity -** In this table it is possible to check the **IMEI**, **IMSI**, **FSN** and **ICCID** of the each installed module, while also configuring the **Roaming Preference** and **MSISDN**.
- **GSM Radio** - This table gives you access to the low level radio parameters such as **Channel Number**, **Nearby Cells**, **GSM Band**, **RSSI** and **Ec/Io**.
- **GSM Network** - Here you will find information about the **service status**, the associated **GSM network**, **MCC**. **MNC**, **RAC** and **Cell Id**.
- **Nearby Cells** - This table has the radiation information about the nearby cellular cells.
- **GSM Security** - In this table you will be able to configure **security settings** such as **Card Holder Verification**, to check the **SIM status** and if it is protected or not.

These tables will be empty if no GSM modules are installed.

### CDMA

This page will allow you to explore the information about the **CDMA (Code-Division Multiple Access) capabilities** of the modules installed. This info is distributed by the following tables:

- **CDMA** **Identity** - Here you can find information that uniquely identifies the installed CDMA modules, such as **ESN**, **MDN**, **MSID**, as well as the **Activation Status** and the **Roaming preferences**.
- **CDMA Radio** - This table has the information about **Channel Number**, **Channel State** and the usual **RSSI** and **Ec/Io**.
- **CDMA Network** - This table has the information about the **location** of the associated base station, **SID**, **NID** and **Simple IP** preferences.
- **CDMA Security** - Here you will be able to configure the **PIN** and **Power Up Lock** status.

These tables will be empty if no CDMA modules are installed.

### LBS

This page you will find information about the available **LBS** (**Location Based Services**) **capabilities**.

The first table, the **WAN LNBS Common table** displays general purpose information, such as the **LBS state**, the **location**, and **uncertainty** correction factors such as **GPS Uncertainty**, **Uncertainty Angle**, **HEPE** and **Horizontal** and **Vertical velocities**.

The second one, the **Satellite Info table** display information about the available satellites, if a GPS is installed. This table contains columns such as **Satellite Number**, **Elevation**, **Azimuth** and **Signal to Noise Ratio.**

### RF Configurations

This section contains the **LTE Profiles status** and **configuration** data.

LTE Profile settings such as the IPv4/6 address can be changed in the table of the same name.

### RF Metrics

This page displays the **Radio metrics** used to evaluate LTE wireless communications, such as RSRP (Reference Signals Received Power) and SNR (Signal-to-noise Ratio).

You can also configure the **threshold settings** associated to these metric parameters, that will trigger **system notifications**.

By opening the EPS Bearers QoS page button you access the system **LTE EPS** **Bearers** (connection between two endpoints) **QoS** (Quality of Service) **metrics**.

### Ping Function

Contains the system Ping functionality used to **test** the system **connection** and to retrieve **connectivity statistics**.

**NOTE: Web Interface not available.**
