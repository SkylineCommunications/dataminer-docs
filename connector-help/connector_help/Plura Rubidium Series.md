---
uid: Connector_help_Plura_Rubidium_Series
---

# Plura Rubidium Series

The PLURA Rubidium series GT module is a "Master Time Code" generator with most typical studio synchronization capabilities and a dynamic number of input and output formats. The GT is designed for compact applications, which require only one power supply and one GPS receiver in order to generate a master LTC time code. It has a set of universal interfaces enabling it to be implemented for smaller compact time code applications (generators, converters) as well as larger multi-generator studio system applications.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.15.14                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page shows the complete range of functions. You can switch each function on or off. Switching it off will hide the relevant page.

### System

This page shows system settings such as the system name, fan monitoring and firmware version, as well as SNMP functionalities related to traps. On a subpage, **Profile** information is available.

### Keys

This page allows you to configure the GPIs (General Purpose Interfaces). You can also select settings for the function keys and LEDs.

### Jam

This page contains settings related to the jam sync function, which transfers data of an external LTC (Linear Time Code) to the time code generator. You can among others configure the mode, values and offset.

### Generate

This page contains the basic setup of the generator, including frame rate, sync and video system settings. You can also set the **time of the generator** as well as the date of the internal real-time frame counters.

You can also configure Impulse Telegram settings. This feature involves an output impulse telegram signal connected to the distribution amplifier to synchronize analogue clocks.

### Reference

This page allows you to configure an **external real-time source** that can be accepted as time and date reference. The Time Zone and DST Mode define the time zone of the real-time reference and the local time zone of the generator, while the Mode of Local Time Zone Synchronization determines how to periodically update the internal real-time counters.

On the **Time Zone** subpage, you can select the time zone of the reference and the local time zone.

### LTC Generate

This page allows you to adjust the output of the LTC (Linear Time Code) by configuring the parameters Gain, Mute and PC bit.

### MTD Generate

This page allows you to configure the functions within the MTD System. You can set up the Main Operation Mode timer, the MTD "Main" time, and the GPI output programmed with the "MTD Time" function.

On the **MTD Timer** subpage, you can set up the various timers of the MTD system.

### Link

This page shows parameters related to the link interface that is shared by all the modules in one frame. Via the RLC connector it is possible to link further modules in different frames. In case the current module should transmit data, on this page you can select the kind of data that should be sent for a specific channel. The receiving module must select this channel as reader input.

### Status Monitor

This page displays various status information, including the status of the **keys,** **fans**, **power supplies** and **frame**. It also contains **LTC** (Linear Time Code) information, such as the source and rate.
