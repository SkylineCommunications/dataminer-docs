---
uid: Connector_help_Arris_FFTMax
---

# Arris FFTMAX

The FTTMax is an optical amplifier that offers optical amplification solutions using RF video overlay. The 1- or 2-RU rack-mounted FFT-EFDA is available in both single optical channels and up to 36 multiple output configurations.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.155                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the pages detailed below.

### General

This page displays chassis information such as the **Model Number**, **Serial Number**, **Date of Manufacture** and **Firmware Revision**, and network settings such as **IP address**, **Subnet Mask** and **Gateway**.

Remote management is accessible through the **SNMP Manager** **table.**

### Attenuation

This page contains system attenuation parameters, such as **Gain Setpoint**, **Output Power** **Setpoint, Optical Output Power**, **Oscillator Optical Power** and **Output Power ALS** (Automatic Laser Shutdown).

### Alarm Settings

The **Alarm Table** on this page shows the current alarm conditions present in the system and some input/output threshold alarm levels: **Temperature Alarm**, **Input/Output Power Alarm**, and **Relay Input/Output Alarms**.

### Events

This page contains the following tables:

- **Event** **table**: Shows the current events present in the system.
- **History** **table**: Shows the records of events that have occurred in the system.
