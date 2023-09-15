---
uid: Connector_help_CEFD_CDM_Qx_SNMP
---

# CEFD CDM Qx SNMP

This protocol is used to control and monitor the CEFD CDM Qx SNMP device

## About

This connector uses an **SNMP** connection and a **serial** connection to communicate with the device.

The snmp connection will poll the device to retrieve the information and also allows sets to control the device.

A serial connection is used to get and set the LSR state.

### Version Info

| **Range** | **Description**                                       | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version                                       | No                  | Yes                     |
| 2.0.0.x          | Usage of tables to handle all slots, based on 1.0.0.6 | No                  | Yes                     |
| 2.0.1.x          | Add (serial) command LRS / REN, based on 2.0.0.9      | No                  | Yes                     |
| 3.0.0.x          | New protocol name, based on 2.0.1.5                   | No                  | Yes                     |
| 3.1.0.x          | New firmware, based on 3.0.0.1                        | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 3.1.0.x          | FW-11247                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

#### Serial SerialPort Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### Main View

This page is the **default page**, and shows the Circuit ID, Unit Summary Alarm, and the ODU Alarms

### General

This **page** allows the **monitoring** and **configuration** of the most important information, as the reference frequency, internal frequency, framing, AUPC, alarms and temperature.

This page also includes these **page buttons**:

- **Grouping**: This **subpage** displays information about the groups, as redundancy, online status and slots.
- **Firmware Info**: This **subpage** displays a table with all the information about the firmware.
- **Defice** **info**: This **subpage** shows the basic information about the device, as the serial number, model number, firmware revision, addresses, and traps.
- **Access** **List**: This **subpage** shows a table with all the allowed addresses.
- **Modules**: This **subpage** shows a table with the existing modules and their characteristics.
- **Interfaces**: This **subpage** shows information about their interfaces, RTS/CTS, G.703 and HSSI.
- **Framing**: This **subpage** shows information about the framing, EDMAC, AUPC and the "Drop and Insert plus plus" Table.
- **Alarm** **Mask**: This **subpage** allows masking or unmasking alarming for the Rx and Tx.
- **Temperature** **Details**: This **subpage** shows details about the temperature of the cards.
- **LBUC**: This **subpage** allows management of the LBUC and LLNB.
- **ODU**: This **subpage** allows the monitoring of the ODU.

### Test Mode Config

This **page** shows a table with the test configurations of the Tx

### Modulator

This **page** shows tables with the Status, Primary Settings and Additional Settings of the Tx

### Demodulator

This **page** shows tables with the Status, Primary Settings and Additional Settings of the Rx

### Monitor

- **EventLog**: This **subpage** shows a table with all the Stored Events received
- **Stat¡stics**: This **subpage** shows a table with all the Stored Statistics, and allows the configuration of the reception of the statistics
- **Rx**: This **subpage** shows the relevant information about the Rx, as the BER Multiplier, Buffer Fill State, Frequency Offset, Signal Level and Eb No
- **CNC**: This **subpage** shows the Slot, the Ratio, the Delay and Offset Freq of the **CNC**

### BIST BERT Generator

This **page** shows information with the monitoring parameters of the BIST BERT Generator

### BIST BERT Monitor

This **page** shows information with the monitoring parameters of the BIST BERT Monitor

### Spectrum Analyzer

This **page** shows information with the monitoring parameters of the Spectrum Analyzer

### Save / Load Configuration

This **page** allows to Save or Load a configuration, by saving or loading a **csv file**

### Web Interface

This **page** displays the web interface of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
