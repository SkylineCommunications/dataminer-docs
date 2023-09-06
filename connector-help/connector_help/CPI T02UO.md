---
uid: Connector_help_CPI_T02UO
---

# CPI T02UO

The **CPI T02UO** is a 200 W outdoor TWT amplifier designed for satellite uplink applications.

## About

This driver communicates with the device using serial commands as described in the manual of the device. It can be used to monitor and control the amplifier.

### Version Info

| **Range**            | **Key Features**                                             | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitoring & control of amplifierControl of waveguide switch | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

Serial main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **Type of Port:** TCP/IP
- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the device, by default *50000.*
- **Bus address***:* The bus address of the device, by default *48.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver has the following data pages:

- **General**: This page contains information about the installed firmware version of the device, timing information on the heater, unit, standby and transmit time, and transmit and inhibit control parameters.
- **Measurements**: The measurements page contains parameters that indicate the current measurements of the different temperature sensors, the output power and fan control.
- **Switch**: This page allows you to control the waveguide switches. It provides control of up to four switches, which can be connected to other HPAs that have a connection with the HPA element.
- **Alarms**: The page provides information on the alarms present on the device. You can monitor these alarms and also substitute some alarms by applying an alarm template and monitoring related parameters polled from the device.
- **Config HPA**: This configuration page contains general information on device settings and also allows you to configure certain HPA parameters.
- **Trip points**: This page contains parameters that are linked to the alarms that the device generates. It allows you to configure thresholds for device alarm generation.

## Notes

As the element provides control of the waveguide switches, it is not necessary to have an external device to control the waveguide switching.
