---
uid: Connector_help_Qbit_Q561
---

# QBIT Q561

The **Qbit Q561** is an IP audio encoder that can handle up to 8 digital (or 4 analog) stereo input channels simultaneously, delivering them as elementary streams via IP.

## About

This connector allows not only the complete monitoring of the QBit Q561 device, but also the configuration and control of every single parameter, including input and output flows. The current range, 1.1.0.x, is built using the latest firmware, which introduced several new functions and optimizations.

Note that any upgrade to the current range 1.1.0.x will cause the loss of all history built by previous versions.

### Version Info

| **Range** | **Description**      | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version      | No                  | Yes                     |
| 1.1.0.x          | New firmware version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | v2.245                      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains the main system parameters, such as the **name**, **type** and **language**. It also displays the real-time status of the system, including the **temperature** and **power supply**. A page button provides access to more detailed power supply information.

Via page buttons, you can configure the **System Network** and **System Time** configuration. There are several other buttons, which among others allow you to **reboot** the device in various ways and **save** the configuration.

Finally, this page also provides direct access to the **Traps**, **Signals**, **ISDN** and **Service Info** subpages.

### Encoder/Decoder

On the left, this page displays the **Encoder Table**, **Global Sampler Rate** and **Rate Slave Mode**. On the right, the **Decoder Table** is displayed. Both tables allow you to both monitor and configure every input channel.

Both for the encoder and for the decoder, page buttons provide access to additional configuration pages, such as **Ancillary**, **Alarms** and **Common** configuration. The encoder section also contains a configuration page for every supported encoding algorithm (**MPEG-1 Layer II**, **AAC**, **HE-AAC1**, **HE-AAC2**, **LPCM**, **APTX** and **G7xx**), while the decoder section contains the **Backup**, **Tools**, **ES Receive** and **TS Receive** configuration pages.

### PSI

This page provides access to the **Transport Stream** and **Program** configuration, including the configuration of all **elementary streams**.

### Output

This page allows you to monitor and configure the **output** flows. You can switch the **output mode** as well as configure all related output parameters, including **FEC** and **Repetition Time**.

### Alarms

This page contains the general alarms related to the **Audio Level**.

### Statistics

This page contains various **statistical** tables regarding **decoding** actions, such as **IP Bitrate**, **Lost Packets** and **Jitter**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface. In addition, the QBit Q561 web interface is currently not supported by Internet Explorer.
