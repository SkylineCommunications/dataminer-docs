---
uid: Connector_help_ASC_Signal_APC400
---

# ASC Signal APC400

With this connector, you can retrieve status information from and send control commands to an **APC400 Antenna Control Unit**.

This unit provides maintenance functionality and, if available, the ability to track small- and medium-sized station antennas.

## About

This is an **SNMP** protocol that polls single and table parameters.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported Firmware versions

| **Range** | **Device Firmware Version**          |
|------------------|--------------------------------------|
| 1.0.0.x          | RPI software version: ACS468K.C.3 03 |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device (e.g. *127.0.0.1*).
- **Device address**: Required (e.g. *1*).

SNMP Settings:

- **Port number**: The port of the connected device (e.g. *161*).
- **Get community string**: The community string used when reading values from the device (e.g. *public*).
- **Set community string**: The community string used when setting values on the device (e.g. *private*).

## Usage

### General

This page contains general information about the device, such as the **Serial Number**, **UTC Date**, **Norad Track**, **Intelsat Track**, **Polarization Rotator**, etc.

It also allows you to configure the main parameters: **Emulated Serial Protocol**, **Remote Mode**, **Site Name** and **Satellite Name**.

Via the **Diagnostic...** page button, you can send diagnostic commands with the following parameters: **Diagnostic Command**, **Diagnostic Command Argument**, **Diagnostic Status** and **Diagnostic Result**.

### Position/Jog

On this page, you can access advanced control/monitoring parameters. The page displays among others the **Azimuth Position**, **Polarization Position** and **Azimuth Wrap**.

You can configure parameters such as **Motor Mode**, **Jog State**, **Elevation**, **Azimuth**, **Polarization**, **Track Command** or **Track Mode**.

Via the **Configuration...** page button, you can change various other parameters, including the **Step Cycle Time**, **Azimuth Offset**, **Latitude**, **Longitude**, **Antenna Size**, etc.

Motor-specific parameters can be configured via the **Motor Configuration...** page button: **Motor Speeds**, **Motor Polarization Axis**, **Elevation Up Coast Distance**, **Drift Factor**, **Azimuth Timeout**, etc.

### Receiver

This page displays receiver-specific parameters, such as the **Receiver Type**, **SNR**, **Pre-Viterbi BER**, **Receiver State**, etc.

### Alarms

This page displays different types of alarms: **Maintenance Settings in Place**, **SRAM State**, **Elevation Resolver State**, **Low Signal State**, **Track State**, **Box Limit State**, etc.

### Satellite Table

The **Satellite Table** allows you to configure each satellite individually, with the parameters **Azimuth Sat**, **Elevation Sat**, **Orbital Longitude**, **Satellite Description**, **Receive Parameters**, etc.
