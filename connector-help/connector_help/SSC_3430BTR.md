---
uid: Connector_help_SSC_3430BTR
---

# SSC 3430BTR

The **SSC 3430BTR** DataMiner connector can be used to monitor and control **Satellite Systems Corporation** model **3430 BTR** devices. These are frequency-agile satellite receivers, designed to provide a linear DC reference voltage proportional to the received signal level of a satellite beacon or other SCPC carrier.

The connector handles communication through both **RS-232** and **RS-485** protocols. All parameters are updated at 10-second intervals.

## About

### Version Info

| **Range**            | **Description**                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                  | No                  | Yes                     |
| 2.0.0.x              | New firmware based on 1.0.0.1, responses changed | No                  | Yes                     |
| 3.0.0.x \[Obsolete\] | Branch version based on 2.0.0.x                  | No                  | Yes                     |
| 4.0.0.x              | New firmware based on 2.0.0.1                    | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 2.0.0.x   | Unknown                |
| 3.0.0.x   | Unknown                |
| 4.0.0.x   | 1998                   |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: The bus address of the device. If the bus address is empty, communication goes through RS-232 protocol, otherwise RS-485 is used. The address range is from the number 1 to the letter F.

## Usage

On the Main page, the **Receive Frequency, Gain, Signal Strength Voltage** and **Lock/Alarm** parameters are available.

If the antenna system is properly aligned to the appropriate satellite and polarity, the lock status parameter will display *Lock*, otherwise it displays *Alarm*.

The frequency and gain parameters can be adjusted. All changes are immediately effected on the device.
