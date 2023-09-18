---
uid: Connector_help_Siemens_Sentron_PAC3200
---

# Siemens Sentron PAC3200

With this connector, it is possible to monitor a **Siemens Sentron PAC3200** power meter device.

## About

This connector uses serial communication to monitor a **Siemens Sentron PAC3200** device. The protocol used for the serial communication is **Modbus TCP**. All commands and resonses are in the standard format of Modbus TCP.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *192.168.236.79.*
- **IP port**: The port of the connected device. For Modbus this is often port *502*.
- **Bus address**: The bus address of the connected device, *e.g. 4*.

## Usage

### General Page

This page displays general information about the device:

- Different **Phase Voltages**
- Different **Phase Currents**
- Different **Phase Power Measurements**

### Phase 1 Page

This page displays power, voltage and measurements of phase 1.

### Phase 2 Page

This page displays power, voltage and measurements of phase 2.

### Phase 3 Page

This page displays power, voltage and measurements of phase 3.
