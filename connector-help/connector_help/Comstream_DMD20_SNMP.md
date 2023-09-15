---
uid: Connector_help_Comstream_DMD20_SNMP
---

# Comstream DMD20 SNMP

Through this connector is possible to gather and view information from the device **Comstream DMD20SNMP**. It also gives the possibility to set values on the device.

# About

Connector used to gather information from the **Comstream DMD20SNMP** device.

The connector has several pages with general information, alarms, information regarding the modulator and the demodulator, etc.

## Creation

### SNMP

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: the port of the connected device, default 161
- **Get community string**: the community string in order to read from the device. The default value is public.
- **Set community string**: the community string in order to set to the device. The default value is private. Other info

# Usage

### Main View

This page displays some main info of the device. E.g.: summary alarms, voltage alarms, modulator and demodulator general parameters.

### General

This page displays some general info of the device, like firmware versions, voltage supply, remote control mode, etc.

This page contains a button to test the reset of the device. It also contains for page buttons where it can be found some general information of several components of the device.

### Alarms

This page shows the status of the alarms present on the device.

It also contains the following page buttons:

- **Force Alarms.**
- **Mask Alarms.**
- **Memorised Alarms.**
- **Insert Status.**
- **Drop Status.**
- **More Demod. Alarms.**
- **Normalize alarms.**

### Modulator

This page display information related to the modulator. Besides displaying information it is also possible to set configurations parameters to the device.

This page contains two page buttons:

- **LBST Settings.**
- **More Settings.**

### Demodulator

This page display information related to the demodulator. Besides displaying information it is also possible to set configurations parameters to the device.

This page contains two page buttons:

- **LBST Settings.**
- **Buffer Settings.**
- **More Settings.**

### AUPC

This page shows and gives the possibility to set parameters related to the AUPC.

### Save / Load Configuration

In this page is possible to **Save** to a csv file all parameters values. After, is also possible to **Load** that same file. It will set the parameters qith the values that were saved.

- The file will be stored by default on this folder: *C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\\PROTOCOLNAME\]*

- The file will be named by default: *backup_ELEMENTNAME_datetime*
