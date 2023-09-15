---
uid: Connector_help_2WCOM_S02
---

# 2WCOM S02

The 2WCOM S02 contains two independently selectable limiters: a peak deviation limiter and a modulation limiter.

- The peak deviation limiter makes it possible to raise the main volume of the sound file considerably without causing clipping or distortion, while at the same time complying with regulatory demands.
- The optional modulation monitoring checks the audio inputs and notifies the user of low audio level. The modulation monitoring can also be configured to switch automatically between the audio inputs.

## About

This connector provides an overview of the states of the AES inputs, the presets and the event settings.

The information is retrieved from the device using **SNMP**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \-                          |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays the **AES Inputs** **Table**, along with the **Input**, **MPX Output**, **Peak Deviation** and **Modulation Power** parameters.

The page contains page buttons to the following subpages:

- **S02 Configuration**: Allows you to configure the **Language**, **Preset**, **Unit** and **Sensitivity** of the device.
- **Network Configuration**: Allows you to configure network settings such as the **IP Address**, **Subnet Mask**, **Gateway**, **HTTP Port**, and **SNMP trap destination** addresses.

### Preset

This page displays the **Presets** **Table**.

### Event Setting

This page displays the **Event Settings** **Table**.
