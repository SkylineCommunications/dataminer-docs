---
uid: Connector_help_Axon_GDR21
---

# Axon GDR21

This protocol is used to monitor parameters of the **Axon GDR21** amplifier. It also allows the user to configure some parameters of the device.

The GDR216 is a dual-channel 3GB/s, HD, SD SDI reclocking distribution amplifier with simple switching capabilities and selectable outputs. This card is ASI/DVB compatible.

## About

This connector uses **SNMP** to retrieve data from the device, and allows alarm monitoring and trending of parameters.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Software Revision: 0600     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *100.99.98.97*.
- **Device address**: The slot the card is in, e.g. *7*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information about the device: **Card Name**, **Card ID**, **Software Revision**, etc.

### Amplifier

This page contains all the information about the amplifier: **Switch Mode**, **Re-Clock Input**, etc.

In addition, you can also find information about **CVBS**, **HDMI**, **Ports** etc. here.

### Alarms

On this page, you can set the different alarm priorities.
