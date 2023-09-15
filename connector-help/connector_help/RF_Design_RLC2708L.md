---
uid: Connector_help_RF_Design_RLC2708L
---

# RF Design RLC2708L

The RF Design RLC2708L is an active 8:1 L-Band combiner with front-side inserted 1:1 redundant operating line-amplifier modules.

The unit features 8:1 L-Band combining while the two redundant operating amplifier modules allow variable gain adjustment so to reach best RF performance within the network. The redundancy switching between these two amplifier modules is done nearly interruption free within a switchover time of less than 5ms. Besides the variable gain adjustment (MGC/AGC) and 8:1 combining the unit also features slope-equalization, 10MHz external reference, RF power monitoring as well as 1:1 redundant power-supply (hot-swappable).

The RLC2708L features a flexible and compact RF-distribution solution which is perfectly suited for applications in Teleports, Satellite Earth-Stations, as well as Broadcast- and Broadband facilities wherever accurate RF power, highest stability and availability is necessary. The unit has a front-side LC-Display/keypads for user-friendly local configuration while front-side status LED's are indicating amplifier and power-supply status. Remote control and configuration can be done via its rear-side Ethernet-Interface (WEB-GUI, SNMP). The RLC2708L is available with 50Ohm SMA(f) or 75Ohm F(f) connectors (see order-information).

## About

This connector retrieves and sets data via SNMP.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range**  | **Device** **Firmware Version** |
|-------------------|---------------------------------|
| 1.0.0.x           | 2.3.23.D11.S23.H18.18.9.4       |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device, e.g. 172.16.201.84.
- **Device address:** Not used.

SNMP Settings:

- **Port number:** The port of the connected device, by default 161.
- **Get community string:** The community string used when reading values from the device. The default value is public.
- **Set community string:** The community string used when setting values on the device. The default value is private.
- **Timeout of a single command (ms):** The timeout is used when the DMA does not receive a response from the device. The default value is 1500.

## Usage

### General

This is the default page, which displays general information on the device (refered as unit) and on the main and backup modules.

- **Unit Name**
- **FW-Version**
- **Unit Serial Number (SNR)**
- **Unit Status**
- **Power Supply Unit 1 (PSU-1) Status**
- **Power Supply Unit 2 (PSU-2) Status**
- **Local (remote) Login Status**
- **Main Module Status**
- **Backup module status.**

### Main Module

This page contains information on the Main Module and is used to edit and monitor configurations, measurements and alarm overview on the same Module.

This page was implemented based upon web UI, namely, the displaying organized in sections as seen below.

- **Main Module**

- **Signal Name (Main Module)**

  - **Current Consumption (Main Module)**

  - **Status (Main Module)**

- **RF-Power Control**

- **RF-Input Power (Main Module)**

  - **RF-Gain (Main Module)**

  - **RF-Output Power (Main Module)**

  - **Slope (Main Module)**

  - **RF-Output Power Overflow (Main Module)**

  - **AGC (Main Module)**

  - **AGC Reference (Main Module)**

  - **AGC Time (Main Module)**

  - **AGC Window (Main Module)**

  - **AGC Lock (Main Module)**

  - **Upper Limit (Main Module)**

  - **Lower Limit (Main Module)**

- **Threshold**

- **Threshold Monitor (Main Module)**

  - **Threshold Level (Main Module)**

  - **Threshold Alarm (Main Module)**

- **Limiter**

- **Limiter (Main Module)**

  - **Limiter Level (Main Module)**

  - **Limiter Alarm (Main Module)**

- **LNB-Power**

- **LNB-Power (Main Module)**

  - **LNB-Power Current (Main Module)**

  - **LNB-Power Reference (Main Module)**

  - **LNB-Power Alarm (Main Module)**

  - **LNB-Power Window (Main Module)**

- **Redundancy**

- **Amplifier 1 Status (Main Module)**

  - **Amplifier 2 Status (Main Module)**

  - **Actual Amplifier (Main Module)**

### Backup Module

Similarly to the Main Module page, this page contains information on the Backup Module and is used to edit and monitor configurations, measurements and alarm overview on this Module.

This page was implemented based upon web UI as seen below.

- **Backup Module**

- **Signal Name (Backup Module)**

  - **Current Consumption (Backup Module)**

  - **Status (Backup Module)**

- **RF-Power Control**

- **RF-Input Power (Backup Module)**

  - **RF-Gain (Backup Module)**

  - **RF-Output Power (Backup Module)**

  - **Slope (Backup Module)**

  - **RF-Output Power Overflow (Backup Module)**

  - **AGC (Backup Module)**

  - **AGC Reference (Backup Module)**

  - **AGC Time (Backup Module)**

  - **AGC Window (Backup Module)**

  - **AGC Lock (Backup Module)**

  - **Upper Limit (Backup Module)**

  - **Lower Limit (Backup Module)**

- **Threshold**

- **Threshold Monitor (Backup Module)**

  - **Threshold Level (Backup Module)**

  - **Threshold Alarm (Backup Module)**

- **Limiter**

- **Limiter (Backup Module)**

  - **Limiter Level (Backup Module)**

  - **Limiter Alarm (Backup Module)**

- **LNB-Power**

- **LNB-Power (Backup Module)**

  - **LNB-Power Current (Backup Module)**

  - **LNB-Power Reference (Backup Module)**

  - **LNB-Power Alarm (Backup Module)**

  - **LNB-Power Window (Backup Module)**

- **Redundancy**

- **Amplifier 1 Status (Backup Module)**

  - **Amplifier 2 Status (Backup Module)**

  - **Actual Amplifier (Backup Module)**
