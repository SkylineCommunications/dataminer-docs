---
uid: Connector_help_Teleste_HDO613_TSEMP_DVX
---

# Teleste HDO613 TSEMP DVX

The HDO613 is a wideband amplifier. It is installed into an HDX installation frame and can be used as a general gain block in headend and hub systems.

## About

This connector is used to control and monitor the HDO613 module using the DVX bus.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  -**IP address/host**: The polling IP of the serial gateway connected to the DVX Bus, e.g. *10.11.12.13.*
  - **IP port**: The port of the Local TCP connection used by the serial gateway, e.g. *4001.*
  - **Bus address**: The bus address of the connected device, in the format *X.Y* (where X = Rack Number, Y = Slot Number).

## Usage

### General page

On this page, you can find general information and statistical information (uptime, temperature, etc.) on the module.

Click the **Alarm Limits** page button to view or configure the analog and discrete alarm limits.

### RF

This page displays the **Attenuator** and **Equalizer** values.

Click the **Normalized Values** page button to configure the normalized value of the attenuator and equalizer parameters. With the **Normalize (All)** button, you can copy the current values to the normalized parameters.
