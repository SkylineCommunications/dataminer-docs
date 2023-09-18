---
uid: Connector_help_WAGO_Kontakttechnik_750-880_(Flairmo)
---

# Wago Kontakttechnik 750-880 (Flairmo)

This connector displays information related to the **Kontakttechnik 750-880 (Flairmo)** air compressor device.

## About

This connector uses an **SNMP** interface to communicate with the 750-880 device. The SNMP interface is used to retrieve status information.

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses an SNMP connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General Page

This page displays status parameters, such as:

- Pressure
- Dewpoint
- Sensor Failure Status
- ...

### Web Interface Page

This page displays the web interface of the device.
