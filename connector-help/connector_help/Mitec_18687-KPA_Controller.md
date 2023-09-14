---
uid: Connector_help_Mitec_18687-KPA_Controller
---

# Mitec 18687-KPA Controller

The **Mitec 18687-KPA Controller** connector monitors and controls a redundancy controller through serial communication. The device monitors/controls eight chains, six online and two on standby, each consisting of one High Power Amplifier (HPA).

## About

The connector polls information from the **Mitec 18687-KPA Controller** device every 30 seconds. This can be information regarding general settings, active alarms and ongoing maintenance on the HPAs.

**Serial** communication is used to poll the information from the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**                                                           |
|------------------|---------------------------------------------------------------------------------------|
| 1.0.0.x          | Compatible with software version 2.23 of the RSU Model 18687-01 (configuration 1.00). |

## Installation and configuration

Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface Connection

- **IP Address/Host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus Address**: The bus address of the device, with a range from *48* up to *63*.

## Usage

### General

On this page, you can find the following general information and settings for the device:

- **RSU Model**: The model of the Redundant Switch Unit (RSU).
- **Configuration Version**: The configuration version of the RSU.
- **Software Version**: The software version of the RSU.
- **Mode**: Shows if the device is operating in *Local* or *Remote* mode.
- **Operating Mode**: Displays whether the device is operating in *Manual*, *Automatic* or *Smart Manual* mode, and allows the user to set the mode to *Manual* or *Auto*.
- **HPA S/B X Backup**: Shows if the standby HPA X (i.e. 1 or 2) is working as a backup.
- **HPA S/B X Backup Failures**: Shows if the standby HPA X (i.e. 1 or 2) is experiencing failures as a backup.
- **PSU Alarms**: Displays whether there are active alarms for the PSU.
- **SW Alarms**: Displays whether there are active alarms for the active switches.
- **Fan Alarms:** Displays whether there are active alarms for the fans.
- **Ack Alarms** button: Acknowledges all active alarms.

### Switches

This page displays the position of each switch, i.e. from **Switch 1** to **18**. The position can be either 1 or 2**.**

### Chain Alarm

This page shows whether there are active alarms for each of the chains, i.e. the online HPAs (**HPA 1** to **HPA 6)** and the standby ones (**HPA S/B 1** and **2**).

In addition, you can set the chain priority with the **Chain Priority** parameter.

### Maintenance

On this page, you can view and control the maintenance status for the online HPAs (**HPA 1 Status** up to **HPA 6 Status**) and the standby HPAs (**HPA S/B 1** and **2 Status**). The available values are *Maintenance* or *OK* (i.e. no maintenance).

### Fan/PSU Alarm

On this page, the following alarm statuses for the fans and PSUs are shown:

- **Hybrid Fan 2** and **5**.
- **Filter Fan 2** and **5**.
- **Fan PSU 1** and **2**.
