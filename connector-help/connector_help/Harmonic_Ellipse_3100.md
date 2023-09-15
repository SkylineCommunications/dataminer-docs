---
uid: Connector_help_Harmonic_Ellipse_3100
---

# Harmonic Ellipse 3100

The **Harmonic Ellipse 3100** encoders leverage Harmonic's industry-leading compression expertise and a flexible system architecture to bring new levels of video quality and work flow efficiency to broadcast contribution applications. Multi-format, multi-codec versatility, low latency and an optional integrated modulator make this all-new compression platform ideal for both digital satellite news gathering (DSNG) and fixed contribution.

## About

With this connector you can monitor and configure the Harmonic Ellipse 3100 Encoder via **SNMP**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V3.3.5.0.76                 |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device. \[e.g. 192.168.5.100\]

SNMP Settings:

- **Port number**: The port of the connected device. \[default: *161*\]
- **Get community string**: The community string used when reading values from the device. \[default: public\]
- **Set community string**: The community string used when setting values on the device. \[default: private\]

## Usage

### General

The General page contains the **Agent**, **License**, **SNTP**, **IPx**, **Modules**, **Traps**, **File Operations** & **Files**: **Date and Time**, **Timezone**, **Key**, etc.

Rows can be added to the **Traps Table** using the Add Row button.

### Alarms

The Alarms page contains everthing to configure the alarming: **Alarms Enabled**, **Alarms Config Table**, etc.

### Video

The Alarms page contains the **Video Input Tables** & **Video Encoding Table**: **VBI Table**, **Input Table**, etc.

### Audio

The Alarms page contains the **Audio Input Tables**, **Audio Encoding Table** & **Audio Advanced Encoding** Tables: **Embedded Table**, **Encoding Table**, **AAC Table**, **Dolby Table**, etc.

### Transport Stream

The Alarms page contains parameters about **Carrier ID**, **Satellite Delivery Descriptor**, **Cascading**, **Modulators**, etc.

Rows can be added to the **Services Table** using the Add Row button.

The **IF Modulator** and **L-Band Modulator** are default not polling. With the buttons polling for these can be enabled.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
