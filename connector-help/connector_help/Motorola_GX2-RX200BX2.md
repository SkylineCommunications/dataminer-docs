---
uid: Connector_help_Motorola_GX2-RX200BX2
---

# Motorola GX2-RX200BX2

The **Motorola GX2-RX200BX2** connector is an SNMP-based connector used to monitor and configure the **Motorola GX2-RX200BX2.**

## About

This connector provides a monitoring interface for the **Motorola GX2-RX200BX2** chassis.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |
| 2.0.0.x          | DVE focused     | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | D                           |

## Usage

### General

This page displays general information about the card. **Unit Name**, **Module Type**, **Firmware** and **Hardware** version, **IP Address** and **Physical Address** are some of the parameters that can be found here.

You can also configure additional information here, such as the **Return Rx Path** name and **Location**. If the device is configured to detect its IP neighbors, their IP will be displayed with the parameter **Rx Neighbor 1 IP Address**.

### Optical Receiver

This page displays the following read-only parameters: **Temperature**, **Fan Current**, **Current 12V** and **Optical Power**. It also contains the following configurable parameters: **Mode**, **Wavelength**, **Attenuator**, **Switch Mode**, **Threshold** and **Factory Default Reset**.

### Alarms

This page contains all the **Status** parameters. If an alarm is detected, the parameter will change from *OK* to *ALARM*.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device.

Note that the client machine has to be able to access the Http server of the device, as otherwise it will not be possible to open the web interface.
