---
uid: Connector_help_Tektronix_SPG8000
---

# Tektronix SPG8000

The SPG8000 is a precision multiformat video signal generator, suitable for master synchronization and reference applications. It provides multiple video reference signals, such as black burst, HD tri-level sync, and serial digital and composite analog test patterns. It also provides time reference signals such as time code and NTP (Network Time Protocol).

## About

The connector polls information from the Tektronix SPG8000 via an SNMP connection. Traps are also implemented; the necessary data will be refreshed as soon as a trap is received.

### Version Info

| **Range**            | **Key Features**                                                                                        | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                                         | \-           | \-                |
| 1.0.1.x              | Second connection for serial API polling                                                                | \-           | \-                |
| 1.0.2.x \[SLC Main\] | Modified exports in PTP table. Some of the PTP parameters can now be exported as standalone parameters. | \-           | \-                |

### Product Info

| **Range** | **Firmware Version** |
|-----------|----------------------|
| 1.0.0.x   | 2.2                  |
| 1.0.1.x   | 3.0                  |
| 1.0.2.x   | 3.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**         |
|-----------|---------------------|-------------------------|-----------------------|---------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                              |
| 1.0.1.x   | No                  | Yes                     | \-                    | Tektronix SPG8000 PTP Interface |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | Tektronix SPG8000 PTP Interface |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial API connection \[1.0.1.x\]

In range 1.0.1.x, this connector also uses a serial connection to poll the API.

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.

SERIAL Settings:

- **Port number**: 5000
- **Bus address**: None/disabled by default.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page contains general information that is retrieved from the device, such as **Firmware Version**, **Hardware Status**, **Main** and **CPU temperature** and **Battery Status.**

### LEDs

This page contains information about the status of the LEDs on the front panel of the device: **Interior LED**, **Exterior LED**, **Time LED** and **Fault LED**.

### Voltage

This page contains information about the different voltages from the different sections of the device, such as **Main Board +5.0V**, **Main Board +3.3V**, **Slot 1 +5.0V**, **Slot 2 +3.3V**, **Slot 3 +8.0AV**, **Slot 4 +5.0AV**, etc.

### Fan

This page displays the speed of the different fans: the **main fan**, **power supply 1(PS1) fan** and **power supply 2(PS2) fan.**

### Power Supply

This page contains critical information about each power supply of the device, such as **Active Hours**, **Standby Hours**, **FOM Status (TWH)** and **12V Status**. It also allows you to **Load Test History.**

### Alarm Status

This page contains status parameters that are associated with each trap the device sends. Based on the received traps, these parameters display *Alarm* or *OK*.

This page also contains a configurable parameter, **Alarm Time-Slot**, which allows you to configure the interval to update the status parameters with incoming traps.

### Status

This page contains general parameters related to the **sources** and **time**.

### Reference

This page allows you to configure or check the status of the **input source** and **antenna**.

### PTP

This page contains a table where you can edit and monitor the PTP values.

### LTC

This page contains a table where you can edit and monitor the values for the 4 LTCs.

### Black

This page contains a table where you can edit and monitor the 3 Black entries.

### AES

This page contains **global parameters settings**, as well as a table with the **8 AES channels**.

### Web Interface

This page contains the web interface for the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
