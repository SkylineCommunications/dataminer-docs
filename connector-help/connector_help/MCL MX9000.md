---
uid: Connector_help_MCL_MX9000
---

# MCL MX9000

The MCL MX9000 is a high-power DBS-Band, CW Klystron power amplifier (HPA) that is used for reliable commercial service in satellite communication earth station terminals. It features a 1-, 8- or 12-channel Klystron amplifier tube, solid-state IPA, RF input and output impedance matching, protective circuitry, power monitoring devices, an arc detector with PIN diode switch, and more.

The driver communicates with the device via serial commands. It can be used in an n+1 configuration, where one of the devices is in fallback mode.

## About

### Version Info

| **Range** | **Key Features**                                                                      | **Based on** | **System Impact** |
|-----------|---------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                                                                       | \-           | \-                |
| 1.1.0.x   | \- Issues with incorrectly interpreted input resolved.- Duplicate parameters removed. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | S                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.1.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial (Main) connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. If the device also uses the Channel Changer, a second bus address needs to be specified here as well. For example, *2.3* should be specified if 2 is the standard bus address and 3 is the bus address for the channel changer.

## How to use

The element consists of the data pages detailed below.

### Main View

This page contains the most important monitored parameters, such as **RF Forward Power, Filament Current (AI05), Tube RF Drive Power,** etc.

### General

This page contains general parameters, including those displayed on the Main View page. Page buttons provide access to the following subpages:

- **Switch HPA**: Allows you to switch the active switch between the antenna and the dummy load.
- **Set Delay Times**: Allows you to set the delays.

### Alarms

This page contains a status parameter for various faults, such as the RF Low Alarm, RF Inhibited, Interlock Fault, etc. It contains page buttons to the following subpages:

- **Fault Count**: Displays information about the number of faults.
- **Alarm Levels:** Displays information about the alarm level assigned to different levels of alarms.

### Digital Input Status

This page contains parameters related to the input, such as **Airflow Fault, EMR Bypassed**, etc.

### Digital Output Status

This page contains parameters related to the output, such as **Switchover Auto Switching, Transmit Enable**, etc.
